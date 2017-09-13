<template>
	<div id="Detail" class="container-fluid">

		<div id="myModalCalle" class="modal">
			<div class="modal-dialog">
				<div class="upperBar">
					<p class="windowCaption">Calles</p>
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
							<label for="Nombre">Nombre:</label>
							<input :disabled="!isEditable" class="form-control" v-model="calle.Nombre" type="text" id="NombreInput" placeholder="Nombre"></input>
						</div>
						<div class="form-group">
							<label>Coordenada X:</label>
							<input :disabled="!isEditable" class="form-control" type="number" v-model="calle.CoordenadaX" id="CoorXInput" placeholder=""></input>
						</div>
						<div class="form-group row">
							<div class="col">
								<label>Coordenada Y:</label>

								<input :disabled="!isEditable" class="form-control" type="number" v-model="calle.CoordenadaY" id="CoorYInput" ></input>

							</div>
						</div>
						<div class="checkbox">
							<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="Circulable" id="circulableInput" >Circulable</label>
						</div>

						<div class="form-group row" v-if="Circulable">
							<label>Número de carriles:</label>
							<input :disabled="!isEditable" class="form-control" type="number" v-model="calle.NumeroCarriles" id="CarrilesInput" placeholder=""></input>
							<label>Accidentes mensuales:</label>
							<input :disabled="!isEditable" class="form-control" type="number" v-model="calle.AccidentesMensuales" id="AccidentesInput" placeholder=""></input>
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
				calle:{
				},
				previousCalle:{
				},
				isEditable:false,
				menuChoice : "Calle",
				estaVacio : false,
				currentIdData: "",
				Circulable: false,

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
					/*if(this.calle.Nombre===this.previousCalle.Nombre){
						return  true; 
					}
					else if(this.calle.Autor===""){
						return true;
					}
					else if(this.calle.Tipo === "" ){
						return true;
					} 
					else if(this.calle.Tamanio === ""){
						return  true; 
					}
					else{
						return false;
					}*/
					return false;
				}
				else if(this.state == constantes.STATE_UPDATE){
					if(this.calle.Nombre != this.previousCalle.Nombre){
						return false;
					}
					else if(this.calle.CoordenadaX != this.previousCalle.CoordenadaX){
						return false;
					}
					else if(this.calle.CoordenadaY != this.previousCalle.CoordenadaY){
						return false;
					}
					else if(this.Circulable != this.previousCalle.Circulable){
						return false;
					}
					if(this.Circulable){
						if(this.calle.NumeroCarriles != this.previousCalle.NumeroCarriles){
							return false;
						}
						else if(this.calle.Accidentes != this.previousCalle.Accidentes){
							return false;
						}
						else{return true;}
					}
					return true;
				}
			},
			computeDeleteButton: function(){
				if(!this.isEditable){
					return true;
				}
				else if(this.state == constantes.STATE_UPDATE){
					return false;
				}
				else {return true};
			},
		},
		methods:{
			buttonEnableEdit: function(){
				this.isEditable = !this.isEditable;
				this.previousCalle = $.extend({}, this.calle)
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
				this.calle.Circulable = this.Circulable;
				if(this.state == constantes.STATE_NEW){
					let errores = "";
					if(this.calle.Nombre===""){
						errores+="El nombre está vacío. \n";
					}
					else if(this.calle.Nombre.length >= 20){
						errores+="El nombre de la calle no puede exceder los 20 caracteres.\n";	
					}
					if(this.calle.CoordenadaX===null){
						errores+="El valor de la coordenada X está vacío. \n";
					}
					if(this.calle.CoordenadaY === null)
					{
						errores+="El valor de la coordenada Y está vacío. \n";
					}
					if(this.calle.Circulable){
						if(this.calle.NumeroCarriles === null){
							errores+="El número de carriles no puede estar vacio. \n";	
						} 
						else if(this.calle.NumeroCarriles <1){
							errores+="El número de carriles debe ser un número mayor que 0. \n";
						}
						if(this.calle.AccidentesMensuales === null){
							errores+="El valor de Accidentes mensuales no puede estar vacio. \n";
						}
						else if(this.calle.AccidentesMensuales <0){

							errores+="El número de Accidentes mensuales no puede ser menor que 0. \n";
						}
					}
					if(errores != ""){
						alert("Hay campos incorrectos. No se puede crear el objeto:\n" + errores);
					}
					else{
						$.ajax({url:constantes.BASE_URL + this.menuChoice,
							method:"POST",
							data: this.calle})	
						.done(this.afterPostHandler)
						.fail(function(){
							alert("Fallo en la creacion del elemento");
						//TODO: Gestionar los fallos
					})
					}

				}
				else if(this.state == constantes.STATE_UPDATE){
					// TODO: Se hace un PUT con el objeto
					if(!this.Circulable){
						this.calle.NumeroCarriles = null;
						this.calle.AccidentesMensuales = null;
					}else{
						if(this.calle.NumeroCarriles != null && this.calle.AccidentesMensuales != null){
							$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentIdData,
								method:"PUT",
								data: this.calle})
							.done(this.putSubmitData)
						}
						else{
							alert("Hay elementos vacios, no se puede actualizar.");
						}
					}
				}
			},
			afterPostHandler(){
				alert("Elemento creado");
				this.$emit('forceUpdate', true);

				// TODO: Se fuerza un get en el maestro y se cierra el detail.
				// Podemos llamar al metodo buttonCancelar.
			},
			putSubmitData(){
				alert("Elemento modificado");
				this.previousCalle = $.extend({}, this.calle);
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
				//this.calle = {};
				this.currentIdData = "";
				this.calle.Nombre = "";
				this.calle.CoordenadaX =null;
				this.calle.CoordenadaY = null;
				this.Circulable = false;
				this.calle.NumeroCarriles = null;
				this.calle.AccidentesMensuales = null;

				this.previousCalle = $.extend({}, this.calle)
			},
			submitGetRequest(datos){
				this.currentIdData = datos.Id;
				this.Circulable = datos.Circulable;
				this.calle = datos; 	
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
				this.currentId = 3;
				this.makeGetRequest();
				this.state = constantes.STATE_NEW;
				this.isEditable = true;
			},
			
		}, 
		mounted(){
			$("#myModalCalle").modal('show');
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