import { Event } from './../../../../node_modules/@firebase/webchannel-wrapper/dist/webchannel-blob/webchannel_blob_types.d';
import { Component, inject } from '@angular/core';
import { NavController } from '@ionic/angular/standalone';
import { ComicsService } from '../../services/comics';
import { CarritoService } from 'src/app/services/carrito';
import { IComic } from '../../../models/comic.model';
import { AuthService } from '../../services/auth';
import {
  IonContent,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonGrid,
  IonRow,
  IonCol,
  IonImg,
  IonText,
  IonInfiniteScroll,
  IonInfiniteScrollContent,
  IonButtons,
  IonButton,
  IonIcon,
  IonBadge,
  IonSearchbar,
  LoadingController,
  InfiniteScrollCustomEvent
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { bagOutline, logOutOutline, businessOutline } from 'ionicons/icons';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-list-comics',
  templateUrl: './list-comics.page.html',
  styleUrls: ['./list-comics.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonGrid,
    IonRow,
    IonCol,
    IonImg,
    IonText,
    IonInfiniteScroll,
    IonInfiniteScrollContent,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonButtons,
    IonButton,
    IonIcon,
    IonBadge,
    IonSearchbar,
    FormsModule
  ]
})
export class ListComicsPage {

  private comicsService: ComicsService = inject(ComicsService);
  private carritoService = inject(CarritoService);
  private loadingController: LoadingController = inject(LoadingController);
  private authService = inject(AuthService);
  private navCtrl = inject(NavController);

  public comics: IComic[] = [];
  public comicsFiltrados: IComic[] = [];
  public busqueda: string = '';

  constructor() {
    addIcons({ bagOutline, logOutOutline });
  }

  ionViewWillEnter() {
    this.loadComics();
  }

  async loadComics(event?: InfiniteScrollCustomEvent) {
    let loading: any;
    if (!event) {
      loading = await this.loadingController.create({
        message: 'Cargando comics...'
      });
      loading.present();
    }

    this.comicsService.getComics().then((comics: IComic[]) => {
      this.comics = comics;
      this.comicsFiltrados = comics;
    }).catch(error => {
      console.error(error);
    }).finally(() => {
      loading?.dismiss();
      event?.target.complete();
    });
  }

  buscar(event: any){
    const termino = event.detail.value.toLowerCase();
    this.comicsFiltrados = this.comics.filter(c =>
      c.nombre.toLowerCase().includes(termino) ||
      c.edicion?.toLowerCase().includes(termino)
    );
  }

  get cantidadCarrito(): number {
    return this.carritoService.getCantidadTotal();
  }

  goToDetail(comic: IComic) {
    this.navCtrl.navigateForward(`/cliente/detail-comics/${comic.id}`);
  }

  irCarrito(){
    this.navCtrl.navigateForward(['/cliente/carrito'])
  }

  misCompras() {
    this.navCtrl.navigateForward(['/cliente/mis-compras']);
  }

  async cerrarSesion() {
    await this.authService.logout();
    this.navCtrl.navigateForward(['/login']);
  }
}
