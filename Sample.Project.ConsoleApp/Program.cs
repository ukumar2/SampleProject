using Sample.Project.Api.Utilities;
using Sample.Project.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Project.ConsoleApp
{
    class Program
    {
        #region Public Methods

        public static void Main(string[] args)
        {
            if (_isDebugEnabled)
                LogInformation.LogInfor(string.Format("Sample Console app started at {0}", DateTime.Now.ToString("MM/dd/yyy H:mm:ss zzz")));

            if (_isWriteToDbEnabled)
            {
                if (_isDebugEnabled)
                    LogInformation.LogInfor("Process Db Write Request");

                ProcessDbWriteRequest();
            }
            else
            {
                if (_isDebugEnabled)
                    LogInformation.LogInfor("Process Console App Request");

                ProcessAppRequest();
            }


            Console.WriteLine("Hello World...");
            Console.WriteLine("Console app processing Completed!!!");
            Console.ReadKey();

            if (_isDebugEnabled)
                LogInformation.LogInfor(string.Format("Sample Console app Completed at {0}", DateTime.Now.ToString("MM/dd/yyy H:mm:ss zzz")));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// If the user select to process as Console app which is by default
        /// </summary>
        private static void ProcessAppRequest()
        {
            Console.WriteLine("Console App mode is selected by default!!!");
        }

        /// <summary>
        /// If the request is to save User data to database
        /// </summary>
        private static void ProcessDbWriteRequest()
        {
            Console.WriteLine("Access to User profile data through the API has been selected!!!");

            //get all list of Users in the system using API
            var userMngr = new Api.UserManager();
            var allUserProfiles = userMngr.GetAllUsers();
            if(allUserProfiles != null && allUserProfiles.Any())
            {
                //bind to web pages or write basic info on console
            }


            //Save new User in the system using API
            var userProfileData = new Api.Objects.UserProfileData() { FirstName = "FIRSTNAME", LastName= "LASTNAME", EmailAddress="TEST@TEST.COM" };
            var status = userMngr.CreateNewUser(userProfileData);
            if(status)
            {
                //user saved succefully...
            }
        }

        private static bool _isDebugEnabled = StringFormatHelper.ParseToBool(ConfigurationManager.AppSettings["LogDebugInformation"]);
        private static bool _isWriteToDbEnabled = StringFormatHelper.ParseToBool(ConfigurationManager.AppSettings["WriteToDataBase"]);

        #endregion
    }
}
