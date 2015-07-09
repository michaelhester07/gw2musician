﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midiKeyboarder
{
    public class instrument
    {
        public string ip;
        public int port;
        public bool local;
        public bool flat;
        KeyboardDriver gw2KeyDriver;

        public instrument()
        {
            mytype = instrumentType.standard; 

        }
        public void initKeyDriver()
        {
            gw2KeyDriver = new KeyboardDriver();
            gw2KeyDriver.targetKey = "C";
            gw2KeyDriver.bass = mytype == instrumentType.bass;
            gw2KeyDriver.flute = mytype == instrumentType.flute;
            gw2KeyDriver.flat = false;
            gw2KeyDriver.transposeDirection = 0;

        }
        public static enum instrumentType
        {
            standard, //guitar, harp, trumpet, bell
            flute,
            bass,
            drum
        }
        instrumentType mytype;

        MultiBoxDriver client;

        bool connected = false;


        public void connect()
        {
            client.connectClient(ip, port);
            connected = true;
        }


        public void disconnect()
        {
            client.closeConnection();
        }

       public static System.Xml.XmlElement save(System.Xml.XmlDocument doc, List<instrument> instrumentList)
        {
            /* public string ip;
        public int port;
        public bool local;
        public bool flat;
        */
            System.Xml.XmlElement instruments = doc.CreateElement("instruments");
           foreach(instrument i in instrumentList)
           {
               System.Xml.XmlElement ele = doc.CreateElement("instrument");
               ele.SetAttribute("ip", i.ip);
               ele.SetAttribute("port", i.port.ToString());
               ele.SetAttribute("local", i.local.ToString());
               ele.SetAttribute("flat", i.flat.ToString());
               ele.SetAttribute("type", System.Enum.GetName(typeof(instrumentType), i.mytype));
               instruments.AppendChild(ele);

           }
           return instruments;

        }
       public static List<instrument> Load(System.Xml.XmlElement parent)
       {
           var instrumentlist = parent.GetElementsByTagName("instrument");
           List<instrument> ret = new List<instrument>();
           foreach (System.Xml.XmlElement ele in instrumentlist)
           {
               instrument i = new instrument();
               i.mytype = (instrumentType)System.Enum.Parse(typeof(instrumentType), ele.GetAttribute("type"));
               i.ip = ele.GetAttribute("ip");
               i.port = int.Parse(ele.GetAttribute("port"));
               i.local = bool.Parse(ele.GetAttribute("local"));
               i.flat = bool.Parse(ele.GetAttribute("flat"));
               ret.Add(i);

           }
           return ret;

       }

    }
}