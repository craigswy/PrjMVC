using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrjMVC.Entity
{
    public class EntityProfileList : EntityProfile
    {
        public EntityProfileList(string connectionString, string providerName)
        {
        }

        #region - 輸入參數 -
        public enum ProfileListPara
        {
            pro_UID,
            pro_Status,
            pro_Name,
            pro_DOB,
            pro_Tel1,
            pro_Tel2,
            pro_Address,
            pro_StfnID,
            pro_ArrivedDate,
            pro_Email            
        }

        public string pro_UID;
        public string pro_Status;
        public string pro_Name;
        public string pro_DOB;
        public string pro_Tel1;
        public string pro_Tel2;
        public string pro_Address;
        public string pro_StfnID;
        public string pro_ArrivedDate;
        public string pro_Email;

        #endregion - 輸入參數 -  

        #region - 輸出參數 -
        public class ProfileList
        {
            public string pro_UID;
            public string pro_Status;
            public string pro_Name;
            public string pro_DOB;
            public string pro_Tel1;
            public string pro_Tel2;
            public string pro_Address;
            public string pro_StfnID;
            public string pro_ArrivedDate;
            public string pro_Email;
        }
        #endregion - 輸出參數 -

        #region - 取值 -

        public List<ProfileList> SelectProfileList(ProfileListPara para)
        {
            string connectionString =
                   "Data Source=.;Initial Catalog=Project;Integrated Security=True";
            List<ProfileList> profiles = new List<ProfileList>();

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();                
                string commandText = string.Join(Environment.NewLine,
                    "SELECT pro_UID",
                    "     , pro_Status",
                    "     , pro_Name",
                    "     , pro_DOB",
                    "     , pro_Tel1",
                    "     , pro_Tel2",
                    "     , pro_Address",
                    "     , pro_StfnID",
                    "     , pro_ArrivalDate",
                    "     , pro_Email",
                    "  FROM DBO.StfnProfile;"
                );

                SqlCommand command = new SqlCommand(commandText, conn);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) 
                {
                    ProfileList profile = new ProfileList
                    {
                        pro_UID = reader["pro_UID"].ToString(),
                        pro_Status = reader["pro_Status"].ToString(),
                        pro_Name = reader["pro_Name"].ToString(),
                        pro_DOB = reader["pro_DOB"].ToString(),
                        pro_Tel1 = reader["pro_Tel1"].ToString(),
                        pro_Tel2 = reader["pro_Tel2"].ToString(),
                        pro_Address = reader["pro_Address"].ToString(),
                        pro_StfnID = reader["pro_StfnID"].ToString(),
                        pro_ArrivedDate = reader["pro_ArrivalDate"].ToString(),
                        pro_Email = reader["pro_Email"].ToString()
                    };
                    profiles.Add(profile);
                }                
            }
            return profiles;
        }
        #endregion - 取值 -
    }
}