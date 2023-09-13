//Ten en cuenta que este método funcionará en navegadores modernos,
//    pero puede no ser compatible con navegadores más antiguos.
//    Si necesitas admitir navegadores más antiguos, es posible que debas utilizar otras técnicas,
//    como el análisis manual de window.location.search.

const urlActual = new URL(window.location.href);

const code = urlActual.searchParams.get("code");

window.onload = () => {

    if (code == null || code == "") {        
        SetUrl();
        return;
    }
    ObtenerToken();  
}

const SetUrl = () => {
    const LinkObtenerCodigo = document.getElementById("LinkObtenerCodigo");

    const Datos =
    {
        url: "https://accounts.spotify.com/authorize",
        client_id: "02780f9add5e45f989fbbe94386d3994",
        response_type: "code",
        redirect_uri: "https://localhost:44367"
    }
    const urlSpotify = `${Datos.url}?client_id=${Datos.client_id}&response_type=${Datos.response_type}&redirect_uri=${Datos.redirect_uri}`;

    LinkObtenerCodigo.setAttribute("href", urlSpotify);   
}

const ObtenerToken = () => {

    const urlFetch = "/Home/SpotifyCallback?code=" + code;

    fetch(urlFetch)
        .then(response => {
            // Verificar si la respuesta tiene un estado exitoso (código 200)
            if (response.status === 200) {
                return response.json(); // Parsear la respuesta como JSON
            } else {
                throw new Error('Error en la solicitud');
            }
        })
        .then(data => {
            // Manipular los datos recibidos en la respuesta
            console.log(data.Result.Data);
            // Haz algo con los datos aquí
        })
        .catch(error => {
            // Manejar errores en la solicitud
            console.error('Error en la solicitud:', error);
            console.log(error);
        });
}