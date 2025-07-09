import { Component, OnInit } from '@angular/core';
import { CoffeeService } from '../services/coffee.service';
import { Record } from '../models/record';

@Component({
  selector: 'app-coffee-list',
  imports: [],
  templateUrl: './coffee-list.component.html',
  styleUrl: './coffee-list.component.css',
})
export class CoffeeListComponent implements OnInit {
  records: Record[] = [];
  constructor(private coffeeService: CoffeeService) {}
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  getAllRecords() {
    this.coffeeService.getRecords().subscribe((data) => {
      this.records = data as Record[];
    });
  }
}
