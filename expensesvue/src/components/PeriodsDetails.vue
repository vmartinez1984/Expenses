<template>
    <div class="container">
        <div class="card">
            <div class="card-header">
                <h2 class="text-primary">Periodo</h2>
            </div>

            <div class="card-body">

                <div v-if="estaCargando">
                    <div class="text-center">
                        <p class="text-info">Cargando registros...</p>
                        <div class="spinner-border text-info" role="status">
                            <span class="visually-hidden">Loading...</span>
                        </div>
                    </div>
                </div>
                <div class="text-danger" v-if="hayError">
                    <div class="text-center">
                        <h5>{{ error }}</h5>
                    </div>
                </div>
                
                <div class="row border border-primary m-1 p-1" v-for="expense in period.listExpenses" :key="expense.id">
                    <div class="col">{{ expense.categoryName }}</div>
                    <div class="col">{{ expense.subcategoryName }}</div>
                    <div class="col">$ {{ expense.budget }}</div>
                    <div class="col">$ {{ expense.amount }}</div>
                    <div class="col">
                        <div v-if="expense.amount == 0">
                            <button class="btn btn-primary">Agregar</button>
                        </div>
                        <div v-if="expense.amount != 0">
                            <button class="btn btn-warning text-white">Editar</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</template>
<script>
import periodService from '@/services/periodService'
//import { toRaw } from 'vue';

 export default {
    data(){
        return{
            period:{},
            estaCargando : true,
            hayError: false,
            error:''
        }
    },
    created: function(){
        this.getPeriodDetailsAsync()
    },
    methods:{
        async getPeriodDetailsAsync(){
            try{
                this.estaCargando = true
                //console.log(this.$route.query.id)
                this.period = await periodService.getPeriodAsync(this.$route.query.id)            
                // this.period = response.listExpenses
                console.log(this.period)
                this.estaCargando = false
            }catch(err){
                this.error = 'Ocurrio un error al cargar :('
                this.hayError = true
                this.estaCargando = false
            }
        }
    }
 }
</script>