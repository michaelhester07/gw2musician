﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace midiKeyboarder
{
    public class section
    {
        public void render(Graphics target)
        {


        }

        public class note: object 
        {
           public  string pitch;
           public  float time;
           public float duration;
           public float monitorOn;
           public bool playing = false;
            public note()
           {
               pitch = "A0";
               time = 0;
               duration = 0;
           }
            //lol duration
        }
        public object sectionLock;// = new object();
        public int instrumentid;
        public List<note> notes;

        public Stack<List<note>> undo;

        public string name;
        public float starttime;
        public section ()
        {
            sectionLock = new object();
            notes = new List<note>();
            undo = new Stack<List<note>>();
        }
        public void pushUndo()
        {
            List<note> currentState = new List<note>();
            foreach(note n in notes)
            {
                note c = new note();
                c.duration = n.duration;
                c.pitch = n.pitch;
                c.time = n.time;
                currentState.Add(c);
            }
            undo.Push(currentState);
        }
        public void popUndo()
        {
            if (undo.Count > 0)
            {
                var lastState = undo.Pop();
                notes.Clear();
                foreach(note n  in lastState)
                {
                    note c = new note();
                    c.duration = n.duration;
                    c.pitch = n.pitch;
                    c.time = n.time;
                    notes.Add(c);
                }
            }
        }
        public note addNote(string pitch, float time, float duration)
        {
            lock (sectionLock)
            {
                note n = new note();
                n.pitch = pitch;
                n.time = time;
                n.duration = duration;
                notes.Add(n);
                return n;
            }
        }
        public void removeNote(int id)
        {
            notes.RemoveAt(id);

        }
        //use a high enough resolution for the sequencer
        public note[] play(float timeA, float timeB)
        {
            //return a list of notes between the times listed
            List<note> retnotes = new List<note>();
            foreach(note n in notes)
            {
                if (n.time > timeA && n.time < timeB)
                    retnotes.Add(n);
            }
            return retnotes.ToArray();
        }


        public  static System.Xml.XmlElement save(System.Xml.XmlDocument doc, List<section> sections)
        {
            System.Xml.XmlElement ret = doc.CreateElement("Sections");
            foreach(section s in sections)
            {
                System.Xml.XmlElement sec = doc.CreateElement("section");
                sec.SetAttribute("name", s.name);
                sec.SetAttribute("instrumentID", s.instrumentid.ToString());
                sec.SetAttribute("startTime", s.starttime.ToString());
                foreach(note n in s.notes)
                {
                    System.Xml.XmlElement xnote = doc.CreateElement("note");
                    xnote.SetAttribute("pitch", n.pitch);
                    xnote.SetAttribute("time", n.time.ToString());
                    xnote.SetAttribute("duration", n.duration.ToString());
                    sec.AppendChild(xnote);
                }
                ret.AppendChild(sec);

            }
            return ret;
        }
        public static List<section> Load(System.Xml.XmlElement parent)
        {
            var elementList = parent.GetElementsByTagName("section");
            List<section> sections = new List<section>();
            foreach (System.Xml.XmlElement e in elementList)
            {
                section s = new section();
                s.name = e.GetAttribute("name");
                s.instrumentid = int.Parse(e.GetAttribute("instrumentID"));
                s.starttime = float.Parse(e.GetAttribute("startTime"));
                var notes = e.GetElementsByTagName("note");
                foreach(System.Xml.XmlElement n in notes)
                {
                    note nx = new note();
                    nx.pitch = n.GetAttribute("pitch");
                    nx.time = float.Parse(n.GetAttribute("time"));
                    nx.duration = float.Parse(n.GetAttribute("duration"));
                    s.notes.Add(nx);
                }
                sections.Add(s);

            }
            return sections;
        }
    }
}
