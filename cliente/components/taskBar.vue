<template>
	<div class="mainContainer">
		<div class ="menuStart "v-if="this.showMenu">
			<div class="menuStartRow" v-for="item in pestañasDisponibles" v-on:click ="setPestaña(item)">
				<p>{{item}}</p>
			</div>
		</div>
		<div class="barContainer">
			<button class="startButton" v-on:click="this.hoverMenu"><i class="fa fa-bars" aria-hidden="true" ></i>START</button>
			<div class="tabContainer">
				<div class="pestanya" v-for="item in pestañasAbiertas" v-on:click="changeTopWindow(item)">
					<p class="textoPestanya">{{item}}</p>
				</div>
			</div>
			<div class="taskContainer">
				<div class="serverOkay" v-on:click="pingServer">
					<i class="fa fa-check centerButton"  v-if="this.isServerOkay"></i>
					<i class="fa fa-exclamation-triangle centerButton" v-else></i>	
				</div>
				<div class="showInfo" v-on:click="showInfo">
					<i class="fa fa-info centerButton"></i>
				</div>
				<div class="minimizeAllButton" v-on:click="minimizeAll">
					<i class="fa fa-home centerButton" aria-hidden="true"></i>
				</div>

				<!-- TODO Puedo poner un boton de info en plan de versiom autor, etc-->
			</div>
		</div>


		<div id="myModalInfo" class="modal">
			<div class="modal-dialog">
				<div class="upperBarInfo">
					<p class="windowCaption"><i class="fa f-info"></i>Info</p>
					<i class="fa fa-window-minimize buttonMinimize" aria-hidden="true" ></i>
					<i class="fa fa-window-maximize buttonMaximize" aria-hidden="true"></i>
					<i class="fa fa-times buttonClose" aria-hidden="true" v-on:click= "buttonCancelar"></i>
				</div> 
				<div class="modal-body">
					<p>{{this.currentDate}}</p>
					<p>Gestor de tráfico v1.0.0Beta</p>
					<p>Juan Carrasco Alonso</p>

				</div>



			</div>
		</div>
	</div>
</div>



</div>
</template>



<script>
	import constantes from './constants.js'


	export default{
		components:{

		},
		props:['pestañasAbiertas'],
		data (){
			return{
				pestañasDisponibles:['Calles', 'Semaforos'],
				showMenu:false,
				currentDate: "",
				isServerOkay: true
			}
		},
		computed:{

		},
		methods:{
			hoverMenu: function(){
				this.showMenu = !this.showMenu;
			},
			setPestaña: function(nombrePestaña){
				if($.inArray(nombrePestaña, this.pestañasAbiertas) == -1){
					this.pestañasAbiertas.push(nombrePestaña);
				}
				this.hoverMenu();
				this.changeTopWindow(nombrePestaña);
			},
			changeTopWindow:function(nombrePestaña){
				this.$emit('changeTopWindow', nombrePestaña);

			},
			minimizeAll: function(){
				this.$emit('minimizeAll');
			},
			showInfo: function(){
				let currentDate = new Date().toString();
				this.currentDate = currentDate.replace('"', '');
				this.currentDate = this.currentDate.substr(0,21);
				$("#myModalInfo").modal('show');
			},
			buttonCancelar: function(){
				$("#myModalInfo").modal('hide');
			},
			pingServer: function(){
				$.ajax({
					url:constantes.BASE_URL + "KeepAlives",
					method: "GET"
				})
				.done(this.setServerOkay)
				.fail(this.setServerKO)
			},
			setServerOkay: function(){
				this.isServerOkay = true;
			},
			setServerKO: function(datos){
				this.isServerOkay = false;
			}
		},
		mounted(){
			setInterval(this.pingServer, 15000);
		}
	}
</script>

<style>
	.upperBarInfo{
		height: 25px;
		position: fixed;
		z-index: 9999;
		width: 100%;
		background-color: #bed1d8 ;
	}
	.windowCaption{
		color: white;
		font-weight: bold;
		text-align: left;
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
	.barContainer{
		width: 100%;
		overflow: hidden;
		left: 0;
		height:100%;
		background-color:  #7ea4b3;
	}
	.centerButton{
		vertical-align: middle;
	}
	.minimizeAllButton{
		bottom: 0;
		color:white;
		text-align: center;
		right: 0;
		width:50px;
		height:100%;
		position: absolute;
		border: solid;
		border-color:white;
	}
	.serverOkay{
		width: 50px;
		bottom: 0;
		height: 100%;
		text-align: center;
		border: solid;
		border-color: white;
		color:white;
		right: 50px;
	}
	.showInfo{
		width: 50px;
		height: 100%;
		bottom: 0;
		right: 50px;
		position: absolute;
		text-align: center;
		border: solid;
		border-color: white;
		color:white;
	}
	.mainContainer{
		position:fixed; 
		bottom:0;
		width: 100%;
		left:0;
		z-index: 100000;
	}
	.textoPestanya{
		vertical-align: middle;
		font-size: 20px;
	}
	.startButton{
		position:absolute; 
		left:0;
		background-color: #77dd77 ;
		width:100px;
		height:inherit;
	}
	.menuStart{
		position: absolute;
		bottom:100%;
		left:0;
		width: 100px;
	}
	.menuStartRow{
		position: relative;
		background-color: #acb583;
		height: 35px;
		left:0;
		border:solid;
		border-color: #ccd2b3;
		border-width: 2px;
		width:100px;

		/*Para evitar que sea seleccionable el texto*/
		-webkit-touch-callout: none; /* iOS Safari */
		-webkit-user-select: none; /* Safari */
		-khtml-user-select: none; /* Konqueror HTML */
		-moz-user-select: none; /* Firefox */
		-ms-user-select: none; /* Internet Explorer/Edge */
            user-select: none; /* Non-prefixed version, currently
            supported by Chrome and Opera */
        }
        .pestanya{
        	width: 150px;
        	background-color: #557f90;
        	height: 100%;
        	display: inline-block;
        	vertical-align: middle;
        	bottom: 0;
        	border-right: solid;
        	text-align: center;
        	border-color: #7ea4b3;
        }
        .tabContainer{
        	left:100px;
        	position: absolute;
        	/*Para evitar que sea seleccionable el texto*/
        	-webkit-touch-callout: none; /* iOS Safari */
        	-webkit-user-select: none; /* Safari */
        	-khtml-user-select: none; /* Konqueror HTML */
        	-moz-user-select: none; /* Firefox */
        	-ms-user-select: none; /* Internet Explorer/Edge */
            user-select: none; /* Non-prefixed version, currently
            supported by Chrome and Opera */
        }

        .taskContainer{
        	background-color: inherit;
        	width: 150px;
        	height: 100%;
        	right: 0;
        	bottom: 0;
        	position: absolute;
        }
    </style>