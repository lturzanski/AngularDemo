import { Component, Injector } from '@angular/core';
import { AddExclusionGenerated } from './add-exclusion-generated.component';

@Component({
  selector: 'page-add-exclusion',
  templateUrl: './add-exclusion.component.html'
})
export class AddExclusionComponent extends AddExclusionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
