import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    loadComponent: () => import('./pages/login/login.page')
      .then(m => m.LoginPage)
  },

  // ─── CLIENTE ───────────────────────────────
  {
    path: 'cliente/list-comics',
    loadComponent: () => import('./pages/list-comics/list-comics.page')
      .then(m => m.ListComicsPage)
  },
  {
    path: 'cliente/detail-comics/:id',
    loadComponent: () => import('./pages/detail-comics/detail-comics.page')
      .then(m => m.DetailComicsPage)
  },
  {
    path: 'cliente/carrito',
    loadComponent: () => import('./pages/cliente/carrito/carrito.page')
      .then(m => m.CarritoPage)
  },
  {
    path: 'cliente/mis-compras',
    loadComponent: () => import('./pages/cliente/mis-compras/mis-compras.page')
      .then(m => m.MisComprasPage)
  },

  // ─── ADMIN ─────────────────────────────────
  {
    path: 'admin/dashboard',
    loadComponent: () => import('./pages/admin/dashboard/dashboard.page')
      .then(m => m.DashboardPage)
  },
  {
    path: 'admin/gestion-comics',
    loadComponent: () => import('./pages/admin/gestion-comics/gestion-comics.page')
      .then(m => m.GestionComicsPage)
  },
  {
    path: 'admin/gestion-comics-form',
    loadComponent: () => import('./pages/admin/gestion-comics-form/gestion-comics-form.page')
      .then(m => m.GestionComicsFormPage)
  },
  {
    path: 'admin/gestion-comics-form/:id',
    loadComponent: () => import('./pages/admin/gestion-comics-form/gestion-comics-form.page')
      .then(m => m.GestionComicsFormPage)
  },
  {
    path: 'admin/gestion-proveedores',
    loadComponent: () => import('./pages/admin/gestion-proveedores/gestion-proveedores.page')
      .then(m => m.GestionProveedoresPage)
  },
  {
    path: 'admin/gestion-proveedores-form',
    loadComponent: () => import('./pages/admin/gestion-proveedores-form/gestion-proveedores-form.page')
      .then(m => m.GestionProveedoresFormPage)
  },
  {
    path: 'admin/gestion-proveedores-form/:id',
    loadComponent: () => import('./pages/admin/gestion-proveedores-form/gestion-proveedores-form.page')
      .then(m => m.GestionProveedoresFormPage)
  },
  {
    path: 'admin/gestion-usuarios',
    loadComponent: () => import('./pages/admin/gestion-usuarios/gestion-usuarios.page')
      .then(m => m.GestionUsuariosPage)
  },
  {
    path: 'admin/gestion-ventas',
    loadComponent: () => import('./pages/admin/gestion-ventas/gestion-ventas.page')
      .then(m => m.GestionVentasPage)
  },

  // ─── VENDEDOR ──────────────────────────────
  {
    path: 'vendedor/punto-venta',
    loadComponent: () => import('./pages/vendedor/punto-venta/punto-venta.page')
      .then(m => m.PuntoVentaPage)
  },
  {
    path: 'vendedor/mis-ventas',
    loadComponent: () => import('./pages/vendedor/mis-ventas/mis-ventas.page')
      .then(m => m.MisVentasPage)
  }
];

/*
🔴 Admin: admin@tienda.com admin123
🟡 Vendedor: vendedor@tienda.com vendedor123
🔵 Cliente: cliente@tienda.com cliente123 
*/