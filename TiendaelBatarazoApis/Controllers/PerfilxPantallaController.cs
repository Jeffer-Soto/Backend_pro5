using Laboratorio.Dominio.EntidadesTipadas;
using Laboratorio.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PerfilxPantallaController : ControladorBaseController
    {
        private IConfiguration _configuracion { get; }

        public readonly IHttpContextAccessor _httpContextAccessor;

        private ILogger<PerfilxPantallaController> _logger { get; }

        private ISegPerfilXpantallaLN _perxpLN { get; }
        // GET: CategoriaController
        public PerfilxPantallaController(IConfiguration configuracion, IHttpContextAccessor httpContextAccessor, ILogger<PerfilxPantallaController> logger, ISegPerfilXpantallaLN PerxpLN)
        {
            _configuracion = configuracion;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _perxpLN = PerxpLN;
        }

        [HttpGet(), Route("lfListar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfListar()
        {
            try
            {
                var objRespuesta = this._perxpLN.Listar();

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
        public JsonResult lfObtener(TSegPerfilXpantalla segPerfilXpantalla)
        {
            try
            {
                var objRespuesta = this._perxpLN.Obtener(segPerfilXpantalla);

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
        public JsonResult lfBuscar(TSegPerfilXpantalla segPerfilXpantalla)
        {
            try
            {
                var objRespuesta = this._perxpLN.Buscar(segPerfilXpantalla);

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
        public JsonResult lfInsertar(TSegPerfilXpantalla segPerfilXpantalla)
        {
            try
            {
                var objRespuesta = this._perxpLN.Insertar(segPerfilXpantalla);

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
        public JsonResult lfModificar(TSegPerfilXpantalla segPerfilXpantalla)
        {
            try
            {
                var objRespuesta = this._perxpLN.Modificar(segPerfilXpantalla);

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
        public JsonResult lfEliminar(TSegPerfilXpantalla segPerfilXpantalla)
        {
            try
            {
                var objRespuesta = this._perxpLN.Eliminar(segPerfilXpantalla);

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