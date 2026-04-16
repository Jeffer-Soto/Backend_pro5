using Laboratorio.Dominio.EntidadesTipadas;
using Laboratorio.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PerfilController : ControladorBaseController
    {
        private IConfiguration _configuracion { get; }

        public readonly IHttpContextAccessor _httpContextAccessor;

        private ILogger<PerfilController> _logger { get; }

        private ISegPerfilLN _perLN { get; }
        // GET: CategoriaController
        public PerfilController(IConfiguration configuracion, IHttpContextAccessor httpContextAccessor, ILogger<PerfilController> logger, ISegPerfilLN PerLN)
        {
            _configuracion = configuracion;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _perLN = PerLN;
        }

        [HttpGet(), Route("lfListar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfListar()
        {
            try
            {
                var objRespuesta = this._perLN.Listar();

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
        public JsonResult lfObtener(TSegPerfil perfil)
        {
            try
            {
                var objRespuesta = this._perLN.Obtener(perfil);

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
        public JsonResult lfBuscar(TSegPerfil perfil)
        {
            try
            {
                var objRespuesta = this._perLN.Buscar(perfil);

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
        public JsonResult lfInsertar(TSegPerfil perfil)
        {
            try
            {
                var objRespuesta = this._perLN.Insertar(perfil);

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
        public JsonResult lfModificar(TSegPerfil perfil)
        {
            try
            {
                var objRespuesta = this._perLN.Modificar(perfil);

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
        public JsonResult lfEliminar(TSegPerfil perfil)
        {
            try
            {
                var objRespuesta = this._perLN.Eliminar(perfil);

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