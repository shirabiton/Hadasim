import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { City } from '../../../../Models/city';
import { CityService } from '../../../../Services/city.service';

import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-cities',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatRadioModule, MatSelectModule, MatFormFieldModule],
  templateUrl: './cities.component.html',
  styleUrl: './cities.component.css'
})
export class CitiesComponent implements OnInit {
  public citiesList: City[] | null | undefined

  @Input()
  form!: FormGroup

  constructor(private _cityService: CityService) { }

  ngOnInit(): void {
    this._cityService.getAllCities().subscribe({
      next: cities => {
        this.citiesList = cities;
        console.log("Cities Retrieved:", cities);
      },
      error: err => console.error("Error retrieving cities:", err)
    });
  }
}
