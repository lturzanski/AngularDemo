import { Component, Injector } from '@angular/core';
import { StateExclusionTableGenerated } from './state-exclusion-table-generated.component';

@Component({
  selector: 'page-state-exclusion-table',
  templateUrl: './state-exclusion-table.component.html'
})
export class StateExclusionTableComponent extends StateExclusionTableGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
