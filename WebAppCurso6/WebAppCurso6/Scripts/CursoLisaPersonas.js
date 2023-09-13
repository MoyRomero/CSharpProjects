
    $.get("Curso/ListaPersonas", (data) => {

        let ListaNombres = [];
        let ListaApellidos = [];

        for (let i = 0; i < data.length; i++) {

            ListaNombres.push(JSON.stringify(data[i].Nombre));
            console.log(ListaNombres);

            ListaApellidos.push(JSON.stringify(data[i].Apellido));
            console.log(ListaApellidos);
        }
        alert("Nombres: " + ListaNombres + "Apellidos:" + ListaApellidos);
    });