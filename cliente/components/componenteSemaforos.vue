<template>
	<div class="componenteSemaforosContainer">
		<div class="upperBar">
			<p class="windowCaption">Semáforos</p>
			<i class="fa fa-window-minimize buttonMinimize" aria-hidden="true" ></i>
			<i class="fa fa-window-maximize buttonMaximize" aria-hidden="true"></i>
			<i class="fa fa-times buttonClose" aria-hidden="true" v-on:click="closeTab"></i>
		</div>
		<div class="windowContent">
			<h1>SEMAFOROS</h1>
		</div>
	</div>
</template>



<script>
	import constantes from './constants.js'

	export default{
		components:{


		},
		data (){
			return{
			}
		},
		computed:{
			
		},
		methods:{
			closeTab: function(){
				this.$emit('closeTab', "Semaforos");
			},

		}
	}
</script>

<style>
	.componenteSemaforosContainer{
		background-color: green;
		width: 100%;
		height: auto;
		max-height: 650px;
	}
	.windowContent{
		margin-top: 25px;
		max-height: inherit;
		overflow: auto;
	}
	.upperBar{
		height: 25px;
		width: 100%;
		position: fixed;
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