import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogAddComponent } from './dialog-addd.component';

describe('DialogAdddComponent', () => {
  let component: DialogAddComponent;
  let fixture: ComponentFixture<DialogAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DialogAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
