import { Routes } from '@angular/router';
import { HomePageComponent } from './Components/home-page/home-page/home-page.component';


export const routes: Routes = [
    { path: '', component: HomePageComponent },
    { path: 'home', component: HomePageComponent },
    // lazy loading
    { path: 'members-list', loadComponent: () => import('./Components/CRUD/member/members-list/members-list.component').then(c => c.MembersListComponent) },
    { path: 'member-details/:memberId', loadComponent: () => import('./Components/CRUD/member/member-details/member-details.component').then(c => c.MemberDetailsComponent) },
    { path: 'add-member', loadComponent: () => import('./Components/CRUD/member/add-member/add-member/add-member.component').then(c => c.AddMemberComponent) },
    { path: 'update-member/:memberId', loadComponent: () => import('./Components/CRUD/member/update-member/update-member/update-member.component').then(c => c.UpdateMemberComponent) },
    { path: 'corona-vaccines-list', loadComponent: () => import('./Components/CRUD/corona-vaccine/corona-vaccines-list/corona-vaccines-list.component').then(c => c.CoronaVaccinesListComponent) },
    { path: 'add-corona-vaccine/:memberId', loadComponent: () => import('./Components/CRUD/corona-vaccine/add-corona-vaccine/add-corona-vaccine/add-corona-vaccine.component').then(c => c.AddCoronaVaccineComponent) },
    { path: '**', loadComponent: () => import('./Components/page-not-found/page-not-found.component').then(c => c.PageNotFoundComponent) },
];
