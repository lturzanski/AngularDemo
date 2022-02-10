import { Component, Injector } from '@angular/core';
import { AddStateExclusionGenerated } from './add-state-exclusion-generated.component';

@Component({
  selector: 'page-add-state-exclusion',
  templateUrl: './add-state-exclusion.component.html'
})
export class AddStateExclusionComponent extends AddStateExclusionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
