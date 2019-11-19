using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_MJ
{
    class Preprocessing
    {
        Metrics[] Objects;
        int numVers;
        int[] GeneralList;

        public Preprocessing(Metrics[] ObjectList)
        {
            this.Objects = ObjectList;
            this.numVers = ObjectList.Length;
            this.GeneralList = new int[this.numVers];
        }

        public int[] GetAll_MI()
        {
            return ArrayCreator(0);
        }

        public int[] GetAll_CYC()
        {
            return ArrayCreator(1);
        }

        public int[] GetAll_CLC()
        {
            return ArrayCreator(2);
        }

        public int[] GetAll_DI()
        {
            return ArrayCreator(3);
        }

        public int[] GetAll_SL()
        {
            return ArrayCreator(4);
        }

        public int[] GetAll_EL()
        {
            return ArrayCreator(5);
        }

        public int[] ArrayCreator(int metricNum)
        {
            int i;
            for (i = 0; i < numVers; i++)
            {
                GeneralList[i] = Objects[i].GetAll()[metricNum];
            }
            return GeneralList;

        }

        public void CreateTextFile()
        {

        }
    }
}
