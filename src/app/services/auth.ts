import { Injectable, inject } from '@angular/core';
import { initializeApp } from 'firebase/app';
import {
  getAuth,
  signInWithEmailAndPassword,
  signOut,
  onAuthStateChanged,
  User
} from 'firebase/auth';
import { environment } from '../../environments/environment';

const app = initializeApp(environment.firebaseConfig);
const auth = getAuth(app);

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public usuarioActual: User | null = null;

  constructor() {
    onAuthStateChanged(auth, (user) => {
      this.usuarioActual = user;
    });
  }

/*  login(correo: string, clave: string) {
  return signInWithEmailAndPassword(auth, correo, clave)
    .then(async (userCredential) => {
      // Aquí consultamos el rol en tu API .NET
      const response = await fetch(
        `http://localhost:5090/api/Usuario/correo/${correo}`
      );
      if (response.ok) {
        const usuario = await response.json();
        return { userCredential, rol: usuario.rol };
      }
      return { userCredential, rol: 'cliente' };
    });
}*/
login(correo: string, clave: string) {
  return signInWithEmailAndPassword(auth, correo, clave)
    .then((userCredential) => {
      // Determinamos el rol según el correo
      let rol = 'cliente';
      if (correo.includes('admin')) {
        rol = 'admin';
      } else if (correo.includes('vendedor')) {
        rol = 'vendedor';
      }
      return { userCredential, rol };
    });
}

  logout() {
    return signOut(auth);
  }

  getUsuario() {
    return this.usuarioActual;
  }

  isLoggedIn(): boolean {
    return this.usuarioActual !== null;
  }
}
