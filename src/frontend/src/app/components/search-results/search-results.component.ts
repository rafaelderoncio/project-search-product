import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductSearch } from '../../core/models/product-search.model';
import { CatalogService } from '../../core/services/catalog/catalog.service';
import { Product } from '../../core/models/product.model';

@Component({
  standalone: false,
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrl: './search-results.component.css'
})
export class SearchResultsComponent {

  constructor(protected service: CatalogService) { }

  @Input()
  results: Array<ProductSearch> = [];

  @Output()
  productSelected: EventEmitter<ProductSearch> = new EventEmitter<ProductSearch>();

  public productEventEmit(product: ProductSearch) {
    this.productSelected.emit(product)
  }
}
