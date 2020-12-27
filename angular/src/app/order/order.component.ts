import { GetOrdersInput, OrderDto, OrderService } from '@proxy/order-management';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PagedResultDto, ListService } from '@abp/ng.core';
import { ModalComponent } from "@abp/ng.theme.shared";
import { TenantSelectorComponent } from '../shared/tenant-selector/tenant-selector.component';
@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss'],
  providers: [ListService]
})
export class OrderComponent implements OnInit {

  items = { items: [], totalCount: 0 } as PagedResultDto<OrderDto>;
  input = { skipCount: 0, maxResultCount: 10 } as GetOrdersInput;
  isModalOpen = false;
  orderDto: OrderDto = {} as OrderDto;
  @ViewChild('orderModal') orderModal: ModalComponent;
  tenantId:string;
  constructor(public readonly list: ListService, private itemService: OrderService) {}

  ngOnInit() {
    this.tenantId = JSON.parse(localStorage.getItem('id_token_claims_obj')).tenantid;
    console.log(this.tenantId);
    const bookStreamCreator = query => {
      query.tenantId = this.input.tenantId;
      return this.itemService.getOrdersByInput(query);
    };
    this.list.hookToQuery(bookStreamCreator).subscribe(response => {
      this.items = response;
    });
  }

  details(orderDto) {
    this.orderDto = orderDto;
    this.isModalOpen = true;
  }

  updateStatus(id){
    this.itemService.updateOrderStatusById(id).subscribe(result=>{
      this.list.get();
      alert("Status updated sucessfully");
    })
  }

  giveToDeliver(id){
    let userName = prompt("Kuryerin istifadəçi adını yazın:");
    this.itemService.giveOrderForDeliveringByIdAndDeliveryUserName(id,userName).subscribe(result=>{
      this.list.get();
    });
  }
  getTenantName(id: string) {
    return (TenantSelectorComponent.Tenants.find(x => x.id == id) || {}).name;
  }
}
