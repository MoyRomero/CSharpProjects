const GenerarTabla = (ObjetoDatosTabla) => {

    const divTabla = document.getElementById(ObjetoDatosTabla.idTabla);
    const Raiz = document.getElementById("Raiz");
    
    let url = ObjetoDatosTabla.url;
    let urlAbsoluta = `${window.location.protocol}//${window.location.host}${Raiz.textContent}${ObjetoDatosTabla.url}`;

    console.log(urlAbsoluta);

    let contenido =
        `<table class="table">
            <thead>
                <tr>`;

    for (let i = 0; i < ObjetoDatosTabla.cabeceras.length; i++) {
        contenido += `<th>${ObjetoDatosTabla.cabeceras[i]}</th>`;
    }

    contenido += `
                </tr>
            </thead>
            <tbody>`;

    fetch(urlAbsoluta)
        .then(data => data.json())
        .then(data => {

            //console.log(data);

            for (let i = 0; i < data.length; i++) {

                let fila = data[i];               

                //Ejemplo del acceso a los datos de un objeto
                //console.log(fila["Id"]);
                //console.log(fila["Nombre"]);
                //console.log(fila["Descripcion"]);

                contenido += `<tr>`;

                    for (let j = 0; j < ObjetoDatosTabla.propiedades.length; j++) {
                        let propiedad = ObjetoDatosTabla.propiedades[j];
                        contenido += `<td>${fila[propiedad]}</td>`;
                    }                               
                    
                contenido += `</tr>`;
            }

            contenido += `</tbody>
                    </table>`;

            divTabla.innerHTML = contenido;
        });
}