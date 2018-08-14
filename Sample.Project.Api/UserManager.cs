using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Project.Api.Objects;
using Sample.Project.Api.Utilities;
using Sample.Project.Logger;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sample.Project.Api
{
    /// <summary>
    /// This public methods can be called from any console app or web pages.
    /// </summary>
    public class UserManager
    {
        #region Public Methods for different clients

        /// <summary>
        /// Get List of all user profiles
        /// </summary>
        /// <returns>generic list of user profile objects</returns>
        public UserProfileData[] GetAllUsers()
        {
            return this.GetAllUserProfiles();
        }

        /// <summary>
        /// This method is used to Create new user in the system
        /// </summary>
        /// <param name="newUserData"></param>
        /// <returns></returns>
        public bool CreateNewUser(UserProfileData newUserData)
        {
            return this.AddUserData(newUserData);
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Helper method to Get All existing Users in the Database
        /// </summary>
        /// <returns>generic list of user profile obj</returns>
        private UserProfileData[] GetAllUserProfiles()
        {
            if (_isDebugEnabled)
                LogInformation.LogInfor(string.Format("Request came in for GetAllUserProfiles at {0}", DateTime.Now.ToString("MM/dd/yyy H:mm:ss zzz")));

            List<UserProfileData> profileList = null;

            //return as no Sql tables & procs are defined.
            return null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string procName = "Get_All_Users_List";//assuming their is a proc already defined

                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = procName;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlConnection.Open();
                        var reader = sqlCommand.ExecuteReader();
                        profileList = new List<UserProfileData>();

                        if (reader.HasRows && _isDebugEnabled)
                        {
                            LogInformation.LogInfor(string.Format("Data found for the Request GetAllUserProfiles"));
                        }

                        while (reader.Read())
                        {
                            //only working on FirstName, Lastname, Email...
                            var u = new UserProfileData()
                            {
                                FirstName = reader["FirstName"] is DBNull ? null : reader["FirstName"].ToString(),
                                LastName = reader["LastName"] is DBNull ? null : reader["LastName"].ToString(),
                                EmailAddress = reader["EmailAddress"] is DBNull ? null : reader["EmailAddress"].ToString()
                            };
                            profileList.Add(u);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInformation.LogError(string.Format("{0}:{1}", ex.Message, ex.StackTrace));
                return null;
            }

            if (_isDebugEnabled)
                LogInformation.LogInfor(string.Format("Request completed for GetAllUserProfiles at {0}", DateTime.Now.ToString("MM/dd/yyy H:mm:ss zzz")));

            if (profileList != null)
                return profileList.ToArray();

            return null;
        }

        /// <summary>
        /// This method is used to add new user data in the system
        /// </summary>
        /// <param name="uData"></param>
        /// <returns></returns>
        private bool AddUserData(UserProfileData uData)
        {
            bool status = false;

            if (_isDebugEnabled)
                LogInformation.LogInfor(string.Format("Request came in for AddUserData at {0}", DateTime.Now.ToString("MM/dd/yyy H:mm:ss zzz")));

            //return as no Sql tables & procs are defined.
            return false;

            if (uData == null)
            {
                if (_isDebugEnabled)
                    LogInformation.LogInfor("User data come as null obj");
                return false;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string procName = "Add_User_Profile";//Assuming proc is already in db
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = procName;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Clear();
                        //only working on FirstName, Lastname, Email...
                        sqlCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = uData.FirstName;
                        sqlCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = uData.LastName;
                        sqlCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = uData.EmailAddress;
                        sqlConnection.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        if (reader > 0 && _isDebugEnabled)
                        {
                            LogInformation.LogInfor("User data added succefully in the system");
                            status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInformation.LogError(string.Format("{0}:{1}", ex.Message, ex.StackTrace));
                status = false;
            }
            return status;
        }


        private string _connectionString = ConfigurationManager.ConnectionStrings["Sample.Project.Data.SqlconnectionStr"] != null ? ConfigurationManager.ConnectionStrings["Sample.Project.Data.SqlconnectionStr"].ConnectionString : "";
        private bool _isDebugEnabled = StringFormatHelper.ParseToBool(ConfigurationManager.AppSettings["LogDebugInformation"]);

        #endregion
    }
}
