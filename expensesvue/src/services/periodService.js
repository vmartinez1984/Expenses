import urlBase from '@/services/url'

export default {

    async getAllPeriodsAsycn(){
        var response
        var url = urlBase.API + 'periods'
        var data
        //console.log(url)

        response =  await fetch(url)
        //console.log(response)
        if(!response.ok){
            throw new Error(response.data)
        }
        data = await response.json()
        //console.log(data)

        return data
    },
    async getPeriodAsync(periodId){
        var response
        var url = urlBase.API + 'periods/'+periodId
        var data

        response =  await fetch(url)
        //console.log(response)
        if(!response.ok){
            throw new Error(response.data)
        }
        data = await response.json()
        //console.log(data)

        return data
    }
}