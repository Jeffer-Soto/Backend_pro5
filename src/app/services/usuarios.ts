import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { IUsuario } from '../../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private http = inject(HttpClient);
  private readonly URL_BASE = 'http://localhost:5090/api/Usuario';

  getUsuarios(): Promise<IUsuario[]> {
    return firstValueFrom(this.http.get<IUsuario[]>(this.URL_BASE));
  }

  getUsuario(id: number): Promise<IUsuario> {
    return firstValueFrom(this.http.get<IUsuario>(`${this.URL_BASE}/${id}`));
  }

  createUsuario(usuario: any): Promise<any> {
  return firstValueFrom(this.http.post(`${this.URL_BASE}`, usuario));
}

  updateUsuario(id: number, usuario: IUsuario): Promise<void> {
    return firstValueFrom(this.http.put<void>(`${this.URL_BASE}/${id}`, usuario));
  }

  deleteUsuario(id: number): Promise<void> {
    return firstValueFrom(this.http.delete<void>(`${this.URL_BASE}/${id}`));
  }
}
