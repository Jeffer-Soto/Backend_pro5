using Laboratorio.Dominio.EntidadesTipadas;
using Laboratorio.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControladorBaseController
    {
        private IConfiguration _configuracion { get; }

        public readonly IHttpContextAccessor _httpContextAccessor;

        private ILogger<ProductoController> _logger { get; }

        private IProductoLN _proLN { get; }
        // GET: CategoriaController
        public ProductoController(IConfiguration configuracion, IHttpContextAccessor httpContextAccessor, ILogger<ProductoController> logger, IProductoLN ProLN)
        {
            _configuracion = configuracion;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _proLN = ProLN;
        }

        [HttpGet(), Route("lfListar"), ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult lfListar()
        {
            try
            {
                var objRespuesta = this._proLN.Listar();

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
        public JsonResult lfObtener(TProducto producto)
        {
            try
            {
                var objRespuesta = this._proLN.Obtener(producto);

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
        public JsonResult lfBuscar(TProducto producto)
        {
            try
            {
                var objRespuesta = this._proLN.Buscar(producto);

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
        public JsonResult lfInsertar(TProducto producto)
        {
            try
            {
                var objRespuesta = this._proLN.Insertar(producto);

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
        public JsonResult lfModificar(TProducto producto)
        {
            try
            {
                var objRespuesta = this._proLN.Modificar(producto);

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
        public JsonResult lfEliminar(TProducto producto)
        {
            try
            {
                var objRespuesta = this._proLN.Eliminar(producto);

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