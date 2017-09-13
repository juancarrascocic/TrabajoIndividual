<template>
	<div id="semaforosMaster">

		<table class="table">
			<table class="table table-hover" role="tablist">
				<thead>
					<tr>
						<th>#</th>
						<th>Calle</th>
						<th>Tiempo verde</th>
						<th>Tiempo rojo</th>
						<th>Paso de peatones</th>
						<th> <i class="fa fa-user-plus" aria-hidden="true" v-on:click="getNewDetail()"></i> </a></th>
					</tr>
				</thead>			
				
				<tbody @click="" v-for="(item, index) in lista">

					<tr v-on:click="renderDetail(item.Id)">
						<th scope="row" v-model='index'>{{index+1}}</th>
						<td>{{item.Calle}}</td>
						<td>{{item.TiempoVerde}}</td>
						<td>{{item.TiempoRojo}}</td>
						<td><input disabled ="true" type="checkbox" name="vehicle"  v-model="item.PasoPeatones" value="Bike"></td>

					</tr>
					<div id="detail-tr" v-if="item.Id == elegido">
						<div colspan="6">
							<detail @makeGet= "recargarMaster" @forceUpdate = "forceUpdate" @cancelDetail = "removeDetail" :currentId = "elegido" :state = "state" role="tabpanel" class="float-right"> </detail>
						</div>
					</div>
					
				</tbody>

			</table>
			
		</table>

		<div  v-if="computeShowNewDetail">
			<detail @cancelDetail ="removeDetail" @forceUpdate = "forceUpdate" :currentId = "elegido" :state ="state" role="tabpanel" class="float-right"> </detail>
		</div>
	</div>
</template>
<script type="text/javascript">
	import constantes from './constants.js';
	import detail from './semaforosDetail.vue'
	export default{
		name: "Semaforo",
		components:{
			detail,
		},
		data (){
			return{
				lista: [],
				menuChoice:"Semaforos",
				state: "",
				elegido : "",

			}
		},
		computed:{
			computeShowNewDetail(){
				return this.state === constantes.STATE_NEW;
			},
		},
		methods:{
			makeGetListRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice,
					method: "GET"
				})
				.done(this.submitGetListValues)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			forceUpdate: function(){
				this.removeDetail();
				this.makeGetListRequest();
			},
			recargarMaster: function(){
				this.removeDetail();
				this.makeGetListRequest();
			},
			removeDetail: function(){
				this.elegido = "";
				this.state = "";
			},
			submitGetListValues: function(datos){
				this.lista = datos;
				this.parseTipo(datos);
			},
			parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					if(element.Tipo == 1){
						_this.lista[index].Tipo = "Texto";
					}
					else if(element.Tipo == 2){
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
					if(element.SoloLectura){
						_this.lista[index].SoloLectura = "Si";
					}
					else{
						_this.lista[index].SoloLectura = "No";
					}
				});
			},

			emitEnableDetailEvent(read) {
		      // Send the event on a channel () with a payload ()
		      EventBus.$emit('enableDetail', this.read);
		  },
		  getNewDetail: function(){
		  	this.state = constantes.STATE_NEW;
		  	this.elegido = "";
				//this.emitEnableDetailEvent(this.read);
			},	
			renderDetail: function(index){
				if(this.state == constantes.STATE_UPDATE){
					if(this.elegido == index){
						this.elegido ="";
						this.state = "";
					}
					else {
						this.elegido = index;
					}
				}
				else{
					this.state = constantes.STATE_UPDATE
					this.elegido = index;
				//this.showDetail == false ? this.showDetail = true :  this.showDetail = false;
			}

		},		
	},
	created(){
		this.makeGetListRequest();
	},
}
</script>
<style type="text/css">
	#detail-tr:hover{
		background-color: white;
	}
	td{
		text-align: left;
	}

</style>