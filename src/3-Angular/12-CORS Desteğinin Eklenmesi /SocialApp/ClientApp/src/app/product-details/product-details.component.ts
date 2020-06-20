import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  @Input() product: Product;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  addProduct(id: number, name: string,price: number,isactive: boolean)
  {
    const p = new Product(id,name,price,isactive);
    this.productService.saveProduct(p);
    this.product = null;
  }

}
