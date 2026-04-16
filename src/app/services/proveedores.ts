import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { IProveedor } from '../../models/proveedor.model';

@Injectable({
  providedIn: 'root'
})
export class ProveedoresService {

  private http = inject(HttpClient);
  private readonly URL_BASE = 'http://localhost:5090/api/ProveedorControl';

  getProveedores(): Promise<IProveedor[]> {
    return firstValueFrom(this.http.get<IProveedor[]>(this.URL_BASE));
  }

  getProveedor(id: number): Promise<IProveedor> {
    return firstValueFrom(this.http.get<IProveedor>(`${this.URL_BASE}/${id}`));
  }

  createProveedor(proveedor: IProveedor): Promise<IProveedor> {
    return firstValueFrom(this.http.post<IProveedor>(this.URL_BASE, proveedor));
  }

  updateProveedor(id: number, proveedor: IProveedor): Promise<void> {
    return firstValueFrom(this.http.put<void>(`${this.URL_BASE}/${id}`, proveedor));
  }

  deleteProveedor(id: number): Promise<void> {
    return firstValueFrom(this.http.delete<void>(`${this.URL_BASE}/${id}`));
  }
}