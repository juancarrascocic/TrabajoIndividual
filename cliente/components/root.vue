<template>
	<div class="rootContainer">
		<taskBar class= "taskBar" @minimizeAll ="minimizeAll" @changeTopWindow = "changeTopWindow" :pestañasAbiertas="pestañasAbiertas"></taskBar>
		<img src="https://images.vexels.com/media/users/3/127711/isolated/preview/384e0b3361d99d9c370b4037115324b9-flat-vintage-car-icon-by-vexels.png"></img>
		<component v-show="!allMinimized" @closeTab="closeTab" v-for="item in pestañasAbiertas" :is="item" class="tabWindow" :class="changeTopWindowClass(item)" key="item"></component>

		
	</div>
</template>



<script>
	import constantes from './constants.js'
	import taskBar from './taskBar.vue'
	import Calles from './componenteCalle.vue'
	import Semaforos from './componenteSemaforos.vue'

	export default{
		components:{
			taskBar,
			Calles,
			Semaforos

		},
		data (){
			return{
				pestañasAbiertas:[],
				currentWindow:"",
				allMinimized : false,	
			}
		},
		computed:{

		},
		methods:{
			closeTab:function(tabName){
				let index = this.pestañasAbiertas.indexOf(tabName);
				this.pestañasAbiertas.splice(index, 1);
				this.currentWindow = "";
			},
			changeTopWindow:function(windowName){
				this.currentWindow = windowName;
				this.allMinimized = false;
			},
			changeTopWindowClass: function(window){
				if(this.currentWindow == window){
					return "currentWindow";
				}
				else{
					return "notCurrentWindow";
				}
			},	
			minimizeAll: function(){
				this.allMinimized = true;
			}
		}
	}
</script>

<style>
	.rootContainer{
		width: 100%;
		overflow: hidden;
	}
	.tabWindow{
		top:0;
		height:95%;
		position: absolute;
	}
	.currentWindow{
		z-index: 1000;
		top:0;
		height: 95%;
	}
	.taskBar{
		height:5%;
	}
	.notCurrentWindow{
		z-index: 100;
		top:0;
	}
	img {
		display: inline-block;
		margin: 0 auto;
		margin-top: 15%;
		vertical-align: middle;
	}
	.bodyClass{
		overflow: hidden;
		z-index: 0;	
		text-align: center;
		background-color: #eccccf;
	}
	.modal-backdrop.show{
		z-index: -1;
		opacity: 0;
	}
</style>