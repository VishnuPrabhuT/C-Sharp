using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin.classes
{
    public class ScriptManager
    {
        static private bool getPOSChanges(out string outMessage, out string fileContents)
        {
            outMessage = "Success"
            fileContents = "marlbro is now $1.99";
            return true
        }
        static private bool sendFileToPOS(string inFileContents, out string outMessage)
        {
            //write to POS!!!
            return true;
        }
        static public bool performPriceChange(out string outMessage)
        {
            bool isOppSuccesful = false;
            string strMessage = "";
            string strFileContents = "";
            if (getPOSChanges(out strMessage, out strFileContents))
            {
                if (sendFileToPOS(strFileContents, out strMessage))
                {
                    isOppSuccesful = true;
                    //TODO:  Update value of BufferClass.latestDate to current date.
                }
                else
                {
                    isOppSuccesful = false;
                    //strMessage set in out param
                }
            }
            else
            {
                isOppSuccesful = false;
                //strMessage set in out param

            }
            outMessage = strMessage;
            return isOppSuccesful;
        }


    }
}
