using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Schedule
    {

        public bool[][] data = new bool[5][];

        public Schedule()
        {
            for (int i = 0; i < 5; i++)
            {
                data[i] = new bool[6];
            }
        }

        public Schedule(bool[][] data)
        {
            this.data = data;
        }

        public Schedule Clone()
        {
            Schedule result = new Schedule((bool[][])this.data.Clone());
            return result;
        }
        public override string ToString()
        {
            int starttime = 9;
            bool oved = false;
            string result = null;
            string hayom = null;
            for (int i = 0; i < 5; i++)
            {
                oved = false;
                hayom = null;
               
                for (int j = 0; j < 6; j++)
                {
                    if (data[i][j] == true)
                    {
                        oved = true;
                        hayom += "\t" + (starttime + j) + ":00-";
                        hayom += (starttime + j + 1).ToString() + ":00  ";
                    }
                    else
                        hayom += "\t\t             ";
                }
                if (oved == true)
                {
                    if (i==3||i==4)
                    {
                        result += "\n" + ((Day)i).ToString() ;
                        result += hayom;

                    }
                    else
                    {
                    result += "\n"+((Day)i).ToString() + "\t";
                    result += hayom;
                    }
                }
            }
            if (result == null)
                return "";
            return result.Substring(0, result.Length - 1);

        }
    }
}