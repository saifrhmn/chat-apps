import { UserService } from '../shared/user.service';
import { Component, OnInit, NgZone, OnDestroy} from '@angular/core';
import { Router } from '@angular/router';
import { Message } from '../models/message';
import { ChatService } from '../shared/chat.service';
import { Subject } from 'rxjs';
import { takeUntil, map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})

export class ChatComponent implements OnInit, OnDestroy {
  txtMessage: string;
  messages:Message[];
  message: Message;
  history: Message[];
  private destroyed$: Subject<void>;
  private deletedMessageid : number;
  private deletedSender : string;
  private deletedMsg : string;
  private deletedDate : Date; 

  
  constructor(private router: Router, private toastr: ToastrService,private userService: UserService,private chatService: ChatService,private ngZone: NgZone) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }


  ngOnInit() {
    this.txtMessage = '';
    this.message = new Message();
    this.history = [];
    this.messages = [];
    this.destroyed$ = new Subject();
    
    this.subscribeToEvents();
    
    this.chatService.getHistoryOfMessages().pipe(takeUntil(this.destroyed$),map(val => <Message[]>val))
    .subscribe(res => {
      this.history = res;
      console.log(res);
      debugger;
      },
      error => {
        console.log(error);
      });
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
    this.chatService.stopSignalR();
  }

  private subscribeToEvents(): void {
    this.chatService.messageReceived
    .subscribe((message: Message) => {
      this.ngZone.run(() => {    
          this.messages.push(message);  
      });
    });
  }

  public sendMessage(): void {
    if (this.txtMessage) {
      this.message.sender = localStorage.getItem('userName');
      this.message.message = this.txtMessage;
      this.message.date = new Date();
      this.chatService.sendMessage(this.message);
      this.txtMessage = '';
    }
  }
  
  public deleteMessage(deletedMessageid,deletedSender,deletedMsg,deletedDate) {
   debugger;
    if (this.deletedMessageid != 0 ) {
      this.message.id=deletedMessageid;
      this.message.sender = deletedSender;
      this.message.message = deletedMsg;
      this.message.date = deletedDate;
      this.chatService.deleteMessage(this.message);
      this.toastr.error('Deleted Message', 'Deleted');
    }
  }

  public onLogout(): void {
  this.userService.logout();
  } 

}