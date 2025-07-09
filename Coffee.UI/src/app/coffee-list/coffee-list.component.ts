import { Component, OnInit } from '@angular/core';
import { CoffeeService } from '../services/coffee.service';
import { Record } from '../models/record';
import { CommonModule, DatePipe } from '@angular/common';

@Component({
  selector: 'app-coffee-list',
  imports: [CommonModule, DatePipe],
  templateUrl: './coffee-list.component.html',
  styleUrl: './coffee-list.component.css',
})
export class CoffeeListComponent implements OnInit {
  records: Record[] = [];
  constructor(private coffeeService: CoffeeService) {}
  ngOnInit(): void {
    this.getAllRecords();
  }

  getAllRecords() {
    this.coffeeService.getRecords().subscribe((data) => {
      this.records = data as Record[];
      console.log(this.records);
    });
  }
}
