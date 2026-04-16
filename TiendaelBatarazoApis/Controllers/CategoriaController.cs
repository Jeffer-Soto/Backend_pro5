using Laboratorio.Dominio.EntidadesTipadas;
using Laboratorio.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : ControladorBaseController
    {
        private IConfiguration _configuracion { get; }

        public readonly IHttpContextAccessor _httpContextAccessor;

        private ILogger<CategoriaController> _logger { get; }

        private ICategoriumLN _catLN { get; }
        // GET: CategoriaController
        public CategoriaController(IConfiguration configuracion, IHttpContextAccessor httpContextAccessor, ILogger<CategoriaController> logger, ICategoriumLN CateLN)
        {
            _configuracion = configuracion;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _catLN = CateLN;
        }

        [HttpGet(), Route("lfListar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfListar()
        {
            try
            {
                var objRespuesta = this._catLN.Listar();

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

        [HttpGet(), Route("lfObtener"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfObtener(TCategorium categorium)
        {
            try
            {
                var objRespuesta = this._catLN.Obtener(categorium);

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

        [HttpGet(), Route("lfBuscar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfBuscar(TCategorium categorium)
        {
            try
            {
                var objRespuesta = this._catLN.Buscar(categorium);

                if (objRespuesta.blnIndicadorTransaccion)
                {
                    return lfManejarRespuesta(objRespuesta, objRespuesta);
                }
                else
                {
                    return lfManejarRespuesta(objRespuesta);
                }
            }
            catch (Exception ex)
            {
                return lfManejarException(ex);
            }
        }

        [HttpPost(), Route("lfInsertar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfInsertar(TCategorium categorium)
        {
            try
            {
                var objRespuesta = this._catLN.Insertar(categorium);

                if (objRespuesta.blnIndicadorTransaccion)
                {
                    return lfManejarRespuesta(objRespuesta, objRespuesta);
                }
                else
                {
                    return lfManejarRespuesta(objRespuesta);
                }
            }
            catch (Exception ex)
            {
                return lfManejarException(ex);
            }
        }

        [HttpPut(), Route("lfModificar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfModificar(TCategorium categorium)
        {
            try
            {
                var objRespuesta = this._catLN.Modificar(categorium);

                if (objRespuesta.blnIndicadorTransaccion)
                {
                    return lfManejarRespuesta(objRespuesta, objRespuesta);
                }
                else
                {
                    return lfManejarRespuesta(objRespuesta);
                }
            }
            catch (Exception ex)
            {
                return lfManejarException(ex);
            }
        }

        [HttpDelete(), Route("lfEliminar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfEliminar(TCategorium categorium)
        {
            try
            {
                var objRespuesta = this._catLN.Eliminar(categorium);

                if (objRespuesta.blnIndicadorTransaccion)
                {
                    return lfManejarRespuesta(objRespuesta, objRespuesta);
                }
                else
                {
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

