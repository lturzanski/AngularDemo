import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { ExclusionComponent } from './exclusion/exclusion.component';
import { AddExclusionComponent } from './add-exclusion/add-exclusion.component';
import { EditExclusionComponent } from './edit-exclusion/edit-exclusion.component';
import { StateComponent } from './state/state.component';
import { AddStateComponent } from './add-state/add-state.component';
import { EditStateComponent } from './edit-state/edit-state.component';
import { ExclusionDateComponent } from './exclusion-date/exclusion-date.component';
import { AddExclusionDateComponent } from './add-exclusion-date/add-exclusion-date.component';
import { EditExclusionDateComponent } from './edit-exclusion-date/edit-exclusion-date.component';
import { StateExclusionTableComponent } from './state-exclusion-table/state-exclusion-table.component';
import { StateExclusionComponent } from './state-exclusion/state-exclusion.component';
import { AddStateExclusionComponent } from './add-state-exclusion/add-state-exclusion.component';
import { EditStateExclusionComponent } from './edit-state-exclusion/edit-state-exclusion.component';

export const routes: Routes = [
  { path: '', redirectTo: '/exclusion', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'exclusion',
        component: ExclusionComponent
      },
      {
        path: 'add-exclusion',
        component: AddExclusionComponent
      },
      {
        path: 'edit-exclusion/:Id',
        component: EditExclusionComponent
      },
      {
        path: 'state',
        component: StateComponent
      },
      {
        path: 'add-state',
        component: AddStateComponent
      },
      {
        path: 'edit-state/:Id',
        component: EditStateComponent
      },
      {
        path: 'exclusion-date',
        component: ExclusionDateComponent
      },
      {
        path: 'add-exclusion-date',
        component: AddExclusionDateComponent
      },
      {
        path: 'edit-exclusion-date/:Id',
        component: EditExclusionDateComponent
      },
      {
        path: 'state-exclusion-table',
        component: StateExclusionTableComponent
      },
      {
        path: 'state-exclusion',
        component: StateExclusionComponent
      },
      {
        path: 'add-state-exclusion',
        component: AddStateExclusionComponent
      },
      {
        path: 'edit-state-exclusion/:Id',
        component: EditStateExclusionComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
