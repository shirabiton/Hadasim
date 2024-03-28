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

  public member!: Member

  @Output()
  public updateForm!: FormGroup
  public memberUpdate!: Member


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

  // public minDateValidator(control: any) {
  //   const currentDate = new Date();
  //   const selectedDate = control.value ? new Date(control.value) : null;
  //   if (selectedDate && selectedDate < currentDate) {
  //     return { minDateValidator: true }; // אימות נכשל
  //   }
  //   return null;
  // }

  public save() {
    this.memberUpdate = this.updateForm.value

    this._memberService.putMember(this.member.id, this.memberUpdate).subscribe({
      next: (m) => {
        console.log("Member updated: ", m)
        this.router.navigate(['/members-list'])
      },
      error: (err) => {
        console.log("Error updating member", err);
      },
    });
  }

}


