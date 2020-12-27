import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ItemService } from '@proxy/item-management';
import { CategoryDto } from '@proxy/item-management/dto';

@Component({
  selector: 'app-categorySelector',
  templateUrl: './categorySelector.component.html',
  styleUrls: ['./categorySelector.component.scss']
})
export class CategorySelectorComponent implements OnInit {

  static Categories :CategoryDto[] = [];
  categories: CategoryDto[] = [];
  @Input() selectedCategory: number;
  @Output() selectedCategoryChange = new EventEmitter<number>()
  @Input() required: boolean;
  constructor(private _itemService:ItemService) { }

  ngOnInit() {
    if(!CategorySelectorComponent.Categories || !CategorySelectorComponent.Categories.length){
      this._itemService.getCategories().subscribe(result=>{
        this.categories = result.items;
        CategorySelectorComponent.Categories = [...result.items];
      })
    } else {
      this.categories = [...CategorySelectorComponent.Categories];
    }
  }

}
