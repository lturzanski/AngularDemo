import { Component, Injector } from '@angular/core';
import { StateExclusionViewGenerated } from './state-exclusion-view-generated.component';

@Component({
  selector: 'page-state-exclusion-view',
  templateUrl: './state-exclusion-view.component.html'
})
export class StateExclusionViewComponent extends StateExclusionViewGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
