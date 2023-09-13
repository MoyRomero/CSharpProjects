const spanDiaDatos = document.querySelector("#HoraAutomatica span:nth-child(1)");
const spanAño = document.querySelector("#HoraAutomatica span:nth-child(2)");
const spanHora = document.querySelector("#HoraAutomatica span:nth-child(3)");
const spanMin = document.querySelector("#HoraAutomatica span:nth-child(4)");
const spanSec = document.querySelector("#HoraAutomatica span:nth-child(5)");

const Meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
const Dias = ["Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"];

setInterval(() => {    const tiempo = new Date();

    spanDiaDatos.textContent = `${Dias[tiempo.getDay()-1]} ${tiempo.getDate()} de ${Meses[tiempo.getMonth()]} del `;
    spanAño.textContent = tiempo.getFullYear();

    if (spanHora.textContent < 9 || spanHora.textContent > 23) {
        spanHora.textContent = "0" + tiempo.getHours();
    }
    else {
        spanHora.textContent = tiempo.getHours();
    }

    if (spanMin.textContent <= 9 || spanSec.textContent > 58) {
        spanMin.textContent = "0" + tiempo.getMinutes();
    }
    else {
        spanMin.textContent = tiempo.getMinutes();
    }

    if (spanSec.textContent < 9 || spanSec.textContent > 58) {
        spanSec.textContent = "0" + tiempo.getSeconds();
    }
    else {
        spanSec.textContent = tiempo.getSeconds();
    }
}, 1000);