# Aula IV

## Requisições HTTP

O browser realiza uma sequencia de requisições:

Em primeiro lugar o HTML, em seguida, realiza requisições do que esta linkado no conteudo do HTML

### GET e POST

Para realizar uma requisição do tipo **GET**

```http
GET <pathname> HTTP/1.0
```

Para realizar uma requisição do tipo **POST**

```http
POST <pathname> HTTP/1.0
```

Exemplo de resposta

```http
HTTP/1.1 200 OK
SERVER: SISDIST Server
Content-Type: text/html
Connection: close
Content-Length: 161

<html></html>
```

