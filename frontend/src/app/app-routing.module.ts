import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RefreshComponent } from "./components/refresh/refresh.component";
import { AuthGuard } from "./modules/account/guards/auth.guard";
import { PageNotFoundComponent } from "./modules/errors/components/page-not-found/page-not-found.component";

const routes: Routes = [
  {
    path: '',
    redirectTo: '/products/list',
    pathMatch: 'full'
  },
  {
    path: 'account',
    loadChildren: () => import('./modules/account/account.module').then(m => m.AccountModule)
  },
  {
    path: 'ingredients',
    loadChildren: () => import('./modules/ingredients/ingredients.module').then(m => m.IngredientsModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'users',
    loadChildren: () => import('./modules/users/users.module').then(m => m.UsersModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'errors',
    loadChildren: () => import('./modules/errors/errors.module').then(m => m.ErrorsModule)
  },
  { path: 'refresh', component: RefreshComponent },
  {
    path: '**', pathMatch: 'full',
    component: PageNotFoundComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    onSameUrlNavigation: 'reload'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
