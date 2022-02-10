import { Component, Injector } from '@angular/core';
import { EditExclusionDateGenerated } from './edit-exclusion-date-generated.component';

@Component({
  selector: 'page-edit-exclusion-date',
  templateUrl: './edit-exclusion-date.component.html'
})
export class EditExclusionDateComponent extends EditExclusionDateGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
