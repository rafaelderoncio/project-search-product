import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ProductSearch } from '../../models/product-search.model';
import { Product } from '../../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  constructor(protected client: HttpClient) { }

  private url: string = 'http://localhost:5000/api/catalog';
  
  search(like: string): Observable<Array<ProductSearch>> {
    const endpoint: string = `${this.url}/product/search?like=${like.trim()}`;
    return this.client.get<Array<ProductSearch>>(endpoint, {headers: {"X-Prod": "true"}}).pipe(
      map((response: Array<ProductSearch>) => response)
    );
  }
  

  getProduct(id: number): Observable<Product> {
    const endpoint: string = `${this.url}/product/${id}`
    return this.client.get<Product>(endpoint).pipe(
      map((response: Product) => response)
    );
  }
}
