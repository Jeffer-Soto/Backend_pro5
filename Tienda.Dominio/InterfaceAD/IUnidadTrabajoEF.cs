using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;

namespace TiendaBatarazo.Dominio.InterfacesAD
{
    public interface IUnidadTrabajoEF : IDisposable
    {
        IRepositorioAD<TUsuario> TUsuario { get; }
        IRepositorioAD<TProveedor> TProveedor { get; }
        IRepositorioAD<TComic> TComic { get; }
        IRepositorioAD<TVenta> TVenta { get; }
        IRepositorioAD<TDetalleVenta> TDetalleVenta { get; }
        IRepositorioAD<TPedidoProveedor> TPedidoProveedor { get; }
        IRepositorioAD<TPedidoLinea> TPedidoLinea { get; }
        IRepositorioAD<TCliente> TCliente { get; }
        IRepositorioAD<TCategoria> TCategoria { get; }
        IRepositorioAD<TProducto> TProducto { get; }
        IRepositorioAD<TPedido> TPedido { get; }
        IRepositorioAD<TDetallesPedido> TDetallesPedido { get; }

        int Completar();
        void EmpezarTransaccion();
        void CompletarTran();
        void Rollback();
        void CerraConexion();
    }
}