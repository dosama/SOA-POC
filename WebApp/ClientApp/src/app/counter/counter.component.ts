import { Component } from '@angular/core';
import { ServiceBusSender } from '../services/service-bus-sender.service';
import { ServiceBusSubscriber } from '../services/service-bus-subscriber.service';
import { Payload } from '../models/payload';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  


  constructor( ) {
 
  }
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
    
    // const payload: Payload = {
    //   actionName: 'CounterMessage',
    //   jsonContent: null
    // };
    // this.serviceBusSender.sendMessage(payload)
   

   
  }

  myMessageHandler = async (payload) => {
    console.log("service Bus Message Received");
    console.log(payload);
  };

   myErrorHandler = (error) => {
    console.log("service Bus Message Error");
    console.log(error);
  };
}
