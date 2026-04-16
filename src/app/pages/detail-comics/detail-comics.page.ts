import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IComic } from '../../../models/comic.model';
import { ComicsService } from '../../services/comics';
import { CarritoService } from '../../services/carrito';
import {
  IonContent,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonButtons,
  IonBackButton,
  IonButton,
  IonIcon,
  IonCard,
  IonCardHeader,
  IonCardTitle,
  IonCardSubtitle,
  IonCardContent,
  IonImg,
  IonText,
  IonBadge,
  ToastController,
  AlertController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { cartOutline, bagOutline } from 'ionicons/icons';

@Component({
  selector: 'app-detail-comics',
  templateUrl: './detail-comics.page.html',
  styleUrls: ['./detail-comics.page.scss'],
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
    IonCard,
    IonCardHeader,
    IonCardTitle,
    IonCardSubtitle,
    IonCardContent,
    IonImg,
    IonText,
    IonBadge
  ]
})
export class DetailComicsPage implements OnInit {

  private route = inject(ActivatedRoute);
  private comicsService = inject(ComicsService);
  private carritoService = inject(CarritoService);
  private router = inject(Router);
  private toastController = inject(ToastController);
  private alertController = inject(AlertController);

  public comic: IComic | null = null;

  constructor() {
    addIcons({ cartOutline, bagOutline });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadComic(+id); 
    }
  }

  loadComic(id: number) { 
    this.comicsService.getComic(id).then((comic: IComic) => { 
        this.comic = comic;
      })
      .catch(err => {
        console.error('Error cargando comic:', err);
      });
  }

  async agregarAlCarrito() {
    if (!this.comic) return;

    if (this.comic.stock === 0) {
      const alert = await this.alertController.create({
        header: 'Sin stock',
        message: 'Este comic no tiene unidades disponibles.',
        buttons: ['OK']
      });
      await alert.present();
      return;
    }

    this.carritoService.agregar(this.comic);
    const toast = await this.toastController.create({
      message: `✅ ${this.comic.nombre} agregado al carrito`,
      duration: 2000,
      position: 'bottom',
      color: 'success'
    });
    await toast.present();
  }

  irAlCarrito() {
    this.router.navigate(['/cliente/carrito']);
  }
}