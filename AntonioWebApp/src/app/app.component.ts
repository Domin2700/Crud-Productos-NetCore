import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Producto } from './interfaces/producto.interface';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit { 
  productos: Producto[] = [];
  url:string = "http://localhost:5063/api"
  constructor( ) {}




  ngOnInit(): void {

    // this.almacenService.getProductos().subscribe((resp)=> {
    // this.productos = resp });
    // console.log(this.productos);
    console.log("Hola");
    this.getProductos();
  }
  
  getProductos(): void {
    
    
  }

} 
 
