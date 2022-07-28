import { Component, OnInit , OnChanges  , Input, ViewChild, Output , EventEmitter, SimpleChanges } from '@angular/core';

import { MatTable } from '@angular/material/table';


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements  OnChanges  {

  @ViewChild(MatTable) myTable! : MatTable<any>;

  @Input() data : any[] = []

  @Output() delete  = new EventEmitter<string>();

  displayedColumns: string[] = ['edit','delete' ,'name','email','phone'];

  constructor() { }

  tableData : any[] = []
  ngOnChanges(changes: SimpleChanges): void {
   
    this.tableData = this.data

  }

  deleteButtonClickHandler(id : string){
      this.delete.emit(id)
  }

}
