using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.Entidades;
using TiendaBatarazo.Dominio.EntidadesTipadas;
using TiendaBatarazo.Dominio.InterfacesAD;
namespace TiendaBatarazo.AccesoDatos.Implementaciones
{
    public class UnidadTrabajoEF : IUnidadTrabajoEF
    {
        #region Atributos
        private readonly DbContext _context;
        private readonly IConfiguration _configuration;
        private IDbContextTransaction? _transaction;

        // Repositorios privados
        private RepositorioAD<TUsuario>? _TUsuario;
        private RepositorioAD<TProveedor>? _TProveedor;
        private RepositorioAD<TComic>? _TComic;
        private RepositorioAD<TVenta>? _TVenta;
        private RepositorioAD<TDetalleVenta>? _TDetalleVenta;
        private RepositorioAD<TProducto>? _TProducto;
        private RepositorioAD<TCategoria>? _TCategoria;
        private RepositorioAD<TCliente>? _TCliente;
        private RepositorioAD<TPedido>? _TPedido;
        private RepositorioAD<TDetallesPedido>? _TDetallesPedido;
        private RepositorioAD<TPedidoProveedor>? _TPedidoProveedor;
        private RepositorioAD<TPedidoLinea>? _TPedidoLinea;
        #endregion

        #region Constructor
        public UnidadTrabajoEF(DbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        #endregion

        #region Repositorios
        public IRepositorioAD<TUsuario> TUsuario => _TUsuario ??= new RepositorioAD<TUsuario>(_context);
        public IRepositorioAD<TProveedor> TProveedor => _TProveedor ??= new RepositorioAD<TProveedor>(_context);
        public IRepositorioAD<TComic> TComic => _TComic ??= new RepositorioAD<TComic>(_context);
        public IRepositorioAD<TVenta> TVenta => _TVenta ??= new RepositorioAD<TVenta>(_context);
        public IRepositorioAD<TDetalleVenta> TDetalleVenta => _TDetalleVenta ??= new RepositorioAD<TDetalleVenta>(_context);
        public IRepositorioAD<TProducto> TProducto => _TProducto ??= new RepositorioAD<TProducto>(_context);
        public IRepositorioAD<TCategoria> TCategoria => _TCategoria ??= new RepositorioAD<TCategoria>(_context);
        public IRepositorioAD<TCliente> TCliente => _TCliente ??= new RepositorioAD<TCliente>(_context);
        public IRepositorioAD<TPedido> TPedido => _TPedido ??= new RepositorioAD<TPedido>(_context);
        public IRepositorioAD<TDetallesPedido> TDetallesPedido => _TDetallesPedido ??= new RepositorioAD<TDetallesPedido>(_context);
        public IRepositorioAD<TPedidoProveedor> TPedidoProveedor => _TPedidoProveedor ??= new RepositorioAD<TPedidoProveedor>(_context);
        public IRepositorioAD<TPedidoLinea> TPedidoLinea => _TPedidoLinea ??= new RepositorioAD<TPedidoLinea>(_context);
        #endregion

        #region Métodos
        public int Completar()
        {
            return _context.SaveChanges();
        }

        public void EmpezarTransaccion()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CompletarTran()
        {
            try
            {
                _context.SaveChanges();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public void CerraConexion()
        {
            _context.Database.CloseConnection();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}

