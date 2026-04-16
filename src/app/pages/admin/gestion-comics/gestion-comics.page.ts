import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
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
  IonIcon,
  IonList,
  IonItem,
  IonLabel,
  IonBadge,
  IonText,
  AlertController,
  LoadingController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { addOutline, createOutline, trashOutline, warningOutline } from 'ionicons/icons';

@Component({
  selector: 'app-gestion-comics',
  templateUrl: './gestion-comics.page.html',
  styleUrls: ['./gestion-comics.page.scss'],
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
    IonBadge,
    IonText
  ]
})
export class GestionComicsPage {

  private comicsService = inject(ComicsService);
  private router = inject(Router);
  private alertController = inject(AlertController);
  private loadingController = inject(LoadingController);

  public comics: IComic[] = [];

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline, warningOutline });
  }

  ionViewWillEnter() {
    this.cargarComics();
  }

  async cargarComics() {
    const loading = await this.loadingController.create({
      message: 'Cargando...'
    });
    await loading.present();

    this.comicsService.getComics()
      .then((comics: IComic[]) => {
        this.comics = comics;
      })
      .catch(error => console.error(error))
      .finally(() => loading.dismiss());
  }

  agregar() {
    this.router.navigate(['/admin/gestion-comics-form']);
  }

  editar(comic: IComic) {
    this.router.navigate(['/admin/gestion-comics-form', comic.id]);
  }

  async eliminar(comic: IComic) {
    const alert = await this.alertController.create({
      header: 'Confirmar',
      message: `¿Eliminar "${comic.nombre}"?`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.comicsService.deleteComic(comic.id)
              .then(() => this.cargarComics())
              .catch(error => console.error(error));
          }
        }
      ]
    });
    await alert.present();
  }
}