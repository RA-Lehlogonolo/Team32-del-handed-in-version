import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnnouncementsComponent } from './announcements/announcements.component';
import { DaysComponent } from './days/days.component';
import { DisciplinaryHearingReportComponent } from './disciplinary-hearing-report/disciplinary-hearing-report.component';
import { DisciplinaryHearingComponent } from './disciplinary-hearing/disciplinary-hearing.component';
import { EventTypeComponent } from './event-type/event-type.component';
import { EventsComponent } from './events/events.component';
import { HealthInspectionReportComponent } from './health-inspection-report/health-inspection-report.component';
import { HealthInspectionResultsComponent } from './health-inspection-results/health-inspection-results.component';
import { ItemTypeComponent } from './item-type/item-type.component';
import { ItemsComponent } from './items/items.component';
import { LoginComponent } from './pages/authntication/login/login.component';
import { MaintenancerequestTypeComponent } from './maintenancerequest-type/maintenancerequest-type.component';
import { MealTypeComponent } from './meal-type/meal-type.component';
import { MenuRotationComponent } from './menu-rotation/menu-rotation.component';
import { MenuTypeComponent } from './menu-type/menu-type.component';
import { MenuComponent } from './menu/menu.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductLevelReportComponent } from './product-level-report/product-level-report.component';
import { ProductTypeComponent } from './product-type/product-type.component';
import { ProductComponent } from './product/product.component';
import { ResidencesComponent } from './pages/residence-management/residences/residences.component';
import { RoomInspectionReportComponent } from './room-inspection-report/room-inspection-report.component';
import { RoomInspectionComponent } from './room-inspection/room-inspection.component';
import { RoomsComponent } from './pages/residence-management/rooms/rooms.component';
import { SalesReportComponent } from './sales-report/sales-report.component';
import { StockLevelReportComponent } from './stock-level-report/stock-level-report.component';
import { UserRolesComponent } from './pages/user-management/user-roles/user-roles.component';
import { UsersComponent } from './pages/user-management/users/users.component';
import { VisitationApplicationsComponent } from './visitation-applications/visitation-applications.component';
import { VisitationReportComponent } from './visitation-report/visitation-report.component';
import { ManageHouseParentsComponent } from './pages/user-management/manage-house-parents/manage-house-parents.component';
import { CampusesComponent } from './pages/campus-management/campuses/campuses.component';
import { ResidenceTypesComponent } from './pages/residence-management/residence-types/residence-types.component';
import { FacultiesComponent } from './pages/campus-management/faculties/faculties.component';
import { StudentRolesComponent } from './pages/residence-management/student-roles/student-roles.component';
import { ManageStudentsComponent } from './pages/user-management/manage-students/manage-students.component';
import { ResidenceManagementService } from './services/residence-management/residence-management.service';
import {AnnouncementService} from './services/announcement/announcement.service';
import { ResidenceAllocationAuditLogComponent } from './pages/audit-logs/residence-allocation-audit-log/residence-allocation-audit-log.component';
import { BlockComponent } from './pages/residence-management/block/block.component';
import { ManageBuildingCoordinatorComponent } from './pages/user-management/manage-building-coordinator/manage-building-coordinator.component';
import { AnnouncementTypeComponent } from './announcement-type/announcement-type.component';
const routes: Routes = [


  { path: 'visitation-applications', component: VisitationApplicationsComponent },
  { path: 'meal-type', component: MealTypeComponent },
  { path: 'menu-type', component: MenuTypeComponent },
  { path: 'event-type', component: EventTypeComponent },
  { path: 'product-type', component: ProductTypeComponent },
  { path: 'event', component: EventsComponent },
  { path: 'product', component: ProductComponent },
  { path: 'product-type', component: MenuTypeComponent },
  { path: 'maintenancerequest-type', component: MaintenancerequestTypeComponent },
  { path: 'room-inspection', component: RoomInspectionComponent },
  { path: 'menu-type', component: MenuTypeComponent },
  { path: 'menu', component: MenuComponent },
  { path: 'items', component: ItemsComponent },
  { path: 'item-type', component: ItemTypeComponent },
  { path: 'disciplinary-hearing', component: DisciplinaryHearingComponent },
  { path: 'announcements', component: AnnouncementsComponent },
  { path: 'announcementtype', component: AnnouncementTypeComponent },
  { path: 'health-inspection-results', component: HealthInspectionResultsComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'health-inspection-report', component: HealthInspectionReportComponent },
  { path: 'sales-report', component: SalesReportComponent },
  { path: 'stock-level-report', component: StockLevelReportComponent },
  { path: 'visitation-report', component: VisitationReportComponent },
  { path: 'disciplinary-hearing-report', component: DisciplinaryHearingReportComponent },
  { path: 'days', component: DaysComponent },
  { path: 'product-level-report', component: ProductLevelReportComponent },
  { path: 'room-inspection-report', component: RoomInspectionReportComponent },
  { path: 'menu-rotation', component: MenuRotationComponent },

  { path: 'users', component: UsersComponent },
  { path: 'user-management/house-parents', component: ManageHouseParentsComponent },
  { path: 'user-management/building-coordinators', component: ManageBuildingCoordinatorComponent },
  { path: 'user-management/students', component: ManageStudentsComponent },
  { path: 'user-management/user-roles', component: UserRolesComponent },



  { path: 'campus-management/campuses', component: CampusesComponent },
  { path: 'campus-management/faculties', component: FacultiesComponent },


  { path: 'residence-management/residences', component: ResidencesComponent },
  { path: 'residence-management/block', component: BlockComponent },
  { path: 'residence-management/rooms', component: RoomsComponent },
  { path: 'residence-management/residence-types', component: ResidenceTypesComponent },
  { path: 'residence-management/student-roles', component: StudentRolesComponent },


  { path: 'audit-logs/residences-allocation', component: ResidenceAllocationAuditLogComponent },




  { path: 'login', component: LoginComponent },
  { path: '', pathMatch: 'full', redirectTo: '/login' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
