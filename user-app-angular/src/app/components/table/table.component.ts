import { Component, OnInit , Input, ViewChild } from '@angular/core';

import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  @ViewChild(MatTable) myTable! : MatTable<any>;

  @Input() data : any[] = []

  displayedColumns: string[] = ['edit','delete' ,'name','email','phone'];

  constructor() { }

  tableData : any[] = []
  ngOnInit(): void {

   
    this.tableData = this.data
   
  
  }

}
