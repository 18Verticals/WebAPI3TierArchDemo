import { Component } from '@angular/core';
import { MessagePassingService } from 'src/app/services/message-passing.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent {
  isShowLoader:boolean = false;
  constructor(private messagePassingService:MessagePassingService) {
    messagePassingService.getMessage().subscribe((res)=>{
      debugger
      this.isShowLoader = res;
    })
  }


}
