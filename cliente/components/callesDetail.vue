<template>
	<div id="Detail" class="container-fluid">

		<div id="myModal" class="modal">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<h4 class="modal-title">Detalle: Calles</h4>
						<button type="button" class="close" data-dismiss="modal" v-on:click= "buttonCancelar" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">

						<div id ="FormularioDocumentos" class="mx-auto" style="width: 45%">
							<center>
								<div class="form-group">
									<button :disabled="this.isEditable" id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit">Modificar</button>
									<button  id="cancelarButton" class="btn btn-primary" v-on:click="buttonCancelar">Cancelar</button>

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
								<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="calle.Circulable" id="circulableInput" >Circulable</label>
							</div>

							<div class="form-group row" v-if="this.calle.Circulable">
							<label>Número de carriles:</label>
								<input :disabled="!isEditable" class="form-control" type="number" v-model="calle.NumeroCarriles" id="CarrilesInput" placeholder=""></input>
								<label>Accidentes mensuales:</label>
								<input :disabled="!isEditable" class="form-control" type="number" v-model="calle.AccidentesMensuales" id="AccidentesInput" placeholder=""></input>
							</div>
							<center>
								<div class="form-group">
									<button  id="acceptButton" :disabled="this.computeAcceptButton" class="btn btn-primary" v-on:click="buttonAccept">Aceptar</button>
									<button  id="borrarButton" :disabled="this.computeDeleteButton" class="btn btn-primary" v-on:click="buttonBorrar">Borrar</button>
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
				previousDocument:{
				},
				isEditable:false,
				menuChoice : "Calle",
				estaVacio : false

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
					/*if(this.calle.Nombre===this.previousDocument.Nombre){
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
					if(this.calle.Nombre != this.previousDocument.Nombre){
						return false;
					}
					else if(this.calle.Autor != this.previousDocument.Autor){
						return false;
					}
					else if(this.calle.FechaCreacion != this.previousDocument.FechaCreacion){
						return false;
					}
					else if(this.calle.FechaUltimoModificado != this.previousDocument.FechaUltimoModificado){
						return false;
					}
					else if(this.calle.Tipo != this.previousDocument.Tipo){
						return false;
					}
					else if(this.calle.Tamanio != this.previousDocument.Tamanio){
						return false;
					}
					else if(this.calle.SoloLectura != this.previousDocument.SoloLectura){
						return false;
					}
					else if(this.calle.VersionFinal != this.previousDocument.VersionFinal){
						return false;
					}
					else{return true;}
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
				this.previousDocument = $.extend({}, this.calle)
			},
			buttonBorrar: function(){
				if(confirm("¿Está seguro de que quiere borrar?")){
					//TODO: Peticion AJAX
					$.ajax({
						url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
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
					if(this.calle.Nombre===""){
						errores+="El valor de Título está vacío. \n";
					}
					if(this.calle.Autor===""){
						errores+="El valor de Autor está vacío. \n";
					}
					if(this.calle.FechaCreacion === "")
					{
						errores+="El valor de Fecha de Creación está vacío. \n";
					}
					if(this.calle.FechaUltimoModificado === "" )
					{
						errores+="El valor de Última Modificación está vacío. \n";
					}
					if(this.calle.Tipo === 0){
						errores+="El valor de Tipo no es correcto. \n";	
					} 
					if(this.calle.Tamanio === 0){
						errores+="El valor de Tamaño es 0. \n";
					}
					if(errores != ""){
						alert("Hay campos no rellenados. No se puede crear el objeto:\n" + errores);
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

					$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method:"PUT",
						data: this.calle})
					.done(this.putSubmitData)
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
				this.previousDocument = $.extend({}, this.calle);
				this.$emit('forceUpdate', true);

			}, 	
			makeGetRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
					method: "GET"
				})
				.done(this.submitGetRequest)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			makeEmptyData(){
				if(!this.estaVacio){
					this.calle = {};
					this.currentId = "";
					this.calle.Nombre = "";
					this.calle.Autor = "";
					this.calle.FechaCreacion = "";
					this.calle.FechaUltimoModificado = "";
					this.calle.Tipo = 0;
					this.calle.Tamanio = 0;
					this.calle.VersionFinal = false;
					this.calle.SoloLectura = false;

					this.previousDocument={};
					this.previousDocument.Nombre = "";
					this.previousDocument.Autor = "";
					this.previousDocument.FechaCreacion = "";
					this.previousDocument.FechaUltimoModificado = "";
					this.previousDocument.Tipo = 0;
					this.previousDocument.Tamanio = 0;
					this.previousDocument.VersionFinal = false;
					this.previousDocument.SoloLectura = false;
				}
			},
			submitGetRequest(datos){
				this.currentId = datos.Id;
				this.calle = datos; 	
			},
			parseTipo: function(array){
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
			},
			makeNewDetail: function(){
				this.makeEmptyData();
				this.currentId = "";
				this.state = constantes.STATE_NEW;
				this.isEditable = true;
			},
			
		}, 
		mounted(){
			$("#myModal").modal('show');
			if(this.state == constantes.STATE_UPDATE){
				this.makeGetRequest();
			}
			else if(this.state == constantes.STATE_NEW){
				this.makeEmptyData(); 	
				this.estaVacio = true;
				this.isEditable = true;
			}
		},
		updated(){
		/*	if(this.state == constantes.STATE_NEW){
				this.makeNewDetail();
			}*/
		}
	}
</script>

<style>

</style>