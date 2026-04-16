using Laboratorio.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoCedulaController : ControladorBaseController
    {
        private IConfiguration _configuracion { get; }

        public readonly IHttpContextAccessor _httpContextAccessor;

        private ILogger<TipoCedulaController> _logger { get; }

        private ITipoCedulaLN _tipLN { get; }
        // GET: CategoriaController
        public TipoCedulaController(IConfiguration configuracion, IHttpContextAccessor httpContextAccessor, ILogger<TipoCedulaController> logger, ITipoCedulaLN TipLN)
        {
            _configuracion = configuracion;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _tipLN = TipLN;
        }

        [HttpGet(), Route("lfListar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfListar()
        {
            try
            {
                var objRespuesta = this._tipLN.Listar();

                if (objRespuesta.blnIndicadorTransaccion)
                {
                    // En caso encontrar resultados, se obtienen y se construye el objeto Json
                    return lfManejarRespuesta(objRespuesta, objRespuesta);
                }
                else
                {
                    // En caso de no existir registros, se retorma el mensaje
                    return lfManejarRespuesta(objRespuesta);
                }
            }
            catch (Exception ex)
            {
                return lfManejarException(ex);
            }
        }
    }
}

