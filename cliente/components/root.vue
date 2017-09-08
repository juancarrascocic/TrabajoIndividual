<template>
<div class="rootContainer">
<taskBar @changeTopWindow = "changeTopWindow" :pestañasAbiertas="pestañasAbiertas"></taskBar>
<component @closeTab="closeTab" v-for="item in pestañasAbiertas" :is="item" class="tabWindow" :class="changeTopWindowClass(item)"></component>
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
			},
			changeTopWindowClass: function(window){
				if(this.currentWindow == window){
					return "currentWindow";
				}
				else{
					return "notCurrentWindow";
				}
			}

		}
	}
</script>

<style>
	.rootContainer{
		width: 100%;
	}
	.tabWindow{
		top:0;
		position: absolute;
	}
	.currentWindow{
		z-index: 1000;
		top:0;
	}
	.notCurrentWindow{
		z-index: 100;
		top:0;
	}
</style>