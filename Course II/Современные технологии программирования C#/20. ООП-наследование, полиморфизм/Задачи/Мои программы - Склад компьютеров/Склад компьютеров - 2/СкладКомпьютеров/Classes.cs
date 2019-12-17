using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace СкладКомпьютеров
{
     public class Store
    {
        public ArrayList storemas = new ArrayList();
        public ArrayList regnummas = new ArrayList();
         public static Computer SearchComputerNum(Store store,string RegNumber)
         {
                         for (int i = 0; i < store.storemas.Count; i++)
                         {
                             if (RegNumber == ((Computer)store.storemas[i]).RegNumber)
                             {
                                 return ((Computer)store.storemas[i]);
                             }
                         }
                         MessageBox.Show("Компьютеров с таким регистрационным номером не обнаружено");
                         return null;
         }

         public static ArrayList SearchComputerName(Store store, string Name)
         {
             ArrayList mas = new ArrayList();
                         for (int i = 0; i < store.storemas.Count; i++)
                         {
                             if (Name == ((Computer)store.storemas[i]).FIO)
                             {
                              mas.Add(store.storemas[i]);  
                             }
                         }
                         if (mas.Count != 0)
                         {

                             return mas;
                         }
                         else
                         {
                             MessageBox.Show("Компьютеров с таким Ф.И.О. владельца не обнаружено");
                             return null;
                         }
         }
  }
         
  

    public class Computer
    {
        private string brand,type,regnumber,fio="На складе";
        private Video video;
        private CenterBlock centerblock;
        private Perepherals perepherals;

        public Computer(string brand, string type, string monitortype,
            uint videomemory, string processortype, uint speed, uint diskspace,
            uint ramcap, uint keyboardbuttons, uint mousebuttons, string printertype)
        {
            this.brand = brand;
            this.type = type;
            video = new Video(monitortype, videomemory);
            centerblock = new CenterBlock(processortype, speed, diskspace, ramcap);
            perepherals = new Perepherals(keyboardbuttons, mousebuttons, printertype);
        }
        public string FIO
        {
            get
            {
                return fio;
            }
            set
            {
                if (fio == "На складе")
                {
                    fio = value;
                }
                else
                {
                    MessageBox.Show("Этот компьютер уже выдан.");
                }
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

        public string RegNumber
        {
            set
            {
                if (regnumber == null)
                {
                    if (centerblock.Speed >= 3000)
                    {
                        value += "S";
                    }
                    else if (centerblock.Speed < 3000 && centerblock.Speed >= 2500)
                    {
                        value += "A";
                    }
                    else if (centerblock.Speed < 2500 && centerblock.Speed >= 2000)
                    {
                        value += "B";
                    }
                    else if (centerblock.Speed < 2000 && centerblock.Speed >= 1500)
                    {
                        value += "C";
                    }
                    else if (centerblock.Speed < 1500 && centerblock.Speed >= 1000)
                    {
                        value += "D";
                    }
                    else if (centerblock.Speed < 1000 && centerblock.Speed >= 500)
                    {
                        value += "E";
                    }
                    else if (centerblock.Speed < 500)
                    {
                        value += "F";
                    }
                    regnumber = value;
                }
                else
                    return;
            }
            get
            {
                return regnumber;
            }
        }

        public Video Video
        {
            get
            {
                return video;
            }
        }

        public CenterBlock CenterBlock
        {
            get
            {
                return centerblock;
            }
        }

        public Perepherals Perepherals
        {
            get
            {
                return perepherals;
            }
        }
     }

    public class Video
    {
        private string monitortype;
        private uint videomemory;

        public Video(string monitortype, uint videomemory)
        {
            this.monitortype = monitortype;
            this.videomemory = videomemory;
        }

        public string MonitorType
        {
            get
            {
                return monitortype;
            }
        }

        public uint VideoMemory
        {
            get
            {
                return videomemory;
            }
        }
    }

    public class CenterBlock
    {
        private string processortype;
        private uint speed, diskspace, ramcap;

        public CenterBlock(string processortype, uint speed, uint diskspace, uint ramcap)
        {
            this.processortype = processortype;
            this.speed = speed;
            this.diskspace = diskspace;
            this.ramcap = ramcap;
        }

        public string ProcessorType
        {
            get
            {
                return processortype;
            }
        }

        public uint Speed
        {
            get
            {
                return speed;
            }
        }

        public uint DiskSpace
        {
            get
            {
                return diskspace;
            }
        }

        public uint RAMCap
        {
            get
            {
                return ramcap;
            }
        }
    }

    public class Perepherals
    {
        private uint keyboardbuttons, mousebuttons; 
        private string printertype;

        public Perepherals(uint keyboardbuttons,uint mousebuttons,string printertype)
        {
            this.keyboardbuttons = keyboardbuttons;
            this.mousebuttons = mousebuttons;
            this.printertype = printertype;
        }

        public uint KeyboardButtons
        {
            get
            {
                return keyboardbuttons;
            }
        }

        public uint MouseButtons
        {
            get
            {
                return mousebuttons;
            }
        }

        public string PrinterType
        {
            get
            {
                return printertype;
            }
        }
    }
}
