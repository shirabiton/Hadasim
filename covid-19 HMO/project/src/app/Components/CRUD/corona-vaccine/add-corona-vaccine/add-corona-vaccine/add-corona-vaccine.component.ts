import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CoronaVaccineService } from '../../../../../Services/corona-vaccine.service';
import { CoronaVaccine } from '../../../../../Models/corona-vaccine';
import { ManufacturersComponent } from '../../../manufacturer/manufacturers/manufacturers/manufacturers.component';
import { CommonModule } from '@angular/common';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-add-corona-vaccine',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, CommonModule, ManufacturersComponent, MatInputModule, MatButtonModule],
  templateUrl: './add-corona-vaccine.component.html',
  styleUrl: './add-corona-vaccine.component.css'
})

export class AddCoronaVaccineComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute, private _coronaVaccineService: CoronaVaccineService) { }

  public memberId!: number

  @Output()
  addForm!: FormGroup;
  coronaVaccine!: CoronaVaccine
  filteredCoronaVaccines:CoronaVaccine[] = []

  ngOnInit(): void {
    this.route.params.subscribe((param) => {
      this.memberId = param['memberId']
    })

    this._coronaVaccineService.getAllCoronaVaccines().subscribe({
      next: coronaVaccines => {
        console.log('Retrived corona vaccines', coronaVaccines);

        this.filteredCoronaVaccines = coronaVaccines.filter((c) => {
          return c.memberId == this.memberId
        })
      },
      error: err => {
        console.log('Error retriving corona vaccines', err);
      }
    })

    this.addForm = new FormGroup({
      "date": new FormControl(new Date(), [Validators.required, this.minDateValidator]),
      "manufacturerId": new FormControl(null, [Validators.required]),
      "memberId": new FormControl(this.memberId),
    })
  }

  public minDateValidator(control: any) {
    const currentDate = new Date();
    const selectedDate = new Date(control.value);
    if (selectedDate < currentDate) {
      return { minDateValidator: true }; // אימות נכשל
    }
    return null;
  }


  save() {
    this.coronaVaccine = this.addForm.value;

    this._coronaVaccineService.postCoronaVaccine(this.coronaVaccine).subscribe({
      next: (res) => {
        console.log(res);
        // העבר את המשתמש לדף הבית
        this.router.navigate(['/member-details', this.memberId]);
      },
      error: (err) => {
        console.log(err);
      },
    })
  }
}
