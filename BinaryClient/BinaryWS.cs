using System;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BinaryClient.JSONTypes;
using Newtonsoft.Json;

namespace BinaryClient
{
    public class BinaryWs
    {
        private readonly ClientWebSocket _ws = new ClientWebSocket();
        //private readonly Uri _uri = new Uri("wss://ws.binaryws.com/websockets/v3?app_id=xxxx");
        private readonly Uri _uri = new Uri("wss://ws.binaryws.com/websockets/v3?app_id=");

        public async Task<Auth> Authorize(string key)
        {
            SendRequest($"{{\"authorize\":\"{key}\"}}").Wait();
            var jsonAuth = await StartListen();
            return JsonConvert.DeserializeObject<Auth>(jsonAuth);
        }

        public async Task SendRequest(string data)
        {
            //X509Certificate2 cert = new X509Certificate2("cacert.pem","",X509KeyStorageFlags.MachineKeySet);
            //ClientWebSocketOptions cliOption = new ClientWebSocketOptions();

            while (_ws.State == WebSocketState.Connecting) { };
            if (_ws.State != WebSocketState.Open)
            {
                throw new Exception("Connection is not open.");
            }

            var reqAsBytes = Encoding.UTF8.GetBytes(data);
            var ticksRequest = new ArraySegment<byte>(reqAsBytes);
            
            
            await this._ws.SendAsync(ticksRequest,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }

        public async Task<string> StartListen()
        {
            while (_ws.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[8000]);
                {
                    var result = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer.Array), CancellationToken.None);
                    try
                    {
                        CancellationToken token = new CancellationToken(true);
                        await Task.Delay(5000, token);
                    }
                    catch (TaskCanceledException taskEx)
                    {
                        //throw;
                    }

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                    var str = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    var res = result.EndOfMessage ? str : $"{str}{await StartListen()}";

                    return res;
                }
            }
            return "Connection Closed!";
        }

        public async Task<string> StartListenStream()
        {
            while (_ws.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[8000]);
                {
                    var result = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer.Array), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                    var str = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    var res = result.EndOfMessage ? str : $"{str}{await StartListen()}";
                    Console.WriteLine(res);
                }
                try
                {
                    CancellationToken token = new CancellationToken(true);
                    await Task.Delay(5000, token);
                }
                catch (TaskCanceledException taskEx)
                {
                    //throw;
                }
            }
            return "Connection Closed!";
        }

        public async Task<string> StopListenStreamAll()
        {
            while (_ws.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[8000]);
                {
                    var result = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer.Array), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                    var str = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    var res = result.EndOfMessage ? str : $"{str}{await StartListen()}";
                    return res;
                }
            }
            return "Connection Closed!";
        }


        public async Task Connect()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            
            await _ws.ConnectAsync(_uri, CancellationToken.None);
        }
    }
}