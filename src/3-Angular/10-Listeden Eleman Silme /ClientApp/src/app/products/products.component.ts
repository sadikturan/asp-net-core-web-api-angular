import { Component, OnInit } from '@angular/core';
import { Model, Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  selectedProduct: Product;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  getProducts(): Product[] {
    return this.productService.getProducts();
  }

  onSelectProduct(product: Product) {
    this.selectedProduct = product;
  }

  deleteProduct(product: Product) {
    this.productService.deleteProduct(product);
  }

 

}
