import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ComicsService } from '../../../services/comics';
import { VentasService } from '../../../services/ventas';
import { AuthService } from '../../../services/auth';
import { IComic } from '../../../../models/comic.model';
import { IVenta } from '../../../../models/venta.model';
import {
  IonContent,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonButton,
  IonIcon,
  IonGrid,
  IonRow,
  IonCol,
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardTitle,
  IonBadge,
  IonList,
  IonItem,
  IonLabel,
  IonText,
  AlertController,
  LoadingController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { cartOutline, trashOutline, receiptOutline, logOutOutline } from 'ionicons/icons';

export interface IItemCarrito {
  comic: IComic;
  cantidad: number;
  subtotal: number;
}

@Component({
  selector: 'app-punto-venta',
  templateUrl: './punto-venta.page.html',
  styleUrls: ['./punto-venta.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonButtons,
    IonButton,
    IonIcon,
    IonGrid,
    IonRow,
    IonCol,
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardTitle,
    IonBadge,
    IonList,
    IonItem,
    IonLabel,
    IonText
  ]
})
export class PuntoVentaPage {

  private comicsService = inject(ComicsService);
  private ventasService = inject(VentasService);
  private authService = inject(AuthService);
  private router = inject(Router);
  private alertController = inject(AlertController);
  private loadingController = inject(LoadingController);

  public comics: IComic[] = [];
  public carrito: IItemCarrito[] = [];

  constructor() {
    addIcons({ cartOutline, trashOutline, receiptOutline, logOutOutline });
  }

  ionViewWillEnter() {
    this.cargarComics();
  }

  cargarComics() {
    this.comicsService.getComics()
      .then((comics: IComic[]) => {
        this.comics = comics.filter(c => c.stock > 0);
      })
      .catch(error => console.error(error));
  }

  agregarAlCarrito(comic: IComic) {
    const item = this.carrito.find(i => i.comic.id === comic.id);
    if (item) {
      if (item.cantidad < comic.stock) {
        item.cantidad++;
        item.subtotal = item.cantidad * comic.precioFinal;
      }
    } else {
      this.carrito.push({
        comic,
        cantidad: 1,
        subtotal: comic.precioFinal
      });
    }
  }

  quitarDelCarrito(item: IItemCarrito) {
    this.carrito = this.carrito.filter(i => i.comic.id !== item.comic.id);
  }

  get total(): number {
    return this.carrito.reduce((acc, item) => acc + item.subtotal, 0);
  }

  get subtotal(): number {
    return this.total / 1.13;
  }

  get impuesto(): number {
    return this.total - this.subtotal;
  }

  async cobrar() {
    if (this.carrito.length === 0) {
      const alert = await this.alertController.create({
        header: 'Carrito vacío',
        message: 'Agregá al menos un comic al carrito',
        buttons: ['OK']
      });
      await alert.present();
      return;
    }

    const alert = await this.alertController.create({
      header: 'Confirmar Venta',
      message: `Total a cobrar: ₡${this.total.toFixed(2)}`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Confirmar',
          handler: () => this.procesarVenta()
        }
      ]
    });
    await alert.present();
  }

  async procesarVenta() {
    const loading = await this.loadingController.create({
      message: 'Procesando venta...'
    });
    await loading.present();

    const venta: IVenta = {
      id: 0,
      subtotal: parseFloat(this.subtotal.toFixed(2)),
      impuesto: parseFloat(this.impuesto.toFixed(2)),
      total: parseFloat(this.total.toFixed(2)),
      moneda: 'CRC',
      usuarioId: 1,
      descuento: 0
    };

    this.ventasService.createVenta(venta)
      .then(async () => {
        this.carrito = [];
        const alert = await this.alertController.create({
          header: '✅ Venta Exitosa',
          message: 'La venta se registró correctamente',
          buttons: ['OK']
        });
        await alert.present();
        this.cargarComics();
      })
      .catch(async (error) => {
        const alert = await this.alertController.create({
          header: 'Error',
          message: 'No se pudo procesar la venta',
          buttons: ['OK']
        });
        await alert.present();
      })
      .finally(() => loading.dismiss());
  }

  async cerrarSesion() {
    await this.authService.logout();
    this.router.navigate(['/login']);
  }
}