<template>
	<div id="Detail" class="container-fluid">

		<div id="myModalSemaforos" class="modal">
			<div class="modal-dialog">
				<div class="upperBar">
					<p class="windowCaption">Semaforos</p>
					<i class="fa fa-window-minimize buttonMinimize" aria-hidden="true" ></i>
					<i class="fa fa-window-maximize buttonMaximize" aria-hidden="true"></i>
					<i class="fa fa-times buttonClose" aria-hidden="true" v-on:click= "buttonCancelar"></i>
				</div> 
				<div class="modal-body">

					<div id ="FormularioDocumentos" class="mx-auto" style="width: 45%">
						<center>
							<div class="form-group">
								<button :disabled="this.isEditable" id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit">Modificar</button>
								<button  id="cancelarButton" class="btn btn-default" v-on:click="buttonCancelar">Cancelar</button>

							</div>
						</center>
						<div class="form-group">
							<label for="Nombre">Calle:</label>
							<select :disabled="!isEditable" class="form-control" v-model="semaforo.Calle" type="text" id="NombreInput" placeholder="Nombre">
								<option v-for="item in this.comboCalles" :value="item">{{item}}</option>
							</select>
						</div>
						<div class="form-group">
							<label>Tiempo verde:</label>
							<input :disabled="!isEditable" class="form-control" type="number" v-model="semaforo.TiempoVerde" id="CoorXInput" placeholder=""></input>
						</div>
						<div class="form-group row">
							<div class="col">
								<label>Tiempo rojo:</label>
								<input :disabled="!isEditable" class="form-control" type="number" v-model="semaforo.TiempoRojo" id="CoorYInput" ></input>

							</div>
						</div>
						<div class="checkbox">
							<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="semaforo.PasoPeatones" id="circulableInput" >Paso de peatones</label>
						</div>
						<center>
							<div class="form-group">
								<button  id="acceptButton" :disabled="this.computeAcceptButton" class="btn btn-success" v-on:click="buttonAccept">Aceptar</button>
								<button  id="borrarButton" :disabled="this.computeDeleteButton" class="btn btn-danger" v-on:click="buttonBorrar">Borrar</button>
							</div>
						</center>

					</div>



				</div>
			</div>
		</div>
	</div>


</div>
</template>

<script>
	import constantes from './constants.js';

	export default{
		components:{
		},
		data (){
			return{
				semaforo:{
				},
				previousSemaforo:{
				},
				isEditable:false,
				menuChoice : "Semaforos",
				estaVacio : false,
				comboCalles:[],
				currentIdData: ""

			}
		},
		props:[
		'state',
		'currentId'
		],
		computed:{
			computeAcceptButton: function()	{
				if(!this.isEditable){
					return  true; 
				}
				else if(this.state == constantes.STATE_NEW){
					/*if(this.semaforo.Nombre===this.previousDocument.Nombre){
						return  true; 
					}
					else if(this.semaforo.Autor===""){
						return true;
					}
					else if(this.semaforo.Tipo === "" ){
						return true;
					} 
					else if(this.semaforo.Tamanio === ""){
						return  true; 
					}
					else{
						return false;
					}*/
					return false;
				}
				else if(this.state == constantes.STATE_UPDATE){
					if(this.semaforo.Calle != this.previousSemaforo.Calle){
						return false;
					}
					else if(this.semaforo.TiempoVerde != this.previousSemaforo.TiempoVerde){
						return false;
					}
					else if(this.semaforo.TiempoRojo != this.previousSemaforo.TiempoRojo){
						return false;
					}
					else if(this.semaforo.PasoPeatones != this.previousSemaforo.PasoPeatones){
						return false;
					}
					else{return true;}
				}
			},
			computeDeleteButton: function(){
				if(this.state == constantes.STATE_UPDATE){
					return false;
				}
				else {return true};
			},
		},
		methods:{
			buttonEnableEdit: function(){
				this.isEditable = !this.isEditable;
				this.previousSemaforo = $.extend({}, this.semaforo)
			},
			buttonBorrar: function(){
				if(confirm("¿Está seguro de que quiere borrar?")){
					//TODO: Peticion AJAX
					$.ajax({
						url:constantes.BASE_URL + this.menuChoice + "/" + this.currentIdData,
						method: "DELETE"
					})
					.done(this.borradoHandler)
					.fail(function(){alert("Ha habido un error al borrar.");})
				}
			},
			buttonCancelar: function(){
				this.$emit('cancelDetail', true);

			},
			borradoHandler: function(){
				alert("Elemento borrado correctamente.");
				this.$emit('makeGet', true);
				this.makeEmptyData();
			},
			buttonAccept: function(){

				if(this.state == constantes.STATE_NEW){
					let errores = "";
					if(this.semaforo.Calle===""){
						errores+="El valor de Calle está vacío. \n";
					}
					if(this.semaforo.TiempoVerde===null){
						errores+="El valor de Tiempo verde está vacío. \n";
					}
					if(this.semaforo.TiempoRojo ===null)
					{
						errores+="El valor de Tiempo rojo está vacío. \n";
					}
					if(errores != ""){
						alert("Hay campos incorrectos. No se puede crear el objeto:\n" + errores);
					}
					else{
						$.ajax({url:constantes.BASE_URL + this.menuChoice,
							method:"POST",
							data: this.semaforo})	
						.done(this.afterPostHandler)
						.fail(function(){
							alert("Fallo en la creacion del elemento");
						//TODO: Gestionar los fallos
					})
					}

				}
				else if(this.state == constantes.STATE_UPDATE){
					// TODO: Se hace un PUT con el objeto

					$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentIdData,
						method:"PUT",
						data: this.semaforo})
					.done(this.putSubmitData)
				}
			},
			afterPostHandler(){
				alert("Elemento creado");
				this.$emit('forceUpdate', true);

				// TODO: Se fuerza un get en el maestro y se cierra el detail.
				// Podemos llamar al metodo buttonCancelar.
			},
			getComboCalles: function(){
				$.ajax({
					url: constantes.BASE_URL + "Calle",
					method: "GET"
				})
				.done(this.afterComboHandler)
			},
			afterComboHandler: function(datos){
				var _this = this;
				datos.forEach(function(element){
					if(!_this.comboCalles.includes(element.Nombre)){
						_this.comboCalles.push(element.Nombre);
					}
				});
			},
			putSubmitData(){
				alert("Elemento modificado");
				this.previousSemaforo = $.extend({}, this.semaforo);
				this.$emit('forceUpdate', true);

			}, 	
			makeGetRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice + "/" + this.currentIdData,
					method: "GET"
				})
				.done(this.submitGetRequest)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			makeEmptyData(){
				if(!this.estaVacio){
					this.semaforo = {};
					this.currentId = "";
					this.semaforo.Calle = "";
					this.semaforo.TiempoVerde = null;
					this.semaforo.TiempoRojo = null;
					this.semaforo.PasoPeatones = false;


					this.previousSemaforo = $.extend({}, this.semaforo);
				}
			},
			submitGetRequest(datos){
				this.currentIdData = datos.Id;
				this.semaforo = datos; 	
			},
			/*parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					
					if(element.Tipo == 2){
						_this.lista[index].Tipo = "Imagen";
					}
					else if(element.Tipo == 3){
						_this.lista[index].Tipo = "PDF";
					}
					else if(element.Tipo == 4){
						_this.lista[index].Tipo = "Hoja de cálculo";
					}
					else if(element.Tipo == 5){
						_this.lista[index].Tipo = "Documento de Word";
					}
					else if(element.Tipo == 1){
						_this.lista[index].Tipo = "Texto";
					}
				});
			},*/
			makeNewDetail: function(){
				this.makeEmptyData();
				this.currentIdData = "";
				this.state = constantes.STATE_NEW;
				this.isEditable = true;
			},
			
		}, 
		mounted(){
			$("#myModalSemaforos").modal('show');
			this.getComboCalles();
			if(this.state == constantes.STATE_UPDATE){
				this.currentIdData = this.currentId;
				this.makeGetRequest();
			}
			else if(this.state == constantes.STATE_NEW){
				this.makeEmptyData(); 	
				this.estaVacio = true;
				this.isEditable = true;
			}
			$('.modal-dialog').draggable({
				handle: ".upperBar"
			});
		},
		updated(){
		/*	if(this.state == constantes.STATE_NEW){
				this.makeNewDetail();
			}*/
		}
	}
</script>

<style>

	.upperBar{
		height: 25px;
		position: fixed;
		z-index: 9999;
		width: 100%;
		background-color: #bed1d8;
	}
	.windowCaption{
		color: white;
		font-weight: bold;
		margin-left: 5px;
		text-align: left;

	}
	.buttonClose{
		height: 25px;
		width: 25px;
		right: 0;
		top: 4px;
		float: right;
		position: absolute;
	}
	.buttonMaximize{
		height: 25px;
		width: 25px;
		right:0;
		margin-right: 30px;
		top: 4px;
		float: right;
		position: absolute;
	}
	.buttonMinimize{
		height: 25px;
		width: 25px;
		right:0;
		margin-right: 60px;
		top: 4px;
		float: right;
		position: absolute;
	}
	.modal-body{
		background-color: #fff;
		padding-top: 40px;
		height: 97%;
	}
	.modal-dialog{
		border:solid;
	}
</style>