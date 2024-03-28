import { Component, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { Member } from '../../../../../Models/member';
import { MemberService } from '../../../../../Services/member.service';
import { Router } from '@angular/router';
import { CitiesComponent } from '../../../city/cities/cities.component';
import { CommonModule } from '@angular/common';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-add-member',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, CitiesComponent, CommonModule, MatInputModule, MatButtonModule, MatDatepickerModule, MatFormFieldModule],
  templateUrl: './add-member.component.html',
  styleUrl: './add-member.component.css'
})

export class AddMemberComponent {
  constructor(private router: Router, private _memberService: MemberService) { }

  public todayDate = new Date()

  @Output()
  public addForm!: FormGroup;
  member!: Member

  ngOnInit(): void {
    this.addForm = new FormGroup({
      "name": new FormControl("", [Validators.required, Validators.minLength(2), Validators.maxLength(20)]),
      "idNumber": new FormControl("", [Validators.required, Validators.minLength(9), Validators.maxLength(9)]),
      "cityId": new FormControl(null, [Validators.required]), // שדה חובה, ואם נכנס משהו-הוא בטוח ID שתואם ל CITY כי הקלט שלו הוא מתוך אופציות
      "street": new FormControl("", [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      "houseNumber": new FormControl(0, [Validators.required, Validators.min(1), Validators.max(999)]),
      "birthDate": new FormControl(null, [Validators.required, this.maxDateValidator]),
      "phone": new FormControl("", [Validators.required, Validators.minLength(9), Validators.maxLength(10)]),
      "mobilePhone": new FormControl("", [Validators.minLength(10), Validators.maxLength(10)]), // not required
      "dateOfSickness": new FormControl(null, [this.maxDateValidator]), // not required
      "dateOfRecovery": new FormControl(null, [this.maxDateValidator]),
    })
  }

  public maxDateValidator(control: any) {
    const currentDate = new Date();
    const selectedDate = new Date(control.value);
    if (!selectedDate || selectedDate >= currentDate) {
      return { maxDateValidator: true }; // אימות נכשל
    }
    return null;
  }

  // public minDateValidator(control: any) {
  //   const currentDate = new Date();
  //   const selectedDate = control.value?new Date(control.value) : null;
  //   if (selectedDate && selectedDate < currentDate) {
  //     return { minDateValidator: true }; // אימות נכשל
  //   }
  //   return null;
  // }


  // הוספת המשתמש לשרת
  save() {
    this.member = this.addForm.value;

    this._memberService.postMember(this.member).subscribe({
      next: (res) => {
        console.log(res);
        // העבר את המשתמש לדף הבית
        this.router.navigate(['/members-list']);
      },
      error: (err) => {
        console.log(err);
      },
    })
  }

}
