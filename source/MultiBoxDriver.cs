using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midiKeyboarder
{
    public class MultiBoxDriver
    {
        public KeyboardDriver keybddriver { get; set; }
        
        System.Net.Sockets.TcpClient xclient;
        System.Net.Sockets.TcpListener server;
        public void start(int port)
        {
          server  = new System.Net.Sockets.TcpListener(port);
            server.Start();
            server.BeginAcceptTcpClient(onClientConnect, server);
        }
        bool killServer = false;
        public void stop()
        {
            killServer = true;
            
           if(server != null)
               server.Stop();


        }
        void onClientConnect(IAsyncResult res)
        {
            if (killServer)
                return;
            var listener = (System.Net.Sockets.TcpListener)res.AsyncState;
            var client = (System.Net.Sockets.TcpClient)listener.EndAcceptTcpClient(res);
            listener.BeginAcceptTcpClient(onClientConnect, listener);
            //G1
            while (client.Connected)
            {
                string smsg;
                byte[] msg = new byte[256];
                int len = client.GetStream().Read(msg, 0, 256);
                if (msg[0] == 0) continue;
                smsg = ASCIIEncoding.ASCII.GetString(msg);
               
                System.Diagnostics.Trace.WriteLine("recv from server " + smsg);
                if (smsg != string.Empty)
                {
                    if (keybddriver != null)
                        keybddriver.play(smsg);
                }
            }
        }
    }
}
