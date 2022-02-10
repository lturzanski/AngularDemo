import { Component, Injector } from '@angular/core';
import { StateGenerated } from './state-generated.component';

@Component({
  selector: 'page-state',
  templateUrl: './state.component.html'
})
export class StateComponent extends StateGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
