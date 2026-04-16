using Microsoft.EntityFrameworkCore;
using NLog.Web;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using TiendaBatarazo.Dominio.InterfaceLN;
using TiendaBatarazo.AccesoDatos.Context;
using TiendaBatarazo.AccesoDatos.Implementaciones;
using TiendaBatarazo.Dominio.InterfacesAD;
using TiendaBatarazo.LogicaNegocio;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ============================
        // LOGGING CON NLOG
        // ============================

        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(LogLevel.Trace);
        builder.Host.UseNLog();

        // ============================
        // CONTROLADORES
        // ============================

        builder.Services.AddControllers();

        // ============================
        // CONFIGURACION JSON
        // ============================

        builder.Services.AddMvc().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.MaxDepth = 0;
        });

        // ============================
        // SWAGGER / OPENAPI
        // ============================

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // ============================
        // ENTITY FRAMEWORK
        // ============================

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
        );

        // ============================
        // UNIDAD DE TRABAJO
        // ============================

        builder.Services.AddScoped<DbContext, AppDbContext>();
        builder.Services.AddScoped<IUnidadTrabajoEF, UnidadTrabajoEF>();

        // ============================
        // LOGICA DE NEGOCIO
        // ============================

        builder.Services.AddScoped<ICategoriaLN, CategoriaLN>();
        builder.Services.AddScoped<IClienteLN, ClienteLN>();
        builder.Services.AddScoped<IDetalleVentaLN, DetalleVentaLN>();
        builder.Services.AddScoped<IPedidoLineaLN, PedidoLineaLN>();
        builder.Services.AddScoped<IPedidoProveedorLN, PedidoProveedorLN>();
        builder.Services.AddScoped<IProductoLN, ProductoLN>();
        builder.Services.AddScoped<IProveedorLN, ProveedorLN>();
        builder.Services.AddScoped<IUsuarioLN, UsuarioLN>();
        builder.Services.AddScoped<IVentaLN, VentaLN>();
        builder.Services.AddScoped<IPedidoLN, PedidoLN>();

        // ============================
        // CORS (para Angular / React)
        // ============================

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
        });

        // ============================
        // AUTORIZACION
        // ============================

        builder.Services.AddAuthorization();

        // ============================
        // BUILD APP
        // ============================

        var app = builder.Build();

        // ============================
        // MIDDLEWARE
        // ============================

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    
}