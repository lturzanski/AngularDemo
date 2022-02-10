import { Component, Injector } from '@angular/core';
import { StateExclusionGenerated } from './state-exclusion-generated.component';

@Component({
  selector: 'page-state-exclusion',
  templateUrl: './state-exclusion.component.html'
})
export class StateExclusionComponent extends StateExclusionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
