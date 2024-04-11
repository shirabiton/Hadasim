import { Component, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Member } from '../../../../../Models/member';
import { MemberService } from '../../../../../Services/member.service';
import { CitiesComponent } from '../../../city/cities/cities.component';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-update-member',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CitiesComponent, CommonModule, MatInputModule, MatButtonModule],
  templateUrl: './update-member.component.html',
  styleUrl: './update-member.component.css'
})

export class UpdateMemberComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private _memberService: MemberService) { }

  public member!: Member;
  imageUrl: string | ArrayBuffer | null = null;
  file: File | null = null;

  @Output()
  public updateForm!: FormGroup

  ngOnInit(): void {
    this.route.params.subscribe((param) => {
      this._memberService.getMemberById(param['memberId']).subscribe({
        next: (m) => {
          this.member = m;
          console.log("Member retrived: ", m);

          // הערכים בטופס
          this.updateForm.patchValue({
            name: this.member.name || '',
            idNumber: this.member.idNumber || '',
            cityId: this.member.cityId || null,
            street: this.member.street || '',
            houseNumber: this.member.houseNumber || 0,
            birthDate: this.member.birthDate ? new Date(this.member.birthDate).toISOString().substring(0, 10) : null, // מחלץ את התאריך וממיר לתבנית הנכונה
            phone: this.member.phone || '',
            mobilePhone: this.member.mobilePhone || '',
            dateOfSickness: null,
            dateOfRecovery: null,
            imageUrl: this.member.imageUrl || '',
          });

        },
        error: (err) => {
          console.log("Error retriving member", err);
        },
      })
    })


    // האובייקט החדש
    this.updateForm = new FormGroup({
      "name": new FormControl("", [Validators.required, Validators.minLength(2), Validators.maxLength(20)]),
      "idNumber": new FormControl("", [Validators.required, Validators.minLength(9), Validators.maxLength(9)]),
      "cityId": new FormControl(null, [Validators.required]),
      "street": new FormControl("", [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      "houseNumber": new FormControl(0, [Validators.required, Validators.min(1), Validators.max(999)]),
      "birthDate": new FormControl(null, [Validators.required, this.maxDateValidator]),
      "phone": new FormControl("", [Validators.required, Validators.minLength(9), Validators.maxLength(10)]),
      "mobilePhone": new FormControl("", [Validators.minLength(9), Validators.maxLength(10)]),
      "dateOfSickness": new FormControl(null, [this.maxDateValidator]),
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
    console.log("name", this.updateForm.get('name')!.value);

    formData.append("name", this.updateForm.get('name')!.value);
    formData.append("idNumber", this.updateForm.get('idNumber')!.value);
    formData.append("cityId", this.updateForm.get('cityId')!.value.toString()); // Ensure cityId is a string
    formData.append("street", this.updateForm.get('street')!.value);
    formData.append("houseNumber", this.updateForm.get('houseNumber')!.value.toString()); // Ensure houseNumber is a string
    formData.append("birthDate", new Date(this.updateForm.get('birthDate')!.value).toISOString()); // Convert birthDate to ISO string
    formData.append("phone", this.updateForm.get('phone')!.value);
    formData.append("mobilePhone", this.updateForm.get('mobilePhone')?.value || ''); // Handle optional mobilePhone
    formData.append("dateOfSickness", this.updateForm.get('dateOfSickness')?.value || ''); // Handle optional dateOfSickness
    formData.append("dateOfRecovery", this.updateForm.get('dateOfRecovery')?.value || ''); // Handle optional dateOfRecovery

    if (this.file) {
      formData.append("image", this.file);
    }

    else {
      formData.append("image", '');
    }
    console.log(formData);

    this._memberService.putMember(this.member.id, formData).subscribe({
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


