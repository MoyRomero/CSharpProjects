const IdAlumno = document.getElementById("IdAlumno");
const FechaNacimientoAlumno = document.getElementById("FechaNacimientoAlumno");
const SexoAlumno = document.getElementById("SexoAlumno");
const TelefonoPadreAlumno = document.getElementById("TelefonoPadreAlumno");
const TelefonoMadreAlumno = document.getElementById("TelefonoMadreAlumno");
const UsuarioAlumno = document.getElementById("UsuarioAlumno");
const inputsdivSelect = document.querySelectorAll("#DatosAlumnosRO input");
const imgDatosContainer = document.getElementById("imgDatosContainer");
const ErrorEliminarAlumno = document.getElementById("ErrorEliminarAlumno");

const selectAlumnos = document.getElementById("selectNombres");
let vacio = "";
let OptionsAlumnos;
let CRUD;

//Modales
const ModalAgregar = document.querySelector("#ModalAgregar");
////////////////////////////


//Formulario: Agregar / editar
const ErroresDiv = document.getElementById("ErroresDiv");
const NombredtoAlumno = document.getElementById("NombredtoAlumno");
const ApellidoPdtoAlumno = document.getElementById("ApellidoPdtoAlumno");
const ApellidoMdtoAlumno = document.getElementById("ApellidoMdtoAlumno");
const FNdtoAlumno = document.getElementById("FNdtoAlumno");
const idSexodtoAlumno = document.getElementById("idSexodtoAlumno");
const TelPadtoAlumno = document.getElementById("TelPadtoAlumno");
const TelMadtoAlumno = document.getElementById("TelMadtoAlumno");
const NumHermanos = document.getElementById("NumHermanos");
const UsuariodtoAlumno = document.getElementById("UsuariodtoAlumno");
const imgContainer = document.getElementById("imgContainer");
const FotoInput = document.getElementById("FotoInput");

///////////////////////////
selectAlumnos.onchange = () => GetAlumnoById(selectAlumnos.value, null);

FotoInput.onchange = () => {
    const lector = new FileReader();
    const fotoCargada = FotoInput.files[0];
    
    lector.onloadend = () => imgContainer.src = lector.result;
    lector.readAsDataURL(fotoCargada);
}

//FUNCION PARA RELLENAR SELECT DE ALUMNOS
const ListarSelectAlumnos = () => {

    $.get("Alumno/Get", (data) => {
        
        OptionsAlumnos += `<option id="SeleccioneAlumno" value=" " style="display:none" >Buscar Alumno</option>`;

        for (i = 0; i < data.length; i++) {
            OptionsAlumnos +=
                `<option value = "${data[i].Id}">
            ${data[i].Nombre} ${data[i].ApPaterno} ${data[i].ApMaterno}
            </option>`;

            selectAlumnos.innerHTML = OptionsAlumnos;
        }
    });

}; ListarSelectAlumnos();

const formatearFecha = () => {
    var fecha = new Date(FNdtoAlumno.value)
    var dia = fecha.getDate();
    var mes = fecha.getMonth() + 1;
    var año = fecha.getFullYear();

    if (dia < 10) dia = "0" + dia;

    if (mes < 10) mes = "0" + mes;

    return `${dia}/${mes}/${año}`;
}

const Enviar = () => {

    var formDatos = new FormData();

    formDatos.append('Nombre', NombredtoAlumno.value);
    formDatos.append('ApPaterno', ApellidoPdtoAlumno.value);
    formDatos.append('ApMaterno', ApellidoMdtoAlumno.value);
    formDatos.append('FechaNacimiento', formatearFecha());
    formDatos.append('SexoId', idSexodtoAlumno.value);
    formDatos.append('TelefonoPadre', TelPadtoAlumno.value);
    formDatos.append('TelefonoMadre', TelMadtoAlumno.value);
    formDatos.append('NumeroHermanos', NumHermanos.value);
    formDatos.append('FotoNombre', FotoInput.files[0].name);
    formDatos.append('Foto', FotoInput.files[0]);

    var alumno = {
        Nombre: NombredtoAlumno.value,
        ApPaterno: ApellidoPdtoAlumno.value,
        ApMaterno: ApellidoMdtoAlumno.value,
        FechaNacimiento: FNdtoAlumno.value,
        SexoId: idSexodtoAlumno.value,
        TelefonoPadre: TelPadtoAlumno.value,
        TelefonoMadre: TelMadtoAlumno.value,
        NumeroHermanos: NumHermanos.value,
        FotoNombre: FotoInput.files[0].name,
        file: FotoInput.files[0]
    };

    //CONDICION PARA AGREGAR
    if (CRUD == 1) {

        $.ajax({
            url: '/Alumno/Post',
            type: 'POST',
            processData: false,
            contentType: false,
            data: formDatos,
            success: function (responses) {
                // Manejar la respuesta del controlador

                ErroresDiv.innerHTML = responses[0];

                if (ErroresDiv.innerHTML != "") {
                    alert(responses[1]);
                    console.log(responses[1]);
                }
                else {
                    alert(responses[2]);
                    location.reload();
                    console.log(responses[2]);
                }
            },
            error: function (error) {
                // Manejar errores de la solicitud
                ErroresDiv.innerHTML = error.responseText;
                console.log(error + 0);
            }
        });
    }

    //CONDICION PARA EDITAR
    if (CRUD == 2) {

        $.ajax({
            url: '/Alumno/Put/' + IdAlumno.value,
            type: 'POST',
            processData: false,
            contentType: false,
            data: formDatos,
            success: function (responses) {
                // Manejar la respuesta del controlador

                ErroresDiv.innerHTML = responses[0];

                if (ErroresDiv.innerHTML != "") {
                    alert(responses[1]);
                    console.log(responses[1]);
                }
                else {
                    alert(responses[2]);
                    location.reload();
                    console.log(responses[2]);
                }
            },
            error: function (error) {
                // Manejar errores de la solicitud
                ErroresDiv.innerHTML = error.responseText;
                console.log(error + 0);
            }
        });

        //$.ajax({
        //    url: '/Alumno/Put/?id=' + IdAlumno.value,
        //    type: 'POST',
        //    contentType: 'application/json',
        //    data: JSON.stringify(alumno),
        //    success: function (responses) {
        //        // Manejar la respuesta del controlador

        //        ErroresDiv.innerHTML = responses[0];

        //        if (ErroresDiv.innerHTML != "") {
        //            alert(responses[1]);
        //            console.log(responses[1]);
        //        }
        //        else {
        //            alert(responses[2]);
        //            ModalAgregar.close();
        //            console.log(responses[2]);
        //        }
        //    },
        //    error: function (error) {
        //        // Manejar errores de la solicitud
        //        ErroresDiv.innerHTML = error.responseText;
        //        console.log(error[0]);
        //    }
        //});
    }
    //if (CRUD == 2) {

    //    fetch('/Alumno/Put/' + IdAlumno.value, {
    //        method: 'POST',
    //        headers: {
    //            'Content-Type': 'application/json'
    //        },
    //        body: JSON.stringify(alumno)
    //    })
    //        .then(response => response.json())
    //        .then(data => {
    //            // Manejar la respuesta del controlador
    //            console.log(data[1]);
    //        })
    //        .catch(error => {
    //            // Manejar errores de la solicitud
    //            console.log(error[0]);
    //        });        
    //}

    //fetch('Alumno/Post', {
    //    method: 'POST',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    body: JSON.stringify(alumno)
    //})
    //.then(response => response.json())
    //.then(data => {
    //    // Manejar la respuesta del controlador
    //    console.log(data);
    //})
    //.catch(error => {
    //    // Manejar errores de la solicitud
    //    console.log(error);
    //});
};

const Eliminar = () => {

    let id = IdAlumno.value;

    console.log(id);

    if (id == null || id == undefined || id == "") {
        alert("Debe seleccionar un alumno, antes de proceder a eliminar.");
        return;
    }
    
    if (confirm(`¿Desea eliminar el/la alumno(a) con el id ${id}?`) == true) { 

        var formDatos = new FormData();

        formDatos.append('Id', id);

        $.ajax({
            url: '/Alumno/Delete',
            type: 'POST',
            processData: false,
            contentType: false,
            data: formDatos,
            success: function (response) {

                // Manejar la respuesta del controlador 
                alert(response);
                location.reload();
                console.log(response);
            },
            error: function (error) {
                // Manejar errores de la solicitud
                alert(error);
                console.log(error);
            }
        });
    }
};

const GetAlumnoById = (id,accion) => {

    if (accion == null) { //Rellena el formulario de solo lectura 

        $.get("Alumno/GetId?id=" + id, (data) => {
            IdAlumno.value = data.Id;
            FechaNacimientoAlumno.value = data.FechaNacimiento;
            SexoAlumno.value = data.SexoId;
            TelefonoPadreAlumno.value = data.TelefonoPadre;
            TelefonoMadreAlumno.value = data.TelefonoMadre;
            UsuarioAlumno.value = data.bTieneUsuario;
            imgDatosContainer.src = srcImagenes(data.Extension, data.CadenaDeFoto);

            let nombreAlumnoReproduccion =
                `Se recuperó la información del Alumno ${data.Nombre} ${data.ApPaterno} ${data.ApMaterno}`;

            ReproducirTexto(nombreAlumnoReproduccion);
        });
    }

    if (accion == 2) {//Rellena el formulario para su edicion.

        $.get("Alumno/GetId?id=" + id, (data) => {

            NombredtoAlumno.value = data.Nombre;
            ApellidoPdtoAlumno.value = data.ApPaterno;
            ApellidoMdtoAlumno.value = data.ApMaterno;
            FNdtoAlumno.value = data.FechaNacimiento;
            idSexodtoAlumno.value = data.SexoId;
            TelPadtoAlumno.value = data.TelefonoPadre;
            TelMadtoAlumno.value = data.TelefonoMadre;
            UsuariodtoAlumno.value = data.bTieneUsuario;
            NumHermanos.value = data.NumeroHermanos;
            imgContainer.src = srcImagenes(data.Extension, data.CadenaDeFoto);
        });       
    }
};

const srcImagenes = (Extension, CadenaFoto) => {

    const SinFoto = "https://i.pinimg.com/280x280_RS/42/03/a5/4203a57a78f6f1b1cc8ce5750f614656.jpg";
    const FotoBD = `data:image/${Extension};base64,${CadenaFoto}`;
    CadenaFoto = CadenaFoto == "AA==" ? SinFoto : FotoBD;
    return CadenaFoto;          
};

const cerrarModal = () => {

    ModalAgregar.close();

    let inputsModal = document.querySelectorAll("#ModalAgregar input");

    ErroresDiv.innerHTML = "";

    inputsModal.forEach(input => {
        input.value = "";
    });
};

const AbrirModal = (accion) => {

    if (accion == 1) {
        ModalAgregar.showModal();
        CRUD = 1;
        console.log(CRUD);
    }

    if (accion == 2) {

        if (IdAlumno.value == "" || IdAlumno.value == null || IdAlumno.value == undefined) {
            alert("Debe seleccionar un alumno, antes de proceder a editar su informacion.");
            return;
        }

        ModalAgregar.showModal();
        let id = IdAlumno.value;
        CRUD = 2;
        console.log(CRUD);
        GetAlumnoById(id,2);
    }      
};

const vaciarSelect = () => {
    selectAlumnos.innerHTML = vacio;
};

const ReproducirTexto = (texto) => {
    var voz = new SpeechSynthesisUtterance(texto);

    window.speechSynthesis.speak(voz);
}


