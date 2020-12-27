import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MarketRoutingModule } from './market-routing.module';
import { MarketComponent } from './market.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [MarketComponent],
  imports: [
    SharedModule,
    MarketRoutingModule
  ]
})
export class MarketModule { }
