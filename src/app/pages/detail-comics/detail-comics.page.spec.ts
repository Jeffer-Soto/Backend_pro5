import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DetailComicsPage } from './detail-comics.page';

describe('DetailComicsPage', () => {
  let component: DetailComicsPage;
  let fixture: ComponentFixture<DetailComicsPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailComicsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
