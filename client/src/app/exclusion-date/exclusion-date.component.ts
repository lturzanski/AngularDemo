import { Component, Injector } from '@angular/core';
import { ExclusionDateGenerated } from './exclusion-date-generated.component';

@Component({
  selector: 'page-exclusion-date',
  templateUrl: './exclusion-date.component.html'
})
export class ExclusionDateComponent extends ExclusionDateGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
