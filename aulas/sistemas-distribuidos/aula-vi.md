# Aula VI

## Estudo pessoal sobre sockets

Sockets estão relacionados a camada de tranporte, onde conseguimos trabalhar com protocolos do tipo TCP e UDP

### Sockets utilizando dotnet (C#)

A classe implementa a interface de sockets Berkeley (tambem conhecida como **POSIX sockets**)

- https://docs.microsoft.com/pt-br/dotnet/api/system.net.sockets.socket?view=netframework-4.8
- https://en.wikipedia.org/wiki/Berkeley_sockets

### POSIX

É um padrão para determinar interfaces comuns entre sistemas operacionais.

- [O que é o POSIX? Stack overflow](https://pt.stackoverflow.com/questions/194883/o-que-é-o-posix)

#### POSIX sockets (Berkeley sockets)

Interface criada para padronizar a implementação de sockets no SO.

Pode ser encontrada em: `sys/socket.h` Internet Protocol family

- https://pubs.opengroup.org/onlinepubs/7908799/xns/syssocket.h.html

- https://www.ibm.com/support/knowledgecenter/ssw_ibm_i_71/rzab6/howdosockets.htm

![The two endpoints establish a connection, and bring the client and server together.](https://www.ibm.com/support/knowledgecenter/ssw_ibm_i_71/rzab6/rxab6500.gif)

### Camadas de rede

![Resultado de imagem para computer network layers](https://www.cse.iitk.ac.in/users/dheeraj/cs425/fig.lec02/tcp_layer.jpg)

### Sockets utilizando Node.js

The `net` module provides an asynchronous network API for creating stream-based TCP or [IPC](https://nodejs.org/api/net.html#net_ipc_support) servers ([`net.createServer()`](https://nodejs.org/api/net.html#net_net_createserver_options_connectionlistener)) and clients ([`net.createConnection()`](https://nodejs.org/api/net.html#net_net_createconnection)).

https://nodejs.org/api/net.html

chat: https://gist.github.com/creationix/707146