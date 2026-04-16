import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GestionVentasPage } from './gestion-ventas.page';

describe('GestionVentasPage', () => {
  let component: GestionVentasPage;
  let fixture: ComponentFixture<GestionVentasPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionVentasPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
