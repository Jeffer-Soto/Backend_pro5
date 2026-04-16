import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ListComicsPage } from './list-comics.page';

describe('ListComicsPage', () => {
  let component: ListComicsPage;
  let fixture: ComponentFixture<ListComicsPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ListComicsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
