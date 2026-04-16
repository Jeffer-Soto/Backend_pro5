import { Component, Input, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ComicsService } from '../../../services/comics';
import { IComic } from '../../../../models/comic.model';
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
  IonSelect,
  IonSelectOption,
  LoadingController,
  AlertController
} from '@ionic/angular/standalone';

@Component({
  selector: 'app-gestion-comics-form',
  templateUrl: './gestion-comics-form.page.html',
  styleUrls: ['./gestion-comics-form.page.scss'],
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
    IonSelect,
    IonSelectOption,
    FormsModule
  ]
})
export class GestionComicsFormPage {

  @Input() id!: number;

  private comicsService = inject(ComicsService);
  private router = inject(Router);
  private loadingController = inject(LoadingController);
  private alertController = inject(AlertController);

  public esEdicion: boolean = false;

  public comic: IComic = {
    id: 0,
    idProveedor: 1,
    nombre: '',
    numeroSaga: '',
    edicion: '',
    portada: '',
    version: 'normal',
    valorBase: 0,
    precioFinal: 0,
    stock: 0,
    createdAt: new Date()
  };

  ionViewWillEnter() {
    if (this.id) {
      this.esEdicion = true;
      this.cargarComic();
    }
  }

  cargarComic() {
    this.comicsService.getComic(this.id).then((comic: IComic) => {
      this.comic = comic;
    });
  }

  async guardar() {
    if (!this.comic.nombre || !this.comic.precioFinal) {
      const alert = await this.alertController.create({
        header: 'Error',
        message: 'El nombre y precio son obligatorios',
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
      ? this.comicsService.updateComic(this.id, this.comic)
      : this.comicsService.createComic(this.comic);

    operacion
      .then(() => {
        this.router.navigate(['/admin/gestion-comics']);
      })
      .catch(async (error) => {
        const alert = await this.alertController.create({
          header: 'Error',
          message: 'No se pudo guardar el comic',
          buttons: ['OK']
        });
        await alert.present();
      })
      .finally(() => loading.dismiss());
  }
}