<template>
	<div class="componenteSemaforosContainer">
		<div class="upperBar">
			<p class="windowCaption">Semáforos</p>
			<i class="fa fa-times buttonClose" aria-hidden="true" v-on:click="closeTab"></i>
		</div>
				<h1>BBBBBBBB</h1>

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
			}
		}
	}
</script>

<style>
	.componenteSemaforosContainer{
		background-color: green;
		width: 100%;
		height: 1500px;
	}
	.upperBar{
		height: 25px;
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
	.windowCaption{
		color: white;
		font-weight: bold;
		margin-left: 5px;
	}
</style>