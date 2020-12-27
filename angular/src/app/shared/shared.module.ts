import { CoreModule } from '@abp/ng.core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { ThemeBasicModule } from '@abp/ng.theme.basic';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { FormsModule } from '@angular/forms';
import { TenantSelectorComponent } from './tenant-selector/tenant-selector.component';
import { CategorySelectorComponent } from './categorySelector/categorySelector.component';

@NgModule({
  declarations: [
    TenantSelectorComponent,
    CategorySelectorComponent
  ],
  imports: [
    CoreModule,
    ThemeSharedModule,
    ThemeBasicModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    FormsModule
  ],
  exports: [
    CoreModule,
    ThemeSharedModule,
    ThemeBasicModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    TenantSelectorComponent,
    CategorySelectorComponent
  ],
  providers: []
})
export class SharedModule {}
