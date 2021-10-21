# Distributed Chat System

For implementing this system I used two different Client UI:
1) [WEB UI](#chat-system---web-ui): Using MVC .Net Core Application and SignalR (WebSockets) as our client
2) [Console](#chat-system---console): Using .Net Core Console Application as our client
## Chat System - WEB UI

When Web & API tiers are separated, it is impossible to directly send a server-to-client message from the HTTP API. This is also true for a microservice architected application. We use the distributed event bus ([NATS](https://nats.io/)) to deliver the message from API application to the web application, then to the client.

![](./assets/web.png)

In above picture, we can see the data-flow that we implemented with using [MVC Web Application](./src/Chat.Web) as Client. This diagram represents how data will flow in our application when Client 1 sends a message to Client 2. It is explained in 5 steps:

1) Client 1 sends a message data to our [Web UI](./src/Chat.Web) through a user interface form.
2) Web Application will call our [API](./src/Chat.API) service via a REST call.
3) The message data is processed in our [API](./src/Chat.API) service and API service publishes an event to our NATS message broker, that holds the data that will be sent to Client 2.
4) [Web UI](./src/Chat.Web), that is subscribed to that event through our NATS message broker, receives it via a event handler.
5) [Web UI](./src/Chat.Web) sends the message to Client 2 via a web socket (signalr) connection.


## Chat System - Console

![](./assets/console.png)

In above picture, we can see the data-flow that we implemented with using [Console Application](./src/Chat.Console) as Client. This diagram represents how data will flow in our application when Client 1 sends a message to Client 2. It is explained in 3 steps:

1) Client1 or first [Console Application](./src/Chat.Console) sends a message data to our [API](./src/Chat.API) service through a REST call.
2) The message data is processed in our [API](./src/Chat.API) service and API service publishes an event to our NATS message broker, that holds the data that will be sent to Client 2.
3) Our Client2 [Console Application](./src/Chat.Console), that is subscribed to that event through our NATS message broker, receives it via a event handler.


## How to run

### WEB UI
For running our system with using [WEB UI](#chat-system---web-ui) we need to run our [MVC Application](./src/Chat.Web) as client and [API](./src/Chat.API) as a service.

```
dotnet run --project src/Chat.API/Chat.API.csproj
dotnet run --project src/Chat.Web/Chat.Web.csproj
```

Then after these two application were up and running, our API service will be host on `https://localhost:7001` and our MVC application will be host on `https://localhost:5001`.
Now on `https://localhost:5001` address we can create some new user for chatting purpose. In seed of our application there are some predefined users with below information:

``` bash
Email: mehdi@yahoo.com
UserName: mehdi
Password: 000000

Email: mehdi1@yahoo.com
UserName: mehdi1
Password: 000000

Email: mehdi2@yahoo.com
UserName: mehdi2
Password: 000000
```

Now we can chat between our different users with different session in browser Incognito Mode.

![](./assets/chat-web.png)

### Console