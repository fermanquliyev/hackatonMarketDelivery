import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ItemRoutingModule } from './item-routing.module';
import { ItemComponent } from './item.component';
import { SharedModule } from '../shared/shared.module';
import { ImageCropperModule } from 'ngx-image-cropper';

@NgModule({
  declarations: [ItemComponent],
  imports: [
    ItemRoutingModule,
    SharedModule,
    ImageCropperModule
  ]
})
export class ItemModule { }
