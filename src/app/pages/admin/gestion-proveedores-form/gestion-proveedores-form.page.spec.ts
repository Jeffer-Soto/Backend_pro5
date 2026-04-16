import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GestionProveedoresFormPage } from './gestion-proveedores-form.page';

describe('GestionProveedoresFormPage', () => {
  let component: GestionProveedoresFormPage;
  let fixture: ComponentFixture<GestionProveedoresFormPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionProveedoresFormPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
