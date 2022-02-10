import { Component, Injector } from '@angular/core';
import { EditStateGenerated } from './edit-state-generated.component';

@Component({
  selector: 'page-edit-state',
  templateUrl: './edit-state.component.html'
})
export class EditStateComponent extends EditStateGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
