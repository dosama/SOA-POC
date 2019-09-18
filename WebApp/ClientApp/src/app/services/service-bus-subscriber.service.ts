import { Injectable, OnDestroy } from "@angular/core";
import { ServiceBusClient, ReceiveMode, OnMessage, OnError } from "@azure/service-bus"; 
import { environment } from "src/environments/environment";

@Injectable()
export class ServiceBusSubscriber implements OnDestroy {

    sbClient;
    subscriptionClient;
    receiver;

  constructor(private serviceBusClient: ServiceBusClient) {
    const sbClient = ServiceBusClient.createFromConnectionString(environment.serviceBusConnectionString); 
    const subscriptionClient = sbClient.createSubscriptionClient(environment.topicName,environment.topicName,);
    const receiver = subscriptionClient.createReceiver(ReceiveMode.peekLock);
     receiver.registerMessageHandler(this.myMessageHandler, this.myErrorHandler);
  }

  registerMessageHandler(messageHandler:OnMessage, errorHandler:OnError )
{
    this.receiver.registerMessageHandler(messageHandler, errorHandler);
}
  
   myMessageHandler = async (message) => {
    
  };
   myErrorHandler = (error) => {
    console.log(error);
  };


  ngOnDestroy(): void {
    throw new Error("Method not implemented.");
}
}
