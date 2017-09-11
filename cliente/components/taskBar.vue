<template>
	<div class="mainContainer">
		<div class ="menuStart "v-if="this.showMenu">
			<div class="menuStartRow" v-for="item in pestañasDisponibles" v-on:click ="setPestaña(item)">
				<p>{{item}}</p>
			</div>
		</div>
		<div class="barContainer">
			<button class="startButton" v-on:click="this.hoverMenu"><i class="fa fa-bars" aria-hidden="true" ></i>  START</button>
			<div class="tabContainer">
				<div class="pestanya" v-for="item in pestañasAbiertas" v-on:click="changeTopWindow(item)">
					<p>{{item}}</p>
				</div>
			</div>
			<div class="taskContainer">
				<div class="minimizeAllButton" v-on:click="minimizeAll">
					<i class="fa fa-home" aria-hidden="true"></i>
				</div>
				<!-- TODO Puedo poner un boton de info en plan de versiom autor, etc-->
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
			}
		}
	}
</script>

<style>
	.barContainer{
		width: 100%;
		overflow: hidden;
		left: 0;
		height: 35px;
		background-color:  #0062EA;
	}
	.minimizeAllButton{
		bottom: 0;
		color:white;
		text-align: center;
		right: 0;
		position: absolute;
		height: 35px;
		border: solid;
		border-color:white;
		width:35px;
	}
	.mainContainer{
		position:fixed; 
		bottom:0;
		width: 100%;
		left:0;
		z-index: 100000;
	}
	.startButton{
		position:absolute; 
		left:0;
		background-color: #5EDB5E;
		width:100px;
		height:inherit;
	}
	.menuStart{
		position: absolute;
		bottom:35px;
		left:0;
		width: 100px;
	}
	.menuStartRow{
		position: relative;
		background-color: yellow;
		height: 35px;
		left:0;
		border:solid;
		border-color: red;
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
        	background-color: grey;
        	height: 35px;
        	display: inline-block;
        	bottom: 0;
        	border: solid;
        	text-align: center;
        	border-color: yellow;
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
        	background-color: red;
        	width: 35px;
        	height: 100%;
        	right: 0;
        	bottom: 0;
        	position: absolute;
        }
    </style>