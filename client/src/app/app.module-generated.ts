/*
  This file is automatically generated. Any changes will be overwritten.
  Modify app.module.ts instead.
*/
import { APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BodyModule } from '@radzen/angular/dist/body';
import { CardModule } from '@radzen/angular/dist/card';
import { ContentContainerModule } from '@radzen/angular/dist/content-container';
import { HeaderModule } from '@radzen/angular/dist/header';
import { SidebarToggleModule } from '@radzen/angular/dist/sidebar-toggle';
import { LabelModule } from '@radzen/angular/dist/label';
import { SidebarModule } from '@radzen/angular/dist/sidebar';
import { PanelMenuModule } from '@radzen/angular/dist/panelmenu';
import { FooterModule } from '@radzen/angular/dist/footer';
import { ContentModule } from '@radzen/angular/dist/content';
import { HeadingModule } from '@radzen/angular/dist/heading';
import { GridModule } from '@radzen/angular/dist/grid';
import { FormModule } from '@radzen/angular/dist/form';
import { SharedModule } from '@radzen/angular/dist/shared';
import { NotificationModule } from '@radzen/angular/dist/notification';
import { DialogModule } from '@radzen/angular/dist/dialog';

import { ConfigService, configServiceFactory } from './config.service';
import { AppRoutes } from './app.routes';
import { AppComponent } from './app.component';
import { CacheInterceptor } from './cache.interceptor';
export { AppComponent } from './app.component';
import { StateExclusionViewComponent } from './state-exclusion-view/state-exclusion-view.component';
import { StateComponent } from './state/state.component';
import { AddStateComponent } from './add-state/add-state.component';
import { EditStateComponent } from './edit-state/edit-state.component';
import { ExclusionComponent } from './exclusion/exclusion.component';
import { AddExclusionComponent } from './add-exclusion/add-exclusion.component';
import { EditExclusionComponent } from './edit-exclusion/edit-exclusion.component';
import { ExclusionDateComponent } from './exclusion-date/exclusion-date.component';
import { AddExclusionDateComponent } from './add-exclusion-date/add-exclusion-date.component';
import { EditExclusionDateComponent } from './edit-exclusion-date/edit-exclusion-date.component';
import { StateExclusionComponent } from './state-exclusion/state-exclusion.component';
import { AddStateExclusionComponent } from './add-state-exclusion/add-state-exclusion.component';
import { EditStateExclusionComponent } from './edit-state-exclusion/edit-state-exclusion.component';
import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';

import { StateExclusionsDatabaseService } from './state-exclusions-database.service';

export const PageDeclarations = [
  StateExclusionViewComponent,
  StateComponent,
  AddStateComponent,
  EditStateComponent,
  ExclusionComponent,
  AddExclusionComponent,
  EditExclusionComponent,
  ExclusionDateComponent,
  AddExclusionDateComponent,
  EditExclusionDateComponent,
  StateExclusionComponent,
  AddStateExclusionComponent,
  EditStateExclusionComponent,
];

export const LayoutDeclarations = [
  LoginLayoutComponent,
  MainLayoutComponent,
];

export const AppDeclarations = [
  ...PageDeclarations,
  ...LayoutDeclarations,
  AppComponent
];

export const AppProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: CacheInterceptor,
    multi: true
  },
  StateExclusionsDatabaseService,
  ConfigService,
  {
    provide: APP_INITIALIZER,
    useFactory: configServiceFactory,
    deps: [ConfigService],
    multi: true
  }
];

export const AppImports = [
  BrowserModule,
  BrowserAnimationsModule,
  FormsModule,
  HttpClientModule,
  BodyModule,
  CardModule,
  ContentContainerModule,
  HeaderModule,
  SidebarToggleModule,
  LabelModule,
  SidebarModule,
  PanelMenuModule,
  FooterModule,
  ContentModule,
  HeadingModule,
  GridModule,
  FormModule,
  SharedModule,
  NotificationModule,
  DialogModule,
  AppRoutes
];
