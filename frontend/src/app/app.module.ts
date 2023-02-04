import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from "@angular/material/toolbar";
import {ToastrModule} from "ngx-toastr";
import {JwtModule} from "@auth0/angular-jwt";
import { RefreshComponent } from './components/refresh/refresh.component';
import {MatIconModule} from "@angular/material/icon";
import {MatChipsModule} from "@angular/material/chips";
import {MatRadioModule} from "@angular/material/radio";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {AccountModule} from "./modules/account/account.module";
import { MatButtonModule } from "@angular/material/button";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { IngredientsModule } from "./modules/ingredients/ingredients.module";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { ErrorDirective } from './modules/account/directives/error.directive';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
    declarations: [
        AppComponent,
        RefreshComponent,
    ],
    imports: [
        // Internal modules
        AccountModule,
        IngredientsModule,
        // External modules
        AppRoutingModule,
        ToastrModule.forRoot(),
        HttpClientModule,
        JwtModule.forRoot({
            config: {
                tokenGetter,
                allowedDomains: ["localhost:4300", "localhost:4200","localhost:5001", "localhost:5000"]
            }
        }),
        MatIconModule,
        FormsModule,
        MatChipsModule,
        MatRadioModule,
        MatCheckboxModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatDialogModule
    ],
    providers: [
        {
            provide: MatDialogRef,
            useValue: {}
        },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
