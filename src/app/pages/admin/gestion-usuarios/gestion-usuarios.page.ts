import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UsuariosService } from '../../../services/usuarios';
import { IUsuario } from '../../../../models/usuario.model';
import {
  IonContent, IonHeader, IonToolbar, IonTitle, IonButtons, IonBackButton,
  IonList, IonItem, IonLabel, IonBadge, IonButton, IonIcon,
  IonModal, IonInput, IonSelect, IonSelectOption,
  AlertController, LoadingController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { trashOutline, personOutline, addOutline, createOutline } from 'ionicons/icons';

@Component({
  selector: 'app-gestion-usuarios',
  templateUrl: './gestion-usuarios.page.html',
  styleUrls: ['./gestion-usuarios.page.scss'],
  standalone: true,
  imports: [
    FormsModule,
    IonContent, IonHeader, IonToolbar, IonTitle, IonButtons, IonBackButton,
    IonList, IonItem, IonLabel, IonBadge, IonButton, IonIcon,
    IonModal, IonInput, IonSelect, IonSelectOption
  ]
})
export class GestionUsuariosPage {

  private usuariosService = inject(UsuariosService);
  private alertController = inject(AlertController);
  private loadingController = inject(LoadingController);

  public usuarios: IUsuario[] = [];

  public modalAbierto = false;
  public nuevoUsuario = {
    usuarioNombre: '',
    correo: '',
    clave: '',
    rol: 'cliente',
    edad: null as number | null,
    fechaNacimiento: ''
  };

  public modalEditarAbierto = false;
  public usuarioEditando: IUsuario | null = null;
  public rolSeleccionado = '';

  constructor() {
    addIcons({ trashOutline, personOutline, addOutline, createOutline });
  }

  ionViewWillEnter() {
    this.cargarUsuarios();
  }

  async cargarUsuarios() {
    const loading = await this.loadingController.create({ message: 'Cargando usuarios...' });
    await loading.present();
    this.usuariosService.getUsuarios()
      .then((usuarios: IUsuario[]) => { this.usuarios = usuarios; })
      .catch(error => console.error(error))
      .finally(() => loading.dismiss());
  }

  colorRol(rol: string): string {
    switch (rol) {
      case 'admin': return 'danger';
      case 'vendedor': return 'warning';
      default: return 'primary';
    }
  }

  abrirModal() {
    this.nuevoUsuario = { usuarioNombre: '', correo: '', clave: '', rol: 'cliente', edad: null, fechaNacimiento: '' };
    this.modalAbierto = true;
  }

  cerrarModal() {
    this.modalAbierto = false;
  }

  async guardarUsuario() {
    const { usuarioNombre, correo, clave, rol, edad, fechaNacimiento } = this.nuevoUsuario;
    if (!usuarioNombre || !correo || !clave || !rol || !edad || !fechaNacimiento) {
      const alert = await this.alertController.create({
        header: 'Campos incompletos',
        message: 'Por favor completá todos los campos.',
        buttons: ['OK']
      });
      await alert.present();
      return;
    }

    const loading = await this.loadingController.create({ message: 'Guardando...' });
    await loading.present();

    this.usuariosService.createUsuario({
      usuarioNombre, correo, clave, rol, edad,
      fechaNacimiento: new Date(fechaNacimiento).toISOString(),
      creadoEn: new Date().toISOString()
    })
      .then(() => { this.cerrarModal(); this.cargarUsuarios(); })
      .catch(error => console.error(error))
      .finally(() => loading.dismiss());
  }

  // ── EDITAR ROL ─────────────────────────────────
  abrirModalEditar(usuario: IUsuario) {
    this.usuarioEditando = { ...usuario };
    this.rolSeleccionado = usuario.rol;
    this.modalEditarAbierto = true;
  }

  cerrarModalEditar() {
    this.modalEditarAbierto = false;
    this.usuarioEditando = null;
  }

  async guardarRol() {
    if (!this.usuarioEditando) return;

    const loading = await this.loadingController.create({ message: 'Actualizando rol...' });
    await loading.present();

    const usuarioActualizado: IUsuario = {
      ...this.usuarioEditando,
      rol: this.rolSeleccionado
    };

    this.usuariosService.updateUsuario(this.usuarioEditando.id, usuarioActualizado)
      .then(() => { this.cerrarModalEditar(); this.cargarUsuarios(); })
      .catch(error => console.error(error))
      .finally(() => loading.dismiss());
  }

  // ── ELIMINAR ───────────────────────────────────
  async eliminar(usuario: IUsuario) {
    const alert = await this.alertController.create({
      header: 'Confirmar',
      message: `¿Eliminar usuario "${usuario.usuarioNombre}"?`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar', role: 'destructive',
          handler: () => {
            this.usuariosService.deleteUsuario(usuario.id)
              .then(() => this.cargarUsuarios())
              .catch(error => console.error(error));
          }
        }
      ]
    });
    await alert.present();
  }
}
