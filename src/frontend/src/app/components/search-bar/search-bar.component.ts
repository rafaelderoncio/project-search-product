import { Component, Input } from '@angular/core';
import { CatalogService } from '../../core/services/catalog/catalog.service';
import { ProductSearch } from '../../core/models/product-search.model';
import { Product } from '../../core/models/product.model';

@Component({
  standalone: false,
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css'
})
export class SearchBarComponent {

  constructor(protected service: CatalogService) { }

  @Input()
  public like: string = '';
  public products: Array<ProductSearch> = [];
  public productSelected: ProductSearch | null = null;
  public product: Product | null = null;

  public searchProduct(): void {
    this.service.search(this.like).subscribe({
        next: (response: Array<ProductSearch>) => { this.products = response.slice(0, 10); },
        error: (error: any) => { console.error(error); },
        complete: () => { }
      }
    );
  }

  public getProduct() {
    if (this.productSelected) {
      this.service.getProduct(this.productSelected.id).subscribe({
        next: (response: Product) => { this.product = response },
        error: (error: any) => console.log(error),        
      })
    }
  }

  public onInputChange(event: Event): void {
    this.product = null;
    this.like = (event.target as HTMLInputElement).value;

    if (this.like.length > 0) {
      this.searchProduct();
    } else {
      this.products = [];
    }
  }

  public onProductSelected(product: ProductSearch) {
    if (product != null) {
      this.products = [];
      this.like = product.name; 
      this.productSelected = product; 
    }
  }
}
