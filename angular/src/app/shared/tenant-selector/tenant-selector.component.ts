import { TenantDto, TenantManagementService, TenantService } from '@abp/ng.tenant-management';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-tenant-selector',
  templateUrl: './tenant-selector.component.html',
  styleUrls: ['./tenant-selector.component.scss']
})
export class TenantSelectorComponent implements OnInit {

  static Tenants :TenantDto[] = [];
  tenants: TenantDto[] = [];
  @Input() selectedTenant: string;
  @Output() selectedTenantChange = new EventEmitter<string>()
  @Input() required: boolean;
  constructor(private _tenantService:TenantService) { }

  ngOnInit() {
    this._tenantService.getList({skipCount:0,maxResultCount:1000} as any).subscribe(result=>{
      this.tenants = result.items;
      TenantSelectorComponent.Tenants = [...result.items];
    })
  }

}
