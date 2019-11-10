#  Relatorio

Nome: Érico de Souza Loewe

Data: 30/10/2019

## O hardware utilizado;

### ESP32

 ESP32 com WiFi ou BLE

![esp-32](https://uploads.filipeflop.com/2017/11/myESP32-DevKitC-pinout.png)

### PIR

Sensor de Movimento/Presença

 ![Image result for sensor PIR](https://http2.mlstatic.com/sensor-pir-presenca-e-movimento-hc-sr501-arduino-realengo-D_NQ_NP_621027-MLB27130045774_042018-F.jpg) 

## O ambiente de desenvolvimento;

### ESP32 (Sensor)

Feito em C - linguagem nativa da IDE Arduino -, é responsavel por processar as informações do sensor PIR e envia-las ao servidor via sockets.

- https://www.arduino.cc/ 
- http://esp32.net/ 
- https://randomnerdtutorials.com/esp32-pir-motion-sensor-interrupts-timers/ 
- http://www.bosontreinamentos.com.br/eletronica/como-funciona-um-sensor-de-movimento-pir-passive-infrared/ 

### Servidor

Feito em C#, é responsavel por receber as mensagens do ESP32 via sockets e alertar o app via WebSockets caso haja alterações no dado.

- https://dotnet.microsoft.com/download 
- https://developer.mozilla.org/pt-BR/docs/WebSockets 

### App

Feito em React (html, css, js), é responsavel por receber as mensagens do Servidor a partir de WebSockets e notificar o usuario caso o sensor detectar alguma presença.

- https://pt-br.reactjs.org/ 

## O procedimento para instalação do software

### Install

- Download and installl dotnet core SDK: [Link](https://dotnet.microsoft.com/download)
- Download and installl node.js: [Link](https://nodejs.org/en/download/)
- Download and installl Arduino IDE: [Link](https://www.arduino.cc/en/main/software)

#### App

Rode os seguintes comandos na pasta *app* `npm i`

### Run

#### App

Rode os seguintes comandos na pasta *app* `npm start`. Ou rode o comando `npm build` para ter a aplicação pronta para subir em um servidor de produção. (com arquivos na pasta `dist`)

#### Server

Rode os seguintes comandos na pasta *server* `dotnet run`

#### ESP32 (Sensor)

Abra o arquivo `pir.ino` na Arduino IDE e clique no botão de upload.

Quando aplicação subir para a placa, deve-se abrir o Serial Monitor (Ctrl + Shift + M) e enviar qualquer caracter para liberar a comunicação serial com a placa.

## Tutorial da aplicação desenvolvida

> (um guia passo a passo para implementar a solução)

### Pir e ESP32

Se iniciou o desenvolvimento da aplicação a partir do entendimento do funcionamento do sensor PIR no ESP32. Para isso, foi configurado o sensor em sua devida porta, foi configurado a transmissão serial e gerado prints do valor do sensor no método loop.

### ESP32 e Sockets

Após ter o valor do sensor em mãos, foi desenvolvido a comunicação da placa com o "mundo externo", para isso foi conectado a placa no hotspot gerado pelo computador, e do computador, foi acessado o socket da placa através do `telnet <host> <port>`.

### Receber dados no servidor web

Foi criado uma API web em dotnet para gerenciamento dos dados e envio do dados para o cliente, umas das funcionalidades desenvolvida, foi o recebimento dos dados do sensor via sockets. Tendo o host e porta do ESP32 em mãos, foi aberto uma conexão com o ESP32, recebido e salvo as informações do sensor.

### Transmitir dados do servidor para o cliente

Recebido os dados do sensor no servidor, foi adicionado aos projetos o suporte a websocket para o servidor conseguir enviar uma mensagem ao cliente, no caso, uma notificação que recebeu o dado do sensor.

Após aberto a conexão cliente=>servidor, quando o cliente é acionado com o dado do servidor, o mesmo atualiza o dado na tela, definindo o valor atual do sensor no estado da aplicação.

### Criar layout app

Depois de todo fluxo funcionando, foi adicionado um layout ao app utilizando scss, para demonstrar o valor do sensor.

### Notificar usuário quando detectar alguma presença

Depois de todo fluxo pronto, foi adicionado uma melhoria a aplicação, agora quando o sensor detecta algum movimento, é enviado um alerta ao usuário, sobre o que foi encontrado no sensor.

## O resultado obtido 

> (a aplicação funcionando na prática).

![App image](https://lh5.googleusercontent.com/Swsb_o8HeGTDb2DbbRMHTh4ZSZLPplw490snU-UwzlAX8oRrDeEzwSzi2COsnINIFbYx_bUramZivOYcl3w2QihZraapTJx0SYvdS6_78V1xKjcNzvzz6vaBONm7ksX3qMJazi3XN2Y)

## O código fonte COMENTADO

### ESP32 (Sensor)

```c
// envia o valor atual do sensor ao servidor
void sendInfoIfNeed() {
  // recebe o valor atual do sensor
  int sensorValue = digitalRead(motionSensorPort);

  Serial.print("Valor atual: ");
  Serial.println(sensorValue);

  // valida se o valor do sensor mudou desde o ultimo envio
  if (lastSensorValue != sensorValue) {  
    lastSensorValue = sensorValue;
  
    // Conecta ao servidor que esta aceitando conexões no host e porta
    if (!client.connect(host, port)) {
      Serial.println("Connection to host failed");
  
      delay(1000);
      return;
    }

    Serial.print("Sending sensor value to IP ");
    Serial.println(WiFi.localIP());
    // Envia o valor ao servidor
    client.print(sensorValue);
  }
}
```

### Server

#### Recebimento das mensagens da placa

```c#
// Abre uma conexão no host e porta para receber os dados do sensor
private async Task ListenSocket()
{
    IPAddress ipAddress = IPAddress.Parse("192.168.137.1");
    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 9999);
    // Cria o socket server no host e ip
    Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

    Console.WriteLine("Start to listen");

    try
    {
        // Atrela o server ao host e porta
        listener.Bind(localEndPoint);
        // Maximo de conexões pendentes
        listener.Listen(1000);

        // Enquanto o sensor enviar informações
        while (true)
        {
            // Aceita a conexão do esp32
            Socket handler = await listener.AcceptAsync();
            Console.WriteLine("Start to accept");

            byte[] bytes = new byte[1024];

            Console.WriteLine("Socket connected to {0}", localEndPoint.ToString());

            // Recebe as informações do sensor em bytes
            int bytesRec = handler.Receive(bytes);

            // Transforma para string e seta na variavel de controle
            pirStatus = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            Console.WriteLine("Echoed test = {0}", pirStatus);
            // Finaliza a conexão com o cliente
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            // Aguarda um tempo para aceitar mais conexões
            Thread.Sleep(5000);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
}
```

#### Envio das mensagens para o app

```c#
// Envia informações do sensor ao cliente enquanto ele estiver ouvindo
private async Task Echo(HttpContext context, WebSocket webSocket)
{
    var buffer = new byte[1024 * 4];
    // Recebe a request do cliente (app)
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

    Console.WriteLine("Start ws");

    while (!result.CloseStatus.HasValue)
    {
        Console.WriteLine("Sending ws");

        // Valida o estado atual do sensor e verifica se foi detectado presença
        if (pirStatus == "1")
        {
            // Caso sim, é enviado a informação "MD" (MOVIMENTO DETECTADO) para o cliente
            await webSocket.SendAsync(Encoding.UTF8.GetBytes("MD"), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }
        else
        {
            // Caso não, é enviado a informação "NMD" (NENHUM MOVIMENTO DETECTADO) para o cliente
            await webSocket.SendAsync(Encoding.UTF8.GetBytes("NMD"), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }

        // Aguarda 5s até a proxima atualização
        Thread.Sleep(5000);
    }

    Console.WriteLine("Closed ws");
    // Finaliza a conexão entre cliente e servidor
    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
}
```

### App

```typescript
// Componente utilizado para apresentar o resultado do sensor na tela
export class PirSensor extends React.Component<Props, State> {
    
    // ...
    
    // Abre a conexão com o servidor e atualiza o estado da aplicação (atualizando a tela)
    private loadSocket() {
        // Cria uma conexão do tipo WebSocket
        socket = new WebSocket(url);
        
        // Abre uma conexão com o servidor
        socket.onopen = () => {
            // Quando aberto, atualiza o estado do sensor para "aberto"
            this.setState(() => ({ wsStatus: "opened" }));
            // Envia uma mensagem ao servidor dizendo que esta ok (estilo ping pong)
            socket.send("Receive sensor status");
        };
        // Fecha a conexão com o servidor
        socket.onclose = () => this.setState(() => ({ wsStatus: "closed" }));
        // No caso de erro, apresenta para o usuario o mesmo (alterando o estado)
        socket.onerror = e => {
            this.setState(() => ({ wsStatus: "error" }));
            console.error("Stack: ", e);
        };
        // Recebe e trata a mensagem do servidor
        socket.onmessage = this.handleMessage;
    }

    // Recebe e trata a mensagem do servidor
    private handleMessage = ({ data }: MessageEvent) => {
        // Atualiza o estado da aplicação com a mensagem do sensor e o status do WS
        this.setState(() => ({ wsStatus: "message", sensorStatus: data }));

        // No caso do movimento detectado, é apresentado ao usuario uma notificação
        if (data === "MD") {
            if (Notification.permission === "granted") {
                new Notification("Movimento detectado!");
            } else {
                alert("Movimento detectado!");
            }
        }
    };
    
    // ...
}
```

## O código fonte (para copiar para um IDE)

- Github
  - [Source](https://github.com/ericoloewe/pir-esp-32 )
  - [Download](https://github.com/ericoloewe/pir-esp-32/archive/master.zip)

