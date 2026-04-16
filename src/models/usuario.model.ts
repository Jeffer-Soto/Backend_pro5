export interface IUsuario {
  id: number;
  usuarioNombre: string;
  correo: string;
  edad: number;
  rol: string;
  creadoEn?: Date;
}