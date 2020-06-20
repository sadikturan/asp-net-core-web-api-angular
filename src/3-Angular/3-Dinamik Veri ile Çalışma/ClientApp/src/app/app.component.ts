import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'SocialApp';
  
  categoryName = "Telefon";

  products = [
    {id:1,name:"samsung s5",price:2000,isActive:true},
    {id:2,name:"samsung s6",price:3000,isActive:false},
    {id:3,name:"samsung s7",price:4000,isActive:true},
    {id:4,name:"samsung s8",price:5000,isActive:false},
    {id:5,name:"samsung s9",price:6000,isActive:true}
  ];
}
