import { Component, Input, OnInit } from '@angular/core';
import { Manufacturer } from '../../../../../Models/manufacturer';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ManufacturerService } from '../../../../../Services/manufacturer.service';
import { CommonModule } from '@angular/common';

import {MatRadioModule} from '@angular/material/radio';

@Component({
  selector: 'app-manufacturers',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatRadioModule],
  templateUrl: './manufacturers.component.html',
  styleUrl: './manufacturers.component.css'
})
export class ManufacturersComponent implements OnInit {
  public manufacturersList: Manufacturer[] | null | undefined

  @Input()
  form!: FormGroup

  constructor(private _manufacturerService: ManufacturerService) { }

  ngOnInit(): void {
    this._manufacturerService.getAllManufacturers().subscribe({
      next: manufacturers => {
        this.manufacturersList = manufacturers;
        console.log("Manufacturers Retrieved:", manufacturers);
      },
      error: err => console.error("Error retrieving manufacturers:", err)
    });
  }
}
