<template>
    <div class="container mt-5">

        <div class="card">
            <div class="card-header">
                <h2 class="text-info">Periodos</h2>

                <!-- Button trigger modal -->
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                    Agregar nuevo
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            ...
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Fecha de inicio</th>
                            <th>Fecha fin</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Nombre</th>
                            <th>Fecha de inicio</th>
                            <th>Fecha fin</th>
                            <th></th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <tr v-for="period in periods" :key="period.id">
                            <td>{{ period.name }}</td>
                            <td>{{ period.dateStart.substring(0,10) }}</td>
                            <td>{{ period.dateStop.substring(0,10) }}</td>
                            <td>                                
                                <button class="btn btn-warning text-white">Editar</button>
                                <router-link class="btn btn-info text-white" :to="{name:'periodsDetails', query:{id: period.id}}">Detalles</router-link>
                                <button class="btn btn-danger text-white" v-on:click="deletePeriod(period.id)">Borrar</button>                               
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

    </div>
</template>
<script>
export default {
    name: 'PeriodsList',
    data(){
        return{
            periods:[]
        }
    },
    created: function(){
        this.getPeriods()
    },
    methods:{
        getPeriods(){
            var url = 'https://localhost:44361/api/Periods'

            fetch(url)
            .then(response => response.json())
            .then((data)=>{
                this.periods = data
                //console.log(data)
            })
        },
        deletePeriod(periodId){
            alert(periodId);
        },
        editPeriod(periodId){
            alert(periodId)
        }
    }
}
</script>