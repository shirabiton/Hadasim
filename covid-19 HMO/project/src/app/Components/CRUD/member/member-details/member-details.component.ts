import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Member } from '../../../../Models/member';
import { MemberService } from '../../../../Services/member.service';
import { City } from '../../../../Models/city';
import { CityService } from '../../../../Services/city.service';
import { CommonModule } from '@angular/common';
import { CoronaVaccinesListComponent } from '../../corona-vaccine/corona-vaccines-list/corona-vaccines-list.component';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-member-details',
  standalone: true,
  imports: [CommonModule, CoronaVaccinesListComponent, 
    MatProgressSpinnerModule, MatIcon],
  templateUrl: './member-details.component.html',
  styleUrl: './member-details.component.css'
})

export class MemberDetailsComponent implements OnInit {

  public member!: Member
  public city!: City


  constructor(private route: ActivatedRoute, private router: Router, private _memberService: MemberService,
    private _cityService: CityService) { }


  ngOnInit(): void {
    this.route.params.subscribe((param) => {
      this._memberService.getMemberById(param['memberId']).subscribe({
        next: m => {
          this.member = m;
          console.log("Member Retrieved:", m);

          this._cityService.getCityById(this.member.cityId).subscribe({
            next: c => {
              this.city = c;
              console.log("City Retrieved:", c);
            },
            error: err => console.error("Error retrieving city:", err)
          });
        },
        error: err => console.error("Error retrieving member:", err)
      });
    });
  }

  public delete() {
    this._memberService.deleteMember(this.member.id).subscribe({
      next: member => {
        console.log("Member deleted:", member);
        this.router.navigate(['/members-list'])
      },
      error: err => console.error("Error deleting member:", err)
    });
  }

  public goToUpdateMember() {
    this.router.navigate(['/update-member', this.member.id])
  }

  public goToAddCoronaVaccine(){
    this.router.navigate(['add-corona-vaccine', this.member.id])
  }
}
