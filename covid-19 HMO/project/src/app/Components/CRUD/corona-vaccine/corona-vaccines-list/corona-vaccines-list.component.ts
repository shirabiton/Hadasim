import { Component, OnInit, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CoronaVaccine } from '../../../../Models/corona-vaccine';
import { CoronaVaccineService } from '../../../../Services/corona-vaccine.service';
import { Manufacturer } from '../../../../Models/manufacturer';
import { ManufacturerService } from '../../../../Services/manufacturer.service';

import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-corona-vaccines-list',
  standalone: true,
  imports: [CommonModule, FormsModule,
  MatListModule],
  templateUrl: './corona-vaccines-list.component.html',
  styleUrl: './corona-vaccines-list.component.css'
})

export class CoronaVaccinesListComponent implements OnInit {

  public filteredCoronaVaccinesList: CoronaVaccine[] = [];
  public manufacturers: Manufacturer[] = [];

  @Input() memberId!: number;

  constructor(
    private _coronaVaccineService: CoronaVaccineService,
    private _manufacturerService: ManufacturerService) { }

  ngOnInit(): void {
    this._coronaVaccineService.getAllCoronaVaccines().subscribe({
      next: coronaVaccines => {
        this.filteredCoronaVaccinesList = coronaVaccines.filter(c => c.memberId === this.memberId);
        console.log("Corona Vaccines Retrieved:", this.filteredCoronaVaccinesList);
        if (this.filteredCoronaVaccinesList.length > 0) {
          this.filteredCoronaVaccinesList.forEach(vaccine => {
            this._manufacturerService.getManufacturerById(vaccine.manufacturerId).subscribe({
              next: m => {
                this.manufacturers.push(m);
              },
              error: err => console.error("Error retrieving manufacturer:", err)
            });
          });
          console.log('manufacturers: ', this.manufacturers);
        }
      },
      error: err => console.error("Error retrieving corona vaccines:", err)
    });
  }
}
