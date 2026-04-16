import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth';
import {
  IonContent,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonItem,
  IonLabel,
  IonInput,
  IonButton,
  IonText,
  LoadingController,
  AlertController
} from '@ionic/angular/standalone';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonItem,
    IonLabel,
    IonInput,
    IonButton,
    IonText,
    FormsModule
  ]
})
export class LoginPage {

  private authService = inject(AuthService);
  private router = inject(Router);
  private loadingController = inject(LoadingController);
  private alertController = inject(AlertController);

  public correo: string = '';
  public clave: string = '';

  async login() {
  const loading = await this.loadingController.create({
    message: 'Iniciando sesión...'
  });
  await loading.present();

  this.authService.login(this.correo, this.clave)
    .then((resultado: any) => {
      const rol = resultado.rol;
      if (rol === 'admin') {
        this.router.navigate(['/admin/dashboard']);
      } else if (rol === 'vendedor') {
        this.router.navigate(['/vendedor/punto-venta']);
      } else {
        this.router.navigate(['/cliente/list-comics']);
      }
    })
    .catch(async (error) => {
      const alert = await this.alertController.create({
        header: 'Error',
        message: 'Correo o contraseña incorrectos',
        buttons: ['OK']
      });
      await alert.present();
    })
    .finally(() => {
      loading.dismiss();
    });
}
}