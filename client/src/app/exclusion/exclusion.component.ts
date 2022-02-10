import { Component, Injector } from '@angular/core';
import { ExclusionGenerated } from './exclusion-generated.component';

@Component({
  selector: 'page-exclusion',
  templateUrl: './exclusion.component.html'
})
export class ExclusionComponent extends ExclusionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
