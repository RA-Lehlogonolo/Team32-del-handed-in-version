import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzTableModule } from 'ng-zorro-antd/table';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ProfileComponent } from './profile/profile.component';
import { VisitationComponent } from './visitation/visitation.component';
import { DemoNgZorroAntdModule } from './ng-zorro-antd.module';
import { HealthCheckComponent } from './health-check/health-check.component';
import { CompulsoryHealthCheckComponent } from './compulsory-health-check/compulsory-health-check.component';
import { BrowseMerchandiseComponent } from './browse-merchandise/browse-merchandise.component';
import { ViewOrdersComponent } from './view-orders/view-orders.component';
import { ViewMenuComponent } from './view-menu/view-menu.component';
import { ViewEventsComponent } from './view-events/view-events.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import interactionPlugin from '@fullcalendar/interaction'; 
import dayGridPlugin from '@fullcalendar/daygrid';
import listPlugin from '@fullcalendar/list';
import { RoomInspectionComponent } from './room-inspection/room-inspection.component';
import { MaintenanceRequestComponent } from './maintenance-request/maintenance-request.component';
import { MoveOutInspectionComponent } from './move-out-inspection/move-out-inspection.component';


registerLocaleData(en);
FullCalendarModule.registerPlugins([ 
  dayGridPlugin,
  listPlugin,
  interactionPlugin]);


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ResetPasswordComponent,
    ProfileComponent,
    VisitationComponent,
    HealthCheckComponent,
    CompulsoryHealthCheckComponent,
    BrowseMerchandiseComponent,
    ViewOrdersComponent,
    ViewMenuComponent,
    ViewEventsComponent,
    RoomInspectionComponent,
    MaintenanceRequestComponent,
    MoveOutInspectionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzFormModule,
    NzInputModule,
    NzButtonModule,
    NzDividerModule,
    NzDescriptionsModule,
    NzModalModule,
    NzTableModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    DemoNgZorroAntdModule,
    ReactiveFormsModule,
    FullCalendarModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }
