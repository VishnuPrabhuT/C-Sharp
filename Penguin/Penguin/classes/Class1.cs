using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin.classes
{
    public class BufferLayer
    {
        public static string latestDate { get { return "abc";//hit DB & get values }; internal set; }

        string getDBData()
        {
            return "Arif made the last update";
        }
        public static bool updatePricebook()
        {
            bool isOppSuccsful = false;
            string strMessage = "";
            if (classes.ScriptManager.performPriceChange(out strMessage))
            {
                latestDate = System.DateTime.UtcNow.ToString();
                isOppSuccsful = true;
            }
            else
            {
                isOppSuccsful = false;
            }
            return isOppSuccsful;
        }
        public static bool updatePricebook()
        {
            bool isOppSuccsful = false;
            string strMessage = "";
            if (classes.ScriptManager.performPriceChange(out strMessage))
            {
                isOppSuccsful = true;
            }
            else
            {
                isOppSuccsful = false;
            }
            return isOppSuccsful;
        }
    }
}
