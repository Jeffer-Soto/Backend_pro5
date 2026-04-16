import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { CarritoService, IItemCarrito } from '../../../services/carrito';
import { VentasService } from '../../../services/ventas';
import { IVenta } from '../../../../models/venta.model';
import {
  IonContent,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonBackButton,
  IonButton,
  IonIcon,
  IonList,
  IonItem,
  IonLabel,
  IonText,
  AlertController,
  LoadingController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { trashOutline, addOutline, removeOutline, cartOutline } from 'ionicons/icons';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.page.html',
  styleUrls: ['./carrito.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonButtons,
    IonBackButton,
    IonButton,
    IonIcon,
    IonList,
    IonItem,
    IonLabel,
    IonText
  ]
})
export class CarritoPage {

  private carritoService = inject(CarritoService);
  private ventasService = inject(VentasService);
  private router = inject(Router);
  private alertController = inject(AlertController);
  private loadingController = inject(LoadingController);

  constructor() {
    addIcons({ trashOutline, addOutline, removeOutline, cartOutline });
  }

  get items(): IItemCarrito[] {
    return this.carritoService.getItems();
  }

  get subtotal(): number {
    return this.carritoService.getSubtotal();
  }

  get impuesto(): number {
    return this.carritoService.getImpuesto();
  }

  get total(): number {
    return this.carritoService.getTotal();
  }

  agregar(item: IItemCarrito) {
    this.carritoService.agregar(item.comic);
  }

  reducir(item: IItemCarrito) {
    this.carritoService.reducir(item.comic.id);
  }

  quitar(item: IItemCarrito) {
    this.carritoService.quitar(item.comic.id);
  }

  async comprar() {
    if (this.items.length === 0) {
      const alert = await this.alertController.create({
        header: 'Carrito vacío',
        message: 'Agregá al menos un comic al carrito',
        buttons: ['OK']
      });
      await alert.present();
      return;
    }

    const alert = await this.alertController.create({
      header: 'Confirmar Compra',
      message: `Total a pagar: ₡${this.total.toFixed(2)}`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Confirmar',
          handler: () => this.procesarCompra()
        }
      ]
    });
    await alert.present();
  }

  async procesarCompra() {
    const loading = await this.loadingController.create({
      message: 'Procesando compra...'
    });
    await loading.present();

    const venta: IVenta = {
      id: 0,
      subtotal: parseFloat(this.subtotal.toFixed(2)),
      impuesto: parseFloat(this.impuesto.toFixed(2)),
      total: parseFloat(this.total.toFixed(2)),
      moneda: 'CRC',
      usuarioId: 3,
      descuento: 0
    };

    this.ventasService.createVenta(venta)
      .then(async () => {
        this.carritoService.limpiar();
        const alert = await this.alertController.create({
          header: '🎉 Compra Exitosa',
          message: 'Tu compra se realizó correctamente',
          buttons: [{
            text: 'OK',
            handler: () => this.router.navigate(['/cliente/mis-compras'])
          }]
        });
        await alert.present();
      })
      .catch(async () => {
        const alert = await this.alertController.create({
          header: 'Error',
          message: 'No se pudo procesar la compra',
          buttons: ['OK']
        });
        await alert.present();
      })
      .finally(() => loading.dismiss());
  }
}