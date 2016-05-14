using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WakeMeUp.WebApp
{
    public class WakeUpService 
    {
        public WakeUpService()
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 33333);
            _listener.Start();

        }

        ManualResetEvent _event = new ManualResetEvent(false);
        private volatile int HaveMessage = 0;
        private string Message;
        
        public void SendMessage(string message)
        {
            var i = HaveMessage;
            Message = message;
            HaveMessage = 1;
            _event.Reset();
        }

        private async void StartAccepting()
        {
            var client = await _listener.AcceptTcpClientAsync();
            _event.WaitOne();
            var message = Message;
            var i = HaveMessage;
            HaveMessage = 0;
        }

        private readonly TcpListener _listener;
    }
}