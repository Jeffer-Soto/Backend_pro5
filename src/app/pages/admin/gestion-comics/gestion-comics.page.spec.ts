import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GestionComicsPage } from './gestion-comics.page';

describe('GestionComicsPage', () => {
  let component: GestionComicsPage;
  let fixture: ComponentFixture<GestionComicsPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionComicsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
