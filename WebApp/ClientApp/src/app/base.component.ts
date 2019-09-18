import { ServiceBusClient, OnMessage, OnError, ReceiveMode } from "@azure/service-bus";
import { environment } from "src/environments/environment";
import { Payload } from "./models/payload";
import { OnDestroy } from "@angular/core";

export class CounterComponent implements OnDestroy {

    serviceBusClient ;
    topicClient ;
    sender ;
    subscriptionClient;
    receiver;
    constructor() {
        this.serviceBusClient  = ServiceBusClient.createFromConnectionString(environment.serviceBusConnectionString);
        this.topicClient = this.serviceBusClient .createTopicClient(environment.topicName); 
        this.sender = this.topicClient.createSender();
        this.subscriptionClient = this.serviceBusClient .createSubscriptionClient(environment.topicName); 
        this.receiver = this.subscriptionClient.createReceiver(ReceiveMode.receiveAndDelete);
    }

    
  registerMessageHandler(onMessage: OnMessage, onError: OnError)
  {
   this.receiver.registerMessageHandler(onMessage, onError);
  }

  async sendMessage(message: Payload) {
    await this.sender.sendMessage(message);
  }
  
  ngOnDestroy(): void {
     this.topicClient.close();
     this.serviceBusClient.close();
     this.subscriptionClient.close();
  }
}

