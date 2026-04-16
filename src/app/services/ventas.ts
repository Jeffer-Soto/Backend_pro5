import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { IVenta } from '../../models/venta.model';

@Injectable({
  providedIn: 'root'
})
export class VentasService {

  private http = inject(HttpClient);
  private readonly URL_BASE = 'http://localhost:5090/api/Venta';

  getVentas(): Promise<IVenta[]> {
    return firstValueFrom(this.http.get<IVenta[]>(this.URL_BASE));
  }

  getVenta(id: number): Promise<IVenta> {
    return firstValueFrom(this.http.get<IVenta>(`${this.URL_BASE}/${id}`));
  }

  createVenta(venta: IVenta): Promise<IVenta> {
    return firstValueFrom(this.http.post<IVenta>(this.URL_BASE, venta));
  }

  deleteVenta(id: number): Promise<void> {
    return firstValueFrom(this.http.delete<void>(`${this.URL_BASE}/${id}`));
  }
}