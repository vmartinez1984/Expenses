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
                <form v-on:submit.prevent="savePeriod">
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Periodo</h1>
                            <!-- <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button> -->
                        </div>
                        <div class="modal-body">

                                <input type="text" class="form-control" v-model="period.id"/>
                                <div class="form-group">
                                    <label for="nombre">Nombre</label>
                                    <input type="text" class="form-control" v-model="period.name"/>
                                </div>

                                <div class="form-group">
                                    <label for="nombre">Fecha de inicio</label>
                                    <input type="date" class="form-control" v-model="period.dateStart"/>
                                </div>

                                <div class="form-group">
                                    <label for="nombre">Fecha de inicio</label>
                                    <input type="date" class="form-control" v-model="period.dateStop"/>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="reset" class="btn btn-secondary" data-bs-dismiss="modal" v-on:click="resetPeriod">Cerrar</button>
                                <button type="submit" class="btn btn-primary">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>

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
                                <button type="button" class="btn btn-warning text-white" data-bs-toggle="modal" data-bs-target="#exampleModal" v-on:click="editPeriod(period)">
                                    Editar
                                </button>
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
            periods:[],
            period:{}
        }
    },
    created: function(){
        this.getPeriods()
        this.period.id= 0
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
        editPeriod(period){
            this.period = period
            this.period.dateStart = period.dateStart.substring(0,10)
            this.period.dateStop = period.dateStop.substring(0,10)
        },
        resetPeriod(){
            this.period.id = 0
            this.period.name = ""
        },
        savePeriod(){
            console.log(this.period)
            if(this.period.id == 0){
                this.addPeriod(this.period)
            }else{
                this.updatePeriod(this.period)
            }
        },
        addPeriod(period){
            var url = 'https://localhost:44361/api/Periods'
            var periodSend = {
                name : period.name,
                dateStart: period.dateStart,
                dateStop: period.dateStop,
            }
            fetch(url,{
                method:'POST',
                body: JSON.stringify(periodSend),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
            .then(response=> response.json())
            .then(data=>{
                console.log(data)
                this.getPeriods()
            })
            .catch(console.log)
        },
        updatePeriod(period){
            console.log(period)
        }
    }
}
</script>