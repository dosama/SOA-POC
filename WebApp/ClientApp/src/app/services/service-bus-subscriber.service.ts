import { Injectable, OnDestroy } from "@angular/core";
import { ServiceBusClient, ReceiveMode, OnMessage, OnError } from '@azure/service-bus';
import { environment } from "src/environments/environment";
import { Payload } from "../models/payload";

@Injectable()
export class ServiceBusSubscriber implements OnDestroy {

  serviceBusClient;
  subscriptionClient;
  receiver;

  constructor() {
    this.serviceBusClient  = ServiceBusClient.createFromConnectionString(environment.serviceBusConnectionString);
    this.subscriptionClient = this.serviceBusClient .createSubscriptionClient(environment.topicName); 
    this.receiver = this.subscriptionClient.createReceiver(ReceiveMode.receiveAndDelete);
  
  }

  registerMessageHandler(onMessage: OnMessage, onError: OnError)
  {
   this.receiver.registerMessageHandler(onMessage, onError);
  }

  ngOnDestroy(): void {
     this.subscriptionClient.close();
     this.serviceBusClient.close();
  }

}
