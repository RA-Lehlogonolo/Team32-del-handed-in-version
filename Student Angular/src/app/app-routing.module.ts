import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { BrowseMerchandiseComponent } from './browse-merchandise/browse-merchandise.component';
import { CompulsoryHealthCheckComponent } from './compulsory-health-check/compulsory-health-check.component';
import { HealthCheckComponent } from './health-check/health-check.component';
import { LoginComponent } from './login/login.component';
import { MaintenanceRequestComponent } from './maintenance-request/maintenance-request.component';
import { MoveOutInspectionComponent } from './move-out-inspection/move-out-inspection.component';
import { ProfileComponent } from './profile/profile.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { RoomInspectionComponent } from './room-inspection/room-inspection.component';
import { ViewEventsComponent } from './view-events/view-events.component';
import { ViewMenuComponent } from './view-menu/view-menu.component';
import { ViewOrdersComponent } from './view-orders/view-orders.component';
import { VisitationComponent } from './visitation/visitation.component';

const routes: Routes = [
  
 { path: 'login',component:LoginComponent},
 { path: '', pathMatch: 'full', redirectTo: '/login' },

 { path: 'reset-password',component:ResetPasswordComponent},
 { path: 'profile',component:ProfileComponent},
 { path: 'visitation',component:VisitationComponent},
 { path: 'browse-merchandise',component:BrowseMerchandiseComponent},
 { path: 'view-orders',component:ViewOrdersComponent},
 { path: 'view-menu',component:ViewMenuComponent},
 { path: 'home',component:ViewEventsComponent},
 { path: 'weekly-health-check',component:HealthCheckComponent},
 { path: 'compulsory-health-check',component:CompulsoryHealthCheckComponent},
 { path: 'maintenance-request',component:MaintenanceRequestComponent},
 { path: 'move-out-inspection',component:MoveOutInspectionComponent},
 { path: 'move-in-inspection',component:RoomInspectionComponent},




];

@NgModule({
  imports: [RouterModule.forRoot(routes),BrowserModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
