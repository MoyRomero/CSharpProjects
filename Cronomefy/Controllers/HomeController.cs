using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityModel.Client;
using Newtonsoft.Json;
using RestSharp;
using Cronomefy.Models;

namespace Cronomefy.Controllers
{

    public class HomeController : Controller
    {
        private const string ClientId = "02780f9add5e45f989fbbe94386d3994";
        private const string ClientSecret = "7d32052ef88e425aa3ba0e6b33df1a15";
        private const string RedirectUri = "https://localhost:44367";

        public ActionResult Index()
        {
            ViewBag.Title = "SPOMETER";

            return View();
        }

        public ActionResult Error(string DescripcionError)
        {
            ViewBag.Title = "Ocurrió un error: " + DescripcionError;

            return View();
        }

        public async Task<JsonResult> SpotifyCallback(string code)
        {
            try
            {
                // Verifica que se haya recibido el código de autorización
                if (string.IsNullOrEmpty(code))
                {
                    return Json("El parámetro 'code' está vacío.", JsonRequestBehavior.AllowGet);
                }

                // Crea una solicitud para obtener el token de acceso
                string Auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret));

                List<KeyValuePair<string, string>> argumentos = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                };


                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Auth}");
                    HttpContent content = new FormUrlEncodedContent(argumentos);

                    // Realiza una solicitud POST a la URL de token de Spotify
                    var response = await httpClient.PostAsync("https://accounts.spotify.com/api/token", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var tokenResponse = await response.Content.ReadAsStringAsync();

                        // Analiza la respuesta JSON para obtener el token de acceso
                        var tokenData = JsonConvert.DeserializeObject<TokenClass>(tokenResponse);

                        return Json(ObtenerCanciónActual(httpClient,tokenData),JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string errorMessage = $"Error al obtener el token. Status code: {response.StatusCode}";

                        // Maneja el error de forma adecuada, puedes registrar el error o devolver un mensaje de error
                        return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción no controlada
                return Json($"Error inesperado: {ex.Message}", JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> ObtenerCanciónActual(HttpClient httpClient,TokenClass TokenData)
        {
            // Configura un tiempo de espera de 30 segundos para el cliente HTTP
            // httpClient.Timeout = TimeSpan.FromSeconds(30);
            string urlCancionActual = "https://api.spotify.com/v1/me/player/currently-playing";

            try
            {
                var client = new RestClient();
                client.AddDefaultHeader("Authorization", $"Bearer {TokenData.access_token}");

                var request = new RestRequest("https://api.spotify.com/v1/artists/4Z8W4fKeB5YxbusRsdQVPb", Method.Get);

                var respuesta = client.Execute(request);

                if (respuesta.IsSuccessStatusCode)
                {
                    return Json(JsonConvert.DeserializeObject<Cancion>(respuesta.Content));
                }
                else
                {
                    return Json("Hubo un error en la respuesta.", JsonRequestBehavior.AllowGet);
                }

                //httpClient.DefaultRequestHeaders.Remove("Authorization");

                //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenData.access_token}");

                //var respuesta = await httpClient.GetAsync(urlCancionActual);

                //var ContenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

                //return Json(JsonConvert.DeserializeObject<Cancion>(ContenidoRespuesta), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error al adquirir la canción actual: "+ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}





//var tokenRequest = new Dictionary<string, string>
//{
//    { "code", code },
//    { "grant_type", "authorization_code" },
//    { "redirect_uri", RedirectUri },
//    { "client_id", ClientId },
//    { "client_secret", ClientSecret }
//};

