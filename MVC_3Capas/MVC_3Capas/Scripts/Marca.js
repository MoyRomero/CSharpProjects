window.onload = () => EnviarDatosTabla();

const EnviarDatosTabla = () => {

    GenerarTabla({
        url: "Marca/Get",
        idTabla: "divTabla",
        cabeceras: ["ID", "NOMBRE", "DESCRIPCIÓN"],
        propiedades: ["Id", "Nombre", "Descripcion"]
    });
}