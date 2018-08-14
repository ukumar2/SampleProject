using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Project.Api.Utilities
{
    public class StringFormatHelper
    {
        /// <summary>
        /// Helper method to parse bool value
        /// </summary>
        /// <param name="value">value as string type</param>
        /// <returns></returns>
        public static bool ParseToBool(string value)
        {
            bool returnVal = false;
            if (!string.IsNullOrEmpty(value))
            {
                if (bool.TryParse(value, out returnVal) == false)
                {
                    Logger.LogInformation.LogError(string.Format("ParseToBool didn't worked fine for the data: {0}", value));
                }
            }
            return returnVal;
        }

        /// <summary>
        /// Helper method to parse int value
        /// </summary>
        /// <param name="value">value as string type</param>
        /// <returns></returns>
        public static int ParseToInt(string value)
        {
            int returnVal = 0;
            if (!string.IsNullOrEmpty(value))
            {
                if (int.TryParse(value, out returnVal) == false)
                {
                    Logger.LogInformation.LogError(string.Format("ParseToInt didn't worked fine for the data: {0}", value));
                }
            }
            return returnVal;
        }

    }
}
