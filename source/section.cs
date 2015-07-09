using System;
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

        public class note
        {
           public  string pitch;
           public  float time;
           public float duration;
            public note()
           {
               pitch = "A0";
               time = 0;
               duration = 0;
           }
            //lol duration
        }

        public int instrumentid;
        public List<note> notes;
        public string name;

        public section ()
        {
            notes = new List<note>();
        }

        public void addNote(string pitch, float time)
        {
            note n = new note();
            n.pitch = pitch;
            n.time = time;
            notes.Add(n);

        }
        public void removeNote(int id)
        {
            notes.RemoveAt(id);

        }
        //use a high enough resolution for the sequencer
        public string [] play(float timeA, float timeB)
        {
            //return a list of notes between the times listed
            List<string> retnotes = new List<string>();
            foreach(note n in notes)
            {
                if (n.time > timeA && n.time < timeB)
                    retnotes.Add(n.pitch);
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
                foreach(note n in s.notes)
                {
                    System.Xml.XmlElement xnote = doc.CreateElement("note");
                    xnote.SetAttribute("pitch", n.pitch);
                    xnote.SetAttribute("time", n.time.ToString());
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
                var notes = e.GetElementsByTagName("note");
                foreach(System.Xml.XmlElement n in notes)
                {
                    note nx = new note();
                    nx.pitch = n.GetAttribute("pitch");
                    nx.time = float.Parse(n.GetAttribute("time"));
                    nx.duration = float.Parse(n.GetAttribute("duration"));
                    s.notes.Add(nx);
                }

            }
            return sections;
        }
    }
}
