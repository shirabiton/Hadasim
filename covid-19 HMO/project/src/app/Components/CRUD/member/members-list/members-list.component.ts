import { Component, OnChanges, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Member } from '../../../../Models/member';
import { MemberService } from '../../../../Services/member.service';
import { MemberDetailsComponent } from '../member-details/member-details.component';

import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-members-list',
  standalone: true,
  imports: [CommonModule, FormsModule, MemberDetailsComponent,
    MatInputModule, MatIconModule, MatDividerModule, MatListModule, MatButtonModule],
  templateUrl: './members-list.component.html',
  styleUrl: './members-list.component.css'
})

export class MembersListComponent implements OnInit {

  public selectedMember!: Member
  public search = ''
  public membersList: Member[] | null | undefined;
  public filterMembersList!: Member[]

  constructor(private router: Router, private _memberService: MemberService) { }

  ngOnInit(): void {
    this._memberService.getAllMembers().subscribe({
      next: members => {
        this.membersList = members;
        this.filterMembersList = members;
        console.log("Members Retrieved:", members);
      },
      error: err => console.error("Error retrieving members:", err)
    });
  }

  public showDetails(member: Member) {
    this.selectedMember = member;
    this.router.navigate(['/member-details', this.selectedMember.id])
  }

  public filterMembers() {
    if (this.membersList)
      this.filterMembersList = this.membersList.filter((m) => {
        return m.name?.toLowerCase().includes(this.search.toLowerCase())
      })
  }

  public goToAddMember() {
    this.router.navigate(['/add-member']);
  }
}
