import { Component, Injector } from '@angular/core';
import { EditExclusionGenerated } from './edit-exclusion-generated.component';

@Component({
  selector: 'page-edit-exclusion',
  templateUrl: './edit-exclusion.component.html'
})
export class EditExclusionComponent extends EditExclusionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
