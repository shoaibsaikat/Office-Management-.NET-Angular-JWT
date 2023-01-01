import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';

import { FormGroup, FormControl } from '@angular/forms';

import { GlobalService } from 'src/app/services/global/global.service';
import { InventoryService } from 'src/app/services/inventory/inventory.service';
import { MessageService } from 'src/app/services/message/message.service';

import { Inventory } from 'src/app/shared/types/inventory';
import { Common } from 'src/app/shared/common';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListComponent implements OnInit {

  inventoryList: Inventory[] = [];
  inventoryFormList: FormGroup[] = [];

  // pagination, NOTE: pagination is by 10 in server side and can't be set from client
  listCount: number = 0;
  currentPage: number = 1;
  totalPage: number = 1;

  constructor(
    private inventoryService: InventoryService,
    private messageService: MessageService,
    private globalService: GlobalService,
    private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.updateInventoryList();
  }

  updateInventoryList(): void {
    this.inventoryService.getInventoryList(this.currentPage).subscribe({
      next: (v) => {
        // console.log('ListComponent: ' + JSON.stringify(v));
        this.inventoryList = [];
        let inventoryList: Inventory[] = JSON.parse(JSON.stringify(v)).inventory_list;
        this.listCount = JSON.parse(JSON.stringify(v)).count;
        this.totalPage = Math.ceil(this.listCount / Common.PAGE_SIZE);

        inventoryList.forEach(element => {
          if (element) {
            let inventory: Inventory = {
              id: element.id,
              name: element.name,
              unit: element.unit,
              count: element.count
            }
            this.inventoryList.push(inventory);
            // console.log('AllListComponent: id:' + inventory.id + ', count:' + inventory.count);
          }
        });

        // generate form groups
        this.inventoryFormList = [];
        this.inventoryList.forEach(element => {
          this.inventoryFormList.push(new FormGroup({
            count: new FormControl(),
          }));
        });
        // set inventory count to form
        this.inventoryFormList.forEach((element, i) => {
          element.get('count')?.setValue(this.inventoryList[i].count);
        });
      },
      error: (e) => {
        // console.error(e);
        this.globalService.handleUnauthorizedAccess(e);
      },
      complete: () => {
        this.changeDetectorRef.markForCheck();
      }
    });
  }

  onSubmit(index: number): void {
    // console.log('ListComponent: index: ' + index + ': ' + this.inventoryFormList[index].get('count')?.value);
    this.inventoryService.inventoryQuickUpdate(this.inventoryList[index].id, this.inventoryFormList[index].get('count')?.value).subscribe(data => {
      let msg = JSON.parse(JSON.stringify(data));
      this.messageService.add(msg.text);
      // console.log(msg);
      // update local data
      this.inventoryList[index].count = this.inventoryFormList[index].get('count')?.value;
    });
  }

  checkInventoryCount(index: number): boolean {
    return false ? this.inventoryFormList[index].get('count')?.value >= 0 : true;
  }

  getPageSize(): number {
    return Common.PAGE_SIZE;
  }

  onClick(item: Inventory): void {
    this.inventoryService.setCurrentInventory(item);
    this.globalService.navigate('inventory/edit');
  }

  onFirstClick(): void {
    this.currentPage = 1;
    this.updateInventoryList();
  }

  onLastClick(): void {
    this.currentPage = this.totalPage;
    this.updateInventoryList();
  }

  onPreviousClick(): void {
    --this.currentPage;
    this.updateInventoryList();
  }

  onNextClick(): void {
    ++this.currentPage;
    this.updateInventoryList();
  }

  hasNextPage(): boolean {
    return !(this.currentPage >= this.totalPage);
  }

  hasPreviousPage(): boolean {
    return (this.currentPage * Common.PAGE_SIZE > Common.PAGE_SIZE);
  }

}
