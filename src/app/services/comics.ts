import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { IComic } from '../../models/comic.model';

@Injectable({
  providedIn: 'root'
})
export class ComicsService {

  private http = inject(HttpClient);
  private readonly URL_BASE = 'http://localhost:5090/api/Comic';

  getComics(): Promise<IComic[]> {
    return firstValueFrom(this.http.get<IComic[]>(this.URL_BASE));
  }

  getComic(id: number): Promise<IComic> {
    return firstValueFrom(this.http.get<IComic>(`${this.URL_BASE}/${id}`));
  }

  createComic(comic: IComic): Promise<IComic> {
    return firstValueFrom(this.http.post<IComic>(this.URL_BASE, comic));
  }

  updateComic(id: number, comic: IComic): Promise<void> {
    return firstValueFrom(this.http.put<void>(`${this.URL_BASE}/${id}`, comic));
  }

  deleteComic(id: number): Promise<void> {
    return firstValueFrom(this.http.delete<void>(`${this.URL_BASE}/${id}`));
  }
}