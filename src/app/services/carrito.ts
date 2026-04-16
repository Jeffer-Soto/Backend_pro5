import { Injectable } from '@angular/core';
import { IComic } from '../../models/comic.model';

export interface IItemCarrito {
  comic: IComic;
  cantidad: number;
  subtotal: number;
}

@Injectable({
  providedIn: 'root'
})
export class CarritoService {

  private items: IItemCarrito[] = [];

  agregar(comic: IComic) {
    const item = this.items.find(i => i.comic.id === comic.id);
    if (item) {
      if (item.cantidad < comic.stock) {
        item.cantidad++;
        item.subtotal = item.cantidad * comic.precioFinal;
      }
    } else {
      this.items.push({
        comic,
        cantidad: 1,
        subtotal: comic.precioFinal
      });
    }
  }

  quitar(comicId: number) {
    this.items = this.items.filter(i => i.comic.id !== comicId);
  }

  reducir(comicId: number) {
    const item = this.items.find(i => i.comic.id === comicId);
    if (item) {
      if (item.cantidad > 1) {
        item.cantidad--;
        item.subtotal = item.cantidad * item.comic.precioFinal;
      } else {
        this.quitar(comicId);
      }
    }
  }

  getItems(): IItemCarrito[] {
    return this.items;
  }

  getCantidadTotal(): number {
    return this.items.reduce((acc, i) => acc + i.cantidad, 0);
  }

  getSubtotal(): number {
    return this.items.reduce((acc, i) => acc + i.subtotal, 0);
  }

  getImpuesto(): number {
    return this.getSubtotal() * 0.13;
  }

  getTotal(): number {
    return this.getSubtotal() + this.getImpuesto();
  }

  limpiar() {
    this.items = [];
  }
}