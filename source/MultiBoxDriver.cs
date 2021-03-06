﻿using System;
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
        string myip;
        int myport;
        public void connectClient(string ip, int port)
        {
            myip = ip;
            myport = port;
            xclient = new System.Net.Sockets.TcpClient();

            System.Net.IPAddress addr = System.Net.IPAddress.Parse(ip);
            xclient.Connect(new System.Net.IPEndPoint(addr, port));
            
        }
        public bool sendMsg(string xmsg)
        {
            string msg = xmsg + ";";
            if(xclient != null)
            {
                if (xclient.Connected)
                {
                    try
                    {
                        System.Diagnostics.Trace.WriteLine("send to client " + msg);
                        xclient.GetStream().Write(ASCIIEncoding.ASCII.GetBytes(msg), 0, msg.Length);
                    }
                    catch
                    {
                        //restart the connection if theres a problem
                        try
                        {
                            xclient.Close();
                        }
                        catch { }

                        connectClient(myip, myport);
                    }
                }
                else
                    return false;

            }
            return true;

        }
        public void closeConnection()
        {
            if (xclient != null)
                if (xclient.Connected)
                    xclient.Close();

        }


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
                try
                {
                    string smsg;
                    byte[] msg = new byte[256];
                    int len = client.GetStream().Read(msg, 0, 256);
                    if (msg[0] == 0) continue;
                    
                    smsg = ASCIIEncoding.ASCII.GetString(msg,0, len);

                    System.Diagnostics.Trace.WriteLine("recv1 from server " + smsg);
                    if (smsg != string.Empty)
                    {
                        string[] notes = smsg.Split(new char[] {';'},  StringSplitOptions.RemoveEmptyEntries);
                        foreach(string n in notes)
                         if (keybddriver != null)
                            keybddriver.play(n);
                    }
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
