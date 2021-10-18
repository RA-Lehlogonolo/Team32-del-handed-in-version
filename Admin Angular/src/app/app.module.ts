import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { DemoNgZorroAntdModule } from './ng-zorro-antd.module';
import { ResidencesComponent } from './pages/residence-management/residences/residences.component';
import { LoginComponent } from './pages/authntication/login/login.component';
import { RoomsComponent } from './pages/residence-management/rooms/rooms.component';
import { AnnouncementsComponent } from './announcements/announcements.component';
import { UserRolesComponent } from './pages/user-management/user-roles/user-roles.component';
import { UsersComponent } from './pages/user-management/users/users.component';
import { DisciplinaryHearingComponent } from './disciplinary-hearing/disciplinary-hearing.component';
import { VisitationApplicationsComponent } from './visitation-applications/visitation-applications.component';
import { MenuTypeComponent } from './menu-type/menu-type.component';
import { MealTypeComponent } from './meal-type/meal-type.component';
import { ItemsComponent } from './items/items.component';
import { ItemTypeComponent } from './item-type/item-type.component';
import { MenuComponent } from './menu/menu.component';
import { EventsComponent } from './events/events.component';
import { EventTypeComponent } from './event-type/event-type.component';
import { ProductComponent } from './product/product.component';
import { ProductTypeComponent } from './product-type/product-type.component';
import { MaintenancerequestTypeComponent } from './maintenancerequest-type/maintenancerequest-type.component';
import { RoomInspectionComponent } from './room-inspection/room-inspection.component';
import { MaintenanceRequestComponent } from './maintenance-request/maintenance-request.component';
import { HealthInspectionResultsComponent } from './health-inspection-results/health-inspection-results.component';
import { OrdersComponent } from './orders/orders.component';
import { HighlightPipe } from './highlight.pipe';
import { HealthInspectionReportComponent } from './health-inspection-report/health-inspection-report.component';
import { SalesReportComponent } from './sales-report/sales-report.component';
import { StockLevelReportComponent } from './stock-level-report/stock-level-report.component';
import { VisitationReportComponent } from './visitation-report/visitation-report.component';
import { DisciplinaryHearingReportComponent } from './disciplinary-hearing-report/disciplinary-hearing-report.component';
import { DaysComponent } from './days/days.component';
import { ProductLevelReportComponent } from './product-level-report/product-level-report.component';
import { RoomInspectionReportComponent } from './room-inspection-report/room-inspection-report.component';
import { MenuRotationComponent } from './menu-rotation/menu-rotation.component';
import { JwtModule } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { ManageHouseParentsComponent } from './pages/user-management/manage-house-parents/manage-house-parents.component';
import { CampusesComponent } from './pages/campus-management/campuses/campuses.component';
import { ResidenceTypesComponent } from './pages/residence-management/residence-types/residence-types.component';
import { FacultiesComponent } from './pages/campus-management/faculties/faculties.component';
import { StudentRolesComponent } from './pages/residence-management/student-roles/student-roles.component';
import { ManageStudentsComponent } from './pages/user-management/manage-students/manage-students.component';
import { ResidenceAllocationAuditLogComponent } from './pages/audit-logs/residence-allocation-audit-log/residence-allocation-audit-log.component';
import { BlockComponent } from './pages/residence-management/block/block.component';
import { AnnouncementTypeComponent } from './announcement-type/announcement-type.component';
import { ManageBuildingCoordinatorComponent } from './pages/user-management/manage-building-coordinator/manage-building-coordinator.component';
import { FreshVillageManagersComponent } from './pages/user-management/fresh-village-managers/fresh-village-managers.component';

registerLocaleData(en);

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    ResidencesComponent,
    RoomsComponent,
    AnnouncementsComponent,
    UserRolesComponent,
    UsersComponent,
    DisciplinaryHearingComponent,
    VisitationApplicationsComponent,
    MenuTypeComponent,
    MealTypeComponent,
    ItemsComponent,
    ItemTypeComponent,
    MenuComponent,
    EventsComponent,
    EventTypeComponent,
    ProductComponent,
    ProductTypeComponent,
    MaintenancerequestTypeComponent,
    RoomInspectionComponent,
    MaintenanceRequestComponent,
    HealthInspectionResultsComponent,
    OrdersComponent,
    HighlightPipe,
    HealthInspectionReportComponent,
    SalesReportComponent,
    StockLevelReportComponent,
    VisitationReportComponent,
    DisciplinaryHearingReportComponent,
    DaysComponent,
    ProductLevelReportComponent,
    RoomInspectionReportComponent,
    MenuRotationComponent,
    LoginComponent,
    ManageHouseParentsComponent,
    CampusesComponent,
    ResidenceTypesComponent,
    FacultiesComponent,
    StudentRolesComponent,
    ManageStudentsComponent,
    ResidenceAllocationAuditLogComponent,
    BlockComponent,
    AnnouncementTypeComponent,
    ManageBuildingCoordinatorComponent,
    FreshVillageManagersComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: [environment.endpointBase.replace("/api/", "")],
      },
    }),
    BrowserAnimationsModule,
    DemoNgZorroAntdModule,
    ReactiveFormsModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }
