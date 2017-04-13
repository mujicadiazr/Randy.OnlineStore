import {Component} from "@angular/core";

@Component({ selector: "my-app", template: "<h1>{{welcomeMessage}}</h1>" })
export class AppComponent {
    welcomeMessage: string = "Welcome to Angular 2 ASP.NET MVC 5 project"; 
}
