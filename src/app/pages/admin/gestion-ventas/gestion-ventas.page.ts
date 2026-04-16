import { Component, inject } from '@angular/core';
import { VentasService } from '../../../services/ventas';
import { IVenta } from '../../../../models/venta.model';
import {
  IonContent,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonBackButton,
  IonList,
  IonItem,
  IonLabel,
  IonBadge,
  IonButton,
  IonIcon,
  AlertController,
  LoadingController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { trashOutline, receiptOutline } from 'ionicons/icons';

@Component({
  selector: 'app-gestion-ventas',
  templateUrl: './gestion-ventas.page.html',
  styleUrls: ['./gestion-ventas.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonButtons,
    IonBackButton,
    IonList,
    IonItem,
    IonLabel,
    IonBadge,
    IonButton,
    IonIcon
  ]
})
export class GestionVentasPage {

  private ventasService = inject(VentasService);
  private alertController = inject(AlertController);
  private loadingController = inject(LoadingController);

  public ventas: IVenta[] = [];
  public totalVentas: number = 0;

  constructor() {
    addIcons({ trashOutline, receiptOutline });
  }

  ionViewWillEnter() {
    this.cargarVentas();
  }

  async cargarVentas() {
    const loading = await this.loadingController.create({
      message: 'Cargando ventas...'
    });
    await loading.present();

    this.ventasService.getVentas()
      .then((ventas: IVenta[]) => {
        this.ventas = ventas;
        this.totalVentas = ventas.reduce((acc, v) => acc + v.total, 0);
      })
      .catch(error => console.error(error))
      .finally(() => loading.dismiss());
  }

  async eliminar(venta: IVenta) {
    const alert = await this.alertController.create({
      header: 'Confirmar',
      message: `¿Eliminar venta #${venta.id}?`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.ventasService.deleteVenta(venta.id)
              .then(() => this.cargarVentas())
              .catch(error => console.error(error));
          }
        }
      ]
    });
    await alert.present();
  }
}