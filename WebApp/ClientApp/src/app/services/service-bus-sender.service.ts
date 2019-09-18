import { Injectable, OnDestroy } from "@angular/core";
import { ServiceBusClient } from "@azure/service-bus"; 
import { Payload } from "../models/payload";

@Injectable()
export class ServiceBusSender implements OnDestroy {

    sbClient;
    topicClient;

  constructor() {
    const sbClient = ServiceBusClient.createFromConnectionString('Endpoint=sb://poc-service-bus2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e5Vw4sN57//CVvC7yurx3TFRTzmR7FAoamVy6xJIoho='); 
    this. topicClient = sbClient.createTopicClient('poc-topic');
    
  }

  async sendMessage(message: Payload) {
      try{
        if(this.topicClient)
        {
          const sender = this.topicClient.createSender();
         await sender.send(message);
         await this.topicClient.close();
        }
      }
      finally{  
this.sbClient.close();
      }
  }

  ngOnDestroy(): void {
    this.sbClient.close();
    this.topicClient.close();
}
}
