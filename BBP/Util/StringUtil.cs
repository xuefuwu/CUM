using System;

using System.Linq;

namespace BBP
{
    public class StringUtil
    {

        public static int[] GetIntArrayFromString(string commaSeparatedString)
        {
            if (String.IsNullOrEmpty(commaSeparatedString))
            {
                return new int[0];
            }
            else
            {
                return commaSeparatedString.Split(',').Select(s => Convert.ToInt32(s)).ToArray();
            }
        }


    }
}
