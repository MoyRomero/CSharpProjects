window.onload = () => EnviarDatosTabla();

const EnviarDatosTabla = () => {

    GenerarTabla({
        url: "TipoHabitacion/Get",
        idTabla: "divTabla",
        cabeceras: ["ID", "NOMBRE", "DESCRIPCIÓN"],
        propiedades: ["Id", "Nombre", "Descripcion"]
    });
}


const FiltradoSensitivo = () => {
    const TxtBoxTipoHabitacion = document.getElementById("TxtBoxTipoHabitacion");

    let texto = TxtBoxTipoHabitacion.value;
    //console.log("KeyUp: " + texto);

    GenerarTabla({
        url: `TipoHabitacion/SensitiveGet?texto=${texto}`,
        idTabla: "divTabla",
        cabeceras: ["ID", "NOMBRE", "DESCRIPCIÓN"],
        propiedades: ["Id", "Nombre", "Descripcion"]
    });
}

TxtBoxTipoHabitacion.onkeyup = (e) => FiltradoSensitivo();


