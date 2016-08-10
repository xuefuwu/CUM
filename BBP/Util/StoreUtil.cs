using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBP.Util
{
    public class StoreUtil
    {
        private static String[] StoreType = { "A", "B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
        private int StoreNum = 20;
        private List<String> StoreStack = new List<String>();
        public StoreUtil()
        {
            foreach (String StorePre in StoreType)
            {
                for (int i = 1; i <= StoreNum; i++)
                {
                    StoreStack.Add(StorePre + i);
                }
            }
        }
        public List<String> getEmptyStack(List<String> inStore)
        {
            
            inStore.ForEach(s => StoreStack.Remove(s));
            return StoreStack;
        }
    }
}