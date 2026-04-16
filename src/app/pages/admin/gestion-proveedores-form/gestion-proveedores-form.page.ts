import { Component, Input, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
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
  IonItem,
  IonLabel,
  IonInput,
  LoadingController,
  AlertController
} from '@ionic/angular/standalone';

@Component({
  selector: 'app-gestion-proveedores-form',
  templateUrl: './gestion-proveedores-form.page.html',
  styleUrls: ['./gestion-proveedores-form.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonButtons,
    IonBackButton,
    IonButton,
    IonItem,
    IonLabel,
    IonInput,
    FormsModule
  ]
})
export class GestionProveedoresFormPage {

  @Input() id!: number;

  private proveedoresService = inject(ProveedoresService);
  private router = inject(Router);
  private loadingController = inject(LoadingController);
  private alertController = inject(AlertController);

  public esEdicion: boolean = false;

  public proveedor: IProveedor = {
    id: 0,
    nombre: '',
    telefono: '',
    correo: ''
  };

  ionViewWillEnter() {
    if (this.id) {
      this.esEdicion = true;
      this.cargarProveedor();
    }
  }

  cargarProveedor() {
    this.proveedoresService.getProveedor(this.id).then((proveedor: IProveedor) => {
      this.proveedor = proveedor;
    });
  }

  async guardar() {
    if (!this.proveedor.nombre) {
      const alert = await this.alertController.create({
        header: 'Error',
        message: 'El nombre es obligatorio',
        buttons: ['OK']
      });
      await alert.present();
      return;
    }

    const loading = await this.loadingController.create({
      message: 'Guardando...'
    });
    await loading.present();

    const operacion = this.esEdicion
      ? this.proveedoresService.updateProveedor(this.id, this.proveedor)
      : this.proveedoresService.createProveedor(this.proveedor);

    operacion
      .then(() => {
        this.router.navigate(['/admin/gestion-proveedores']);
      })
      .catch(async (error) => {
        const alert = await this.alertController.create({
          header: 'Error',
          message: 'No se pudo guardar el proveedor',
          buttons: ['OK']
        });
        await alert.present();
      })
      .finally(() => loading.dismiss());
  }
}