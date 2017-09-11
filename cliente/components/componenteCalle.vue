<template>
	<div class="componenteCalleContainer">
		<div class="upperBar">
			<p class="windowCaption">Calles</p>
			<i class="fa fa-window-minimize buttonMinimize" aria-hidden="true" ></i>
			<i class="fa fa-window-maximize buttonMaximize" aria-hidden="true"></i>
			<i class="fa fa-times buttonClose" aria-hidden="true" v-on:click="closeTab"></i>
		</div>
		<div class="windowContent">
		<callesMaster></callesMaster>
		</div>
	</div>	
</template>



<script>
	import constantes from './constants.js'
	import callesMaster from './callesMaster.vue'
	export default{
		components:{
			callesMaster

		},
		data (){
			return{
			}
		},
		computed:{
			
		},
		methods:{
			closeTab: function(){
				this.$emit('closeTab', "Calles");
			},

		}
	}
</script>

<style>
	.componenteCalleContainer{
		background-color: white;
		width: 100%;
			}
	.windowContent{
		margin-top: 25px;
		overflow: auto;
		height: 97%;
	}
	.upperBar{
		height: 3%;
		position: fixed;
		width: 100%;
		background-color: red;
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
	.windowCaption{
		color: white;
		font-weight: bold;
		margin-left: 5px;
	}
</style>