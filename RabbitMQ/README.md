# Docker Run

```bash
docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

```

We must also add a port mapping for 5672, which is the default port RabbitMQ uses for communication. In order for us to access the management UI, we open a browser window and navigate to localhost:15672, using the default login of guest/guest.
