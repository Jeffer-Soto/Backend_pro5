import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GestionComicsFormPage } from './gestion-comics-form.page';

describe('GestionComicsFormPage', () => {
  let component: GestionComicsFormPage;
  let fixture: ComponentFixture<GestionComicsFormPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionComicsFormPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
