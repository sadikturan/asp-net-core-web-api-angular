export class Model {
    products: Array<Product>;

    constructor(){
        // this.products = [
        //     new Product(1,"samsung s5",2000,false),
        //     new Product(2,"samsung s6",3000,false),
        //     new Product(3,"samsung s7",4000,true),
        //     new Product(4,"samsung s8",5000,true),
        //     new Product(5,"samsung s9",6000,true),
        //     new Product(6,"samsung s10",7000,true)
        // ];
    }
}

export class Product {
    productId: number;
    name: string;
    price : number;
    isActive: boolean;

    constructor(productId: number,name: string,price: number,isActive:boolean) {
        this.productId = productId;
        this.name = name;
        this.price = price;
        this.isActive = isActive;
    }
}

