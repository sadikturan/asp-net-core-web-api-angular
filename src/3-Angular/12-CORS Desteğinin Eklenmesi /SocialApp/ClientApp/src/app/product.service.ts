import { Injectable } from '@angular/core';
import { Model, Product } from './Model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl: string = "http://localhost:5000/";
  model = new Model();

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'api/products');
  }

  getProductById(id: number) {
    return this.model.products.find(i=>i.productId==id);
  }

  saveProduct(product: Product) {
    if(product.productId==0)
    {
      this.model.products.push(product);
    }
    else {
      const p = this.getProductById(product.productId);
      p.name = product.name;
      p.price = product.price;
      p.isActive = product.isActive;
    }
  }

  deleteProduct(product: Product) {
    this.model.products = this.model.products.filter(p=>p!==product);
  }
}
