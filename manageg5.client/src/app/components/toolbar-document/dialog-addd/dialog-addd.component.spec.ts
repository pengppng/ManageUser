import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogAdddocComponent } from './dialog-addd.component';

describe('DialogAdddComponent', () => {
  let component: DialogAdddocComponent;
  let fixture: ComponentFixture<DialogAdddocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DialogAdddocComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogAdddocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
