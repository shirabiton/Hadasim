import { Component, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { MemberService } from '../../../../../Services/member.service';
import { Router } from '@angular/router';
import { CitiesComponent } from '../../../city/cities/cities.component';
import { CommonModule } from '@angular/common';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-add-member',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, CitiesComponent, CommonModule,
    MatInputModule, MatButtonModule, MatDatepickerModule, MatFormFieldModule, MatIconModule
  ],
  templateUrl: './add-member.component.html',
  styleUrl: './add-member.component.css'
})

export class AddMemberComponent {

  constructor(private router: Router, private _memberService: MemberService) { }
  
  todayDate = new Date();
  imageUrl: string | ArrayBuffer | null = null;
  file: File | null = null;
  
  @Output()
  addForm!: FormGroup;

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
      "image": new FormControl(null),
      "imageUrl": new FormControl(null),
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

  handleImage(event: any): void {
    this.file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      this.imageUrl = reader.result;
    };
    if (this.file) {
      reader.readAsDataURL(this.file);
    }
  }

  save() {
    const formData = new FormData();

    formData.append("name", this.addForm.get('name')!.value);
    formData.append("idNumber", this.addForm.get('idNumber')!.value);
    formData.append("cityId", this.addForm.get('cityId')!.value.toString());
    formData.append("street", this.addForm.get('street')!.value);
    formData.append("houseNumber", this.addForm.get('houseNumber')!.value.toString());
    formData.append("birthDate", new Date(this.addForm.get('birthDate')!.value).toISOString()); 
    formData.append("phone", this.addForm.get('phone')!.value);
    formData.append("mobilePhone", this.addForm.get('mobilePhone')?.value || ''); 
    formData.append("dateOfSickness", this.addForm.get('dateOfSickness')?.value || ''); 
    formData.append("dateOfRecovery", this.addForm.get('dateOfRecovery')?.value || ''); 

    if (this.file) {
      formData.append("image", this.file);
    }

    else {
      formData.append("image", '');
    }


    this._memberService.postMember(formData).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/members-list']);
      },
      error: (err) => {
        console.log(err);
      },
    })
  }

}