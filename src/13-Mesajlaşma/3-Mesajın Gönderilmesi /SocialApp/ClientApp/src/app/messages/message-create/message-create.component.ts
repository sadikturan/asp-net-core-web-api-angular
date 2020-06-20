import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-message-create',
  templateUrl: './message-create.component.html',
  styleUrls: ['./message-create.component.css']
})
export class MessageCreateComponent implements OnInit {

  @Input() recipientId: number;
  message: any = {};

  constructor(private activeModal: NgbActiveModal,
    private authService: AuthService,
    private userService: UserService,
    private alertifyService: AlertifyService,
    private router: Router) { }

  ngOnInit(): void {
    console.log(this.recipientId);
  }

  closeModal() {
    this.activeModal.close()
  }

  sendMessage() {
    this.message.recipientId = this.recipientId;

    this.userService
      .sendMessage(this.authService.decodedToken.nameid, this.message)
      .subscribe(result => {
        console.log(result);
        this.alertifyService.success("message has been sent");
        this.activeModal.close();
        this.router.navigate(['/messages']);
      }, err => {
        this.alertifyService.error(err);
      })

  }

}
