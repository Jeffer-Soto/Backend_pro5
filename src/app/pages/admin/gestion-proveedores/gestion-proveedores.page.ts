import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ProveedoresService } from '../../../services/proveedores';
import { IProveedor } from '../../../../models/proveedor.model';
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
  AlertController,
  LoadingController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { addOutline, createOutline, trashOutline, businessOutline } from 'ionicons/icons';

@Component({
  selector: 'app-gestion-proveedores',
  templateUrl: './gestion-proveedores.page.html',
  styleUrls: ['./gestion-proveedores.page.scss'],
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
    IonLabel
  ]
})
export class GestionProveedoresPage {

  private proveedoresService = inject(ProveedoresService);
  private router = inject(Router);
  private alertController = inject(AlertController);
  private loadingController = inject(LoadingController);

  public proveedores: IProveedor[] = [];

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline, businessOutline });
  }

  ionViewWillEnter() {
    this.cargarProveedores();
  }

  async cargarProveedores() {
    const loading = await this.loadingController.create({
      message: 'Cargando proveedores...'
    });
    await loading.present();

    this.proveedoresService.getProveedores()
      .then((proveedores: IProveedor[]) => {
        this.proveedores = proveedores;
      })
      .catch(error => console.error(error))
      .finally(() => loading.dismiss());
  }

  agregar() {
    this.router.navigate(['/admin/gestion-proveedores-form']);
  }

  editar(proveedor: IProveedor) {
    this.router.navigate(['/admin/gestion-proveedores-form', proveedor.id]);
  }

  async eliminar(proveedor: IProveedor) {
    const alert = await this.alertController.create({
      header: 'Confirmar',
      message: `¿Eliminar proveedor "${proveedor.nombre}"?`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.proveedoresService.deleteProveedor(proveedor.id)
              .then(() => this.cargarProveedores())
              .catch(error => console.error(error));
          }
        }
      ]
    });
    await alert.present();
  }
}