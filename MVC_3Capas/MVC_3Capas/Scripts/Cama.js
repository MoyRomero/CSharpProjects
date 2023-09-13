window.onload = () => EnviarDatosTabla();

const EnviarDatosTabla = () => {

    GenerarTabla({
        url: "Cama/Get",
        idTabla: "divTabla",
        cabeceras: ["ID", "NOMBRE", "DESCRIPCIÓN"],
        propiedades: ["Id", "Nombre", "Descripcion"]
    });
}