import { Component, OnInit, ViewChild } from '@angular/core';
import { GetItemsInput, ItemDto } from '@proxy/item-management/dto';
import { PagedResultDto, ListService } from '@abp/ng.core';
import { ModalComponent } from "@abp/ng.theme.shared";
import { ItemService } from '@proxy/item-management';
import { CategorySelectorComponent } from '../shared/categorySelector/categorySelector.component';
import { TenantSelectorComponent } from '../shared/tenant-selector/tenant-selector.component';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss'],
  providers: [ListService],
})
export class ItemComponent implements OnInit {
  items = { items: [], totalCount: 0 } as PagedResultDto<ItemDto>;
  input = { skipCount: 0, maxResultCount: 10 } as GetItemsInput;
  isModalOpen = false;
  isStockModalOpen = false;
  itemDto: ItemDto = {} as ItemDto;
  @ViewChild('form') form: NgForm;
  @ViewChild('sform') sform: NgForm;
  @ViewChild('itemModal') itemModal: ModalComponent;
  @ViewChild('stockModal') stockModal: ModalComponent;
  tenantId:string;
  constructor(public readonly list: ListService, private itemService: ItemService) {}

  ngOnInit() {
    this.tenantId = JSON.parse(localStorage.getItem('id_token_claims_obj')).tenantid;
    console.log(this.tenantId);
    const bookStreamCreator = query => {
      query.tenantId = this.input.tenantId;
      query.categoryId = this.input.categoryId;
      query.searchKeyword = this.input.searchKeyword;
      return this.itemService.getItemsByInput(query);
    };
    this.list.hookToQuery(bookStreamCreator).subscribe(response => {
      this.items = response;
    });
  }

  getCategoryName(id: number) {
    return (CategorySelectorComponent.Categories.find(x => x.id == id) || {}).name;
  }

  getTenantName(id: string) {
    return (TenantSelectorComponent.Tenants.find(x => x.id == id) || {}).name;
  }

  createItem(itemDto?: ItemDto) {
    if(itemDto){
      this.itemDto = itemDto;
    }
    this.isModalOpen = true;
  }

  setStock(itemDto: ItemDto) {
    this.itemDto = itemDto;
    this.isStockModalOpen = true;
  }

  save() {
    this.itemService.createUpdateItemByItemDto(this.itemDto).subscribe(result => {
      this.list.get();
      this.isModalOpen = false;
      this.itemModal.visible = false;
      this.itemDto = {} as ItemDto;
    });
  }

  saveStockCount() {
    this.itemService.setItemStockByInput({itemId:this.itemDto.id, stockCount:this.itemDto.stockCount}).subscribe(result => {
      this.list.get();
      this.isStockModalOpen = false;
      this.stockModal.visible = false;
      this.itemDto = {} as ItemDto;
    });
  }
  delete(id:number){
    let deleteConfirm = confirm("Are you sure want to delete this item?");
    if(deleteConfirm) {
      this.itemService.deleteByItemId(id).subscribe(result=>{
        this.list.get();
      });
    }
  }



  imageChangedEvent: any = '';
  croppedImage: any = '';

  fileChangeEvent(event: any): void {
    this.imageChangedEvent = event;
  }
  imageCropped(event) {
    this.itemDto.photoUrl = event.base64;
  }
  cropperReady() {
    // cropper ready
  }
  loadImageFailed() {
    // show message
  }
}
