import { GetMarketsInput, MarketDto, MarketService } from '@proxy/market-management';
import { TenantSelectorComponent } from '../shared/tenant-selector/tenant-selector.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PagedResultDto, ListService } from '@abp/ng.core';
import { ModalComponent } from "@abp/ng.theme.shared";
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  styleUrls: ['./market.component.scss'],
  providers: [ListService]
})
export class MarketComponent implements OnInit {

  items = { items: [], totalCount: 0 } as PagedResultDto<MarketDto>;
  input = { skipCount: 0, maxResultCount: 10 } as GetMarketsInput;
  isModalOpen = false;
  isStockModalOpen = false;
  itemDto: MarketDto = {} as MarketDto;
  @ViewChild('form') form: NgForm;
  @ViewChild('itemModal') itemModal: ModalComponent;
  tenantId:string;
  constructor(public readonly list: ListService, private itemService: MarketService) {}

  ngOnInit() {
    this.tenantId = JSON.parse(localStorage.getItem('id_token_claims_obj')).tenantid;
    console.log(this.tenantId);
    const bookStreamCreator = query => {
      query.tenantId = this.input.tenantId;
      return this.itemService.getMarketsByInput(query);
    };
    this.list.hookToQuery(bookStreamCreator).subscribe(response => {
      this.items = response;
    });
  }

  getTenantName(id: string) {
    return (TenantSelectorComponent.Tenants.find(x => x.id == id) || {}).name;
  }

  createItem(itemDto?: MarketDto) {
    if(itemDto){
      this.itemDto = itemDto;
    }
    this.isModalOpen = true;
  }

  save() {
    this.itemService.createUpdateMarketByMarketDto(this.itemDto).subscribe(() => {
      this.list.get();
      this.isModalOpen = false;
      this.itemModal.visible = false;
      this.itemDto = {} as MarketDto;
    });
  }
  delete(id:number){
    let deleteConfirm = confirm("Are you sure want to delete this item?");
    if(deleteConfirm) {
      this.itemService.deleteMarketById(id).subscribe(()=>{
        this.list.get();
      });
    }
  }

}
