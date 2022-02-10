import { Component, Injector } from '@angular/core';
import { AddStateGenerated } from './add-state-generated.component';

@Component({
  selector: 'page-add-state',
  templateUrl: './add-state.component.html'
})
export class AddStateComponent extends AddStateGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
