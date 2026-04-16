import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MisVentasPage } from './mis-ventas.page';

describe('MisVentasPage', () => {
  let component: MisVentasPage;
  let fixture: ComponentFixture<MisVentasPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(MisVentasPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
