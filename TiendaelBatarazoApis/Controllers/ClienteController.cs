using Laboratorio.Dominio.EntidadesTipadas;
using Laboratorio.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControladorBaseController
    {
        private IConfiguration _configuracion { get; }

        public readonly IHttpContextAccessor _httpContextAccessor;

        private ILogger<CategoriaController> _logger { get; }

        private IClienteLN _cliLN { get; }
        // GET: CategoriaController
        public ClienteController(IConfiguration configuracion, IHttpContextAccessor httpContextAccessor, ILogger<CategoriaController> logger, IClienteLN CliLN)
        {
            _configuracion = configuracion;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _cliLN = CliLN;
        }
        [HttpGet(), Route("lfListar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfListar()
        {
            try
            {
                var objRespuesta = this._cliLN.Listar();

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
        public JsonResult lfObtener(TCliente cliente)
        {
            try
            {
                var objRespuesta = this._cliLN.Obtener(cliente);

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
        public JsonResult lfBuscar(TCliente cliente)
        {
            try
            {
                var objRespuesta = this._cliLN.Buscar(cliente);

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
        public JsonResult lfInsertar(TCliente cliente)
        {
            try
            {
                var objRespuesta = this._cliLN.Insertar(cliente);

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
        public JsonResult lfModificar(TCliente cliente)
        {
            try
            {
                var objRespuesta = this._cliLN.Modificar(cliente);

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
        public JsonResult lfEliminar(TCliente cliente)
        {
            try
            {
                var objRespuesta = this._cliLN.Eliminar(cliente);

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


