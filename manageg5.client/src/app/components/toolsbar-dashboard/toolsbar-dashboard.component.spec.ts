import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolsbarDashboardComponent } from './toolsbar-dashboard.component';

describe('ToolsbarDashboardComponent', () => {
  let component: ToolsbarDashboardComponent;
  let fixture: ComponentFixture<ToolsbarDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToolsbarDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToolsbarDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
