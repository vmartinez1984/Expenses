var listSubcategories = new Array();

function loadLisSubcateries(){
    var categoryId;

    categoryId = document.getElementById("CategoryId").value;
    if(categoryId != ''){
        var url;

        url = "http://www.vmartinez84.somee.com/Subcategories/Get/"+categoryId;
        url = "/Subcategories/Get/"+categoryId;
        console.log(url);
        fetch(url).
        then( response =>{
            if (response.ok) {
            return response.json();
        } else {
            throw response.error;
        }
    })
    .then(data => {
        //console.log(data);
        var option;

        document.getElementById("SubcategoryId").innerHTML = '';
        listSubcategories = [];
        if(data.length > 1){
            option = document.createElement("option");
            option.text = "Seleccione";
            option.value ="";
            document.getElementById("SubcategoryId").append(option);
        }
        data.forEach(item =>{
            option = document.createElement("option");
            option.text = item.name;
            option.value = item.id;
            document.getElementById("SubcategoryId").append(option);
            listSubcategories.push(item);
            //console.log(item);
        });
    })
    .catch(error => {
        console.log(error);
    });
    }
}

function loadSubcategory(){
    var value;

    value =  document.getElementById("SubcategoryId").value;
    if(value != ''){
        var item;
        
        item = listSubcategories.find(x=> x.id == value);
        document.getElementById("Amount").value = item.amount;
        document.getElementById("Name").value = item.name;
        document.getElementById("Name").focus();
    }
}