import { Injectable, OnDestroy } from "@angular/core";
import { ServiceBusClient } from '@azure/service-bus';
import { Payload } from "../models/payload";
import { environment } from "src/environments/environment";

@Injectable()
export class ServiceBusSender implements OnDestroy  {
  serviceBusClient ;
  topicClient ;
  sender ;

  constructor() {
    this.serviceBusClient  = ServiceBusClient.createFromConnectionString(environment.serviceBusConnectionString);
    this.topicClient = this.serviceBusClient .createTopicClient(environment.topicName); 
    this.sender = this.topicClient.createSender();
  }

  async sendMessage(message: Payload) {
    await this.sender.sendMessage(message);
  }
  
  ngOnDestroy(): void {
     this.topicClient.close();
     this.serviceBusClient.close();
  }

}
