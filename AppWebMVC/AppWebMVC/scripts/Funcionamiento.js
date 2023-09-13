const btnMenu = document.querySelector("#btnMenu");
const NavMenu = document.querySelector("#nav");
const BotonesNav = document.querySelectorAll("#nav a");
const formAgregar = document.getElementById("formAgreg");
const formEditar = document.getElementById("formEdit");
const dialogoAgregar = document.getElementById("AgregarDialogo");
const dialogoEditar = document.getElementById("EditarDialogo");
const dialogoEliminar = document.getElementById("EliminarDialogo");
//FILTRADO SENSITIVO
const FiltradoSensitivo = document.getElementById("NOMBRE");
const formBSensitivo = document.getElementById("formBSensitivo");
//FILTRADO DROPTBOX
const drpDownS = document.getElementById("IDSexo");
//FILTRADO DROPTBOX (SENSITIVO)
const drpDownTU = document.getElementById("IDTipoDeUsuario");
//MULTIPLE FILTRADO
const formTipoUsuario = document.getElementById("formTipoUsuario");


let Oculto = false;
let decision = false;

AccionAncho();

//MULTIPLE FILTRADO
function Limpiar() {

    if (formTipoUsuario != null) {

        event.preventDefault();

        IDTipoUsuario.value = "";
        NOMBRE.value = "";
        Descripcion.value = "";

        formTipoUsuario.submit();
    }
}

//FILTRADO DROPTBOX (SENSITIVO)
if (drpDownTU != null) filtradoSensDropDown();
function filtradoSensDropDown() {

    drpDownTU.onchange = () => formSensCombBx.submit();

    drpDownTU.options[0].style.display = "none";

    if (drpDownTU.options[0].style.display == "none" && drpDownTU.options[1].selected == true) drpDownTU.options[0].selected = true;
}

//FILTRADO DROPTBOX
if (drpDownS != null) filtradoDropS();
function filtradoDropS() {

    drpDownS.options[0].style.display = "none";

    if (drpDownS.options[2].selected == true || drpDownS.options[3].selected == true) drpDownS.options[1].display = "block";

    if (drpDownS.options[0].style.display == "none" && drpDownS.options[1].selected == true) drpDownS.options[0].selected = true;
}

//FILTRADO SENSITIVO
if (FiltradoSensitivo != null && formBSensitivo != null) FiltradoSensitivo.onkeyup = () => formBSensitivo.submit();

function EliminarPopUp(id) {

    dialogoEliminar.showModal();
    document.getElementById("idElemento").value = id;
}

function Eliminar() {

    let frmEliminar = document.getElementById("frmEliminar");

    frmEliminar.submit();

}

function OkDialogo() {
    if (formAgregar != null) formAgregar.submit();
    if (formEditar != null) formEditar.submit();
}

function CancelarDialogo() {
    if (dialogoAgregar != null) dialogoAgregar.close();
    if (dialogoEditar != null) dialogoEditar.close();
    if (dialogoEliminar != null) dialogoEliminar.close();
}

function AccionAncho() {
    if (this.window.innerWidth <= 850) Ocultar();

    window.addEventListener("resize", MedirAncho);

    btnMenu.addEventListener("click", OcultarMostrar);
}

function MedirAncho() {

    console.log(this.window.innerWidth)

    if (this.window.innerWidth <= 850) {

        Ocultar();
        btnMenu.style.display = "block";
    }

    else if (this.window.innerWidth > 850) {

        Mostrar();
        btnMenu.style.display = "none";
    }
}

function Ocultar() {
    NavMenu.style.height = "10vh";

    BotonesNav.forEach(boton => {
        boton.style.display = "none";
    });

    btnMenu.style.display = "block";

    Oculto = true;
}

function Mostrar() {
    NavMenu.style.height = "auto";

    BotonesNav.forEach(boton => {
        boton.style.display = "block";
    });

    Oculto = false;
}

function OcultarMostrar() {
    if (Oculto == false) {
        Ocultar()
    }
    else {
        Mostrar()
    }
    console.log("Se ajustó el tamaño.");
}

if (formAgregar != null) {

    formAgregar.onsubmit = function (e) {

        e.preventDefault();

        dialogoAgregar.showModal();
    }
}

if (formEditar != null) {

    formEditar.onsubmit = function (e) {

        e.preventDefault();

        dialogoEditar.showModal();
    }
}