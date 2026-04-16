using Laboratorio.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.API.Controllers
{
    public class ControladorBaseController : Controller
    {
        private JsonResult lfFormatearExceptionJson(string strMensaje, System.Net.HttpStatusCode intEstado, string faltante = "")
        {
            Response.StatusCode = (int)intEstado;
            return Json(new { message = strMensaje, bFaltante = faltante });
        }

        private JsonResult lfFormatearExceptionJson(string strMensaje, byte enuTipoMensaje, System.Net.HttpStatusCode intEstado, string faltante = "")
        {
            Response.StatusCode = (int)intEstado;
            return Json(new { message = strMensaje, type = enuTipoMensaje, bFaltante = faltante });
        }

        private JsonResult lfFormatearExceptionJson(string strTitulo, string strMensaje, byte enuTipoMensaje, System.Net.HttpStatusCode intEstado, string faltante = "")
        {
            Response.StatusCode = (int)intEstado;
            return Json(new { title = strTitulo, message = strMensaje, type = enuTipoMensaje, bFaltante = faltante });
        }

        private JsonResult lfFormatearExceptionJson(string strTitulo, string strMensaje, byte enuTipoMensaje, object objeto, System.Net.HttpStatusCode intEstado, string cantidad = "", string faltante = "")
        {
            Response.StatusCode = (int)intEstado;
            return Json(new { title = strTitulo, message = strMensaje, data = objeto, type = enuTipoMensaje, xCantidadItems = cantidad, bFaltante = faltante });

        }
        [NonAction]
        public JsonResult lfManejarMensaje(string strMensaje)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strMensaje, System.Net.HttpStatusCode.InternalServerError);
        }
        [NonAction]
        public JsonResult lfManejarMensaje(string strMensaje, byte enuTipoMensaje)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strMensaje, enuTipoMensaje, System.Net.HttpStatusCode.InternalServerError);
        }
        [NonAction]
        public JsonResult lfManejarMensaje(string strTitulo, string strMensaje, byte enuTipoMensaje)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strTitulo, strMensaje, enuTipoMensaje, System.Net.HttpStatusCode.InternalServerError);
        }
        [NonAction]
        public JsonResult lfManejarValidacion(string strTitulo, string strMensaje)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strTitulo, strMensaje, (byte)Enumeradores.eTipoMensaje.Validacion, System.Net.HttpStatusCode.BadRequest);
        }
        [NonAction]
        public JsonResult lfManejarValidacion(string strTitulo, string strMensaje, object objeto)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strTitulo, strMensaje, (byte)Enumeradores.eTipoMensaje.Validacion, objeto, System.Net.HttpStatusCode.BadRequest);
        }
        [NonAction]
        public JsonResult lfManejarError(string strTitulo, string strMensaje)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strTitulo, strMensaje, (byte)Enumeradores.eTipoMensaje.Error, System.Net.HttpStatusCode.InternalServerError);
        }
        [NonAction]
        public JsonResult lfManejarError(string strTitulo, string strMensaje, object objeto)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(strTitulo, strMensaje, (byte)Enumeradores.eTipoMensaje.Error, objeto, System.Net.HttpStatusCode.InternalServerError);
        }
        [NonAction]
        public JsonResult lfManejarException(Exception ex)
        {
            //llamar utilidad para logging
            return lfFormatearExceptionJson(ex.Message, (byte)Enumeradores.eTipoMensaje.Error, System.Net.HttpStatusCode.InternalServerError);
        }
        [NonAction]
        public JsonResult lfManejarRespuesta<T>(Respuesta<T> respuesta)
        {
            System.Net.HttpStatusCode intEstado;
            switch (respuesta.enuTipoMensaje)
            {
                case (byte)Enumeradores.eTipoMensaje.Satisfactorio:

                case (byte)Enumeradores.eTipoMensaje.Informativo:
                    intEstado = System.Net.HttpStatusCode.OK;
                    break;

                case (byte)Enumeradores.eTipoMensaje.Validacion:
                    intEstado = System.Net.HttpStatusCode.BadRequest;
                    break;

                case (byte)Enumeradores.eTipoMensaje.Error:
                    intEstado = System.Net.HttpStatusCode.InternalServerError;
                    break;
                default:
                    intEstado = System.Net.HttpStatusCode.OK;
                    break;
            }

            //llamar utilidad para logging
            return lfFormatearExceptionJson(respuesta.strTituloRespuesta, respuesta.strMensajeRespuesta, respuesta.enuTipoMensaje, respuesta.ValorRetorno, intEstado, respuesta.xCantidadItems, respuesta.bfaltante);
        }
        [NonAction]
        public JsonResult lfManejarRespuesta<T>(Respuesta<T> respuesta, object objeto)
        {
            System.Net.HttpStatusCode intEstado;
            switch (respuesta.enuTipoMensaje)
            {
                case (byte)Enumeradores.eTipoMensaje.Satisfactorio:

                case (byte)Enumeradores.eTipoMensaje.Informativo:
                    intEstado = System.Net.HttpStatusCode.OK;
                    break;

                case (byte)Enumeradores.eTipoMensaje.Validacion:
                    intEstado = System.Net.HttpStatusCode.BadRequest;
                    break;

                case (byte)Enumeradores.eTipoMensaje.Error:
                    intEstado = System.Net.HttpStatusCode.InternalServerError;
                    break;

                default:
                    intEstado = System.Net.HttpStatusCode.OK;
                    break;
            }

            //llamar utilidad para logging
            return lfFormatearExceptionJson(respuesta.strTituloRespuesta, respuesta.strMensajeRespuesta, respuesta.enuTipoMensaje, objeto, intEstado, respuesta.xCantidadItems, respuesta.bfaltante);
        }
    }
}

