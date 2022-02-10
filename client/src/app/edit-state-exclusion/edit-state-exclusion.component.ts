import { Component, Injector } from '@angular/core';
import { EditStateExclusionGenerated } from './edit-state-exclusion-generated.component';

@Component({
  selector: 'page-edit-state-exclusion',
  templateUrl: './edit-state-exclusion.component.html'
})
export class EditStateExclusionComponent extends EditStateExclusionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
