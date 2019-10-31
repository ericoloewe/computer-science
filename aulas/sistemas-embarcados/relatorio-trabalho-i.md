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

## O resultado obtido 

> (a aplicação funcionando na prática).

![App image](https://lh5.googleusercontent.com/Swsb_o8HeGTDb2DbbRMHTh4ZSZLPplw490snU-UwzlAX8oRrDeEzwSzi2COsnINIFbYx_bUramZivOYcl3w2QihZraapTJx0SYvdS6_78V1xKjcNzvzz6vaBONm7ksX3qMJazi3XN2Y)

## O código fonte COMENTADO

### ESP32 (Sensor)

```c
void sendInfoIfNeed() {
  int sensorValue = digitalRead(motionSensorPort);

  Serial.print("Valor atual: ");
  Serial.println(sensorValue);

  if (lastSensorValue != sensorValue) {  
    lastSensorValue = sensorValue;
  
    if (!client.connect(host, port)) {
      Serial.println("Connection to host failed");
  
      delay(1000);
      return;
    }

    Serial.print("Sending sensor value to IP ");
    Serial.println(WiFi.localIP());
    client.print(sensorValue);
  }
}
```

### Server

#### Recebimento das mensagens da placa

```c#
private async Task ListenSocket()
{
    IPAddress ipAddress = IPAddress.Parse("192.168.137.1");
    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 9999);
    Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

    Console.WriteLine("Start to listen");

    try
    {
        listener.Bind(localEndPoint);
        listener.Listen(1000);

        while (true)
        {
            Socket handler = await listener.AcceptAsync();
            Console.WriteLine("Start to accept");

            byte[] bytes = new byte[1024];

            Console.WriteLine("Socket connected to {0}", localEndPoint.ToString());

            // Receive the response from the remote device.  
            int bytesRec = handler.Receive(bytes);

            pirStatus = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            Console.WriteLine("Echoed test = {0}", pirStatus);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
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
private async Task Echo(HttpContext context, WebSocket webSocket)
{
    var buffer = new byte[1024 * 4];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

    Console.WriteLine("Start ws");

    while (!result.CloseStatus.HasValue)
    {
        Console.WriteLine("Sending ws");

        if (pirStatus == "1")
        {
            await webSocket.SendAsync(Encoding.UTF8.GetBytes("MD"), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }
        else
        {
            await webSocket.SendAsync(Encoding.UTF8.GetBytes("NMD"), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }

        Thread.Sleep(5000);
    }

    Console.WriteLine("Closed ws");
    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
}
```

### App

```typescript
export class PirSensor extends React.Component<Props, State> {
    private loadSocket() {
        socket = new WebSocket(url);
        socket.onopen = () => {
            this.setState(() => ({ wsStatus: "opened" }));
            socket.send("Receive sensor status");
        };
        socket.onclose = () => this.setState(() => ({ wsStatus: "closed" }));
        socket.onerror = e => {
            this.setState(() => ({ wsStatus: "error" }));
            console.error("Stack: ", e);
        };
        socket.onmessage = this.handleMessage;
    }

    private handleMessage = ({ data }: MessageEvent) => {
        this.setState(() => ({ wsStatus: "message", sensorStatus: data }));

        if (data === "MD") {
            if (Notification.permission === "granted") {
                // If it's okay let's create a notification
                new Notification("Movimento detectado!");
            } else {
                alert("Movimento detectado!");
            }
        }
    };
}
```

## O código fonte (para copiar para um IDE)

- Github
  - [Source](https://github.com/ericoloewe/pir-esp-32 )
  - [Download](https://github.com/ericoloewe/pir-esp-32/archive/master.zip)

