import { Category } from "./category.model";

export interface Product {
    id: number;
    name: string;
    description: string;
    brand: string;
    model: string;
    price: number;
    stock: number;
    image: string;
    category: Category;
}2