import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { RouterOutlet } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { SearchResultsComponent } from './components/search-results/search-results.component';

const APP_COMPONENTS: any[] = [
  AppComponent,
  SearchBarComponent,
  SearchResultsComponent,
  ProductCardComponent
]

const APP_IMPORTS: any[] = [
  CommonModule,
  RouterOutlet,
  BrowserModule,
  FormsModule
]

const APP_PROVIDERS: any[] = [
  provideHttpClient(withInterceptorsFromDi())
]

@NgModule({
  declarations: APP_COMPONENTS,
  imports: APP_IMPORTS,
  providers: APP_PROVIDERS,
  bootstrap: [AppComponent]
})
export class AppModule { }
