import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login/login-form.component';
import { FileListComponent } from './file-list/file-list.component';
import { UploadFormComponent } from './upload-form/upload-form.component';
import { AuthInterceptor } from './auth.interceptor';

const routes: Routes = [
  { path: 'login', component: LoginFormComponent },
  { path: '', component: FileListComponent }
];

@NgModule({
  declarations: [AppComponent, LoginFormComponent, FileListComponent, UploadFormComponent],
  imports: [BrowserModule, HttpClientModule, FormsModule, RouterModule.forRoot(routes)],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
