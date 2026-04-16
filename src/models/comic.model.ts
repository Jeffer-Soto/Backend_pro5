export interface IComic {
  id: number;
  idProveedor: number;
  nombre: string;
  numeroSaga?: string;
  edicion?: string;
  portada?: string;
  version: string;
  valorBase: number;
  precioFinal: number;
  stock: number;
  createdAt?: Date;
}