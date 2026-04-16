export interface IVenta {
  id: number;
  fecha?: Date;
  subtotal: number;
  impuesto: number;
  total: number;
  moneda: string;
  usuarioId: number;
  descuento: number;
}