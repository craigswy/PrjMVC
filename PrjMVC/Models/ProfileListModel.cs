using PrjMVC.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Provider;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace PrjMVC.Models
{
    public class ProfileListModel : ProfileModel
    {
        #region - Definitions -

        public class ProfiltView
        {
            public string UID;
            public string Status;
            public string Name;
            public string DOB;
            public string Tel1;
            public string Tel2;
            public string Address;
            public string StfnID;
            public string ArrivedDate;
            public string Country;
            public string Theme;
            public string Remark;
            public string Record_Date;
            public string City;
            public string Email;
            public string Gender;
        }

        public enum EnumStatus 
        {
            [Description("C")]
            Contacted,

            [Description("0")]
            Accepted,

            [Description("1")]
            Employed,

            [Description("R")]
            Resigned       
        }

        #endregion - Definitions -

        #region - Constructor -
        private readonly EntityProfileList _entityProfileList;
        private readonly string connectionStringPF;
        private readonly string ProviderNamePF;

        public ProfileListModel(string connectionString, string providerName)
        {
            this.connectionStringPF = connectionString;
            this.ProviderNamePF = providerName;
            _entityProfileList = new EntityProfileList(connectionStringPF, ProviderNamePF);
        }
        #endregion - Constructor -

        #region - Property -

        public string SelectStatus { get; set; }

        public List<ProfiltView> ProfileList { get; set; }

        #endregion - Property -

        #region - Private -

        #endregion - Private -

        #region - Validation -
        #endregion - Validation -

        #region - 表單預設值 -
        #endregion - 表單預設值 -

        #region - 設定系統參數 -

        public Dictionary<string, string> DicStatus { get; set; }

        public void SetSysParameter() 
        {
            DicStatus = new Dictionary<string, string> 
            {
                { ProfileModel.GetEnumDesc(EnumStatus.Contacted), EnumStatus.Contacted.ToString()},
                { ProfileModel.GetEnumDesc(EnumStatus.Accepted), EnumStatus.Accepted.ToString()},
                { ProfileModel.GetEnumDesc(EnumStatus.Employed), EnumStatus.Employed.ToString()},
                { ProfileModel.GetEnumDesc(EnumStatus.Resigned), EnumStatus.Resigned.ToString()}        
            };                
        }
        #endregion - 設定系統參數 -

        #region - 取得資料 -
        public void GetDataList() 
        {
            EntityProfileList.ProfileListPara para = new EntityProfileList.ProfileListPara();
            List<EntityProfileList.ProfileList> result = _entityProfileList.SelectProfileList(para);

            if (result != null) 
            {
                ProfileList = new List<ProfiltView>();

                foreach (var item in result) 
                {
                    string tempUID = !string.IsNullOrEmpty(item.pro_UID) ? item.pro_UID : string.Empty;
                    string tempName = !string.IsNullOrEmpty(item.pro_Name) ? item.pro_Name : string.Empty;
                    string tempDOB = !string.IsNullOrEmpty(item.pro_DOB) ? item.pro_DOB : string.Empty;
                    string tempTel1 = !string.IsNullOrEmpty(item.pro_Tel1) ? item.pro_Tel1 : string.Empty;
                    string tempTel2 = !string.IsNullOrEmpty(item.pro_Tel2) ? item.pro_Tel2 : string.Empty;
                    string tempAddr = !string.IsNullOrEmpty(item.pro_Address) ? item.pro_Address : string.Empty;
                    string tempStfn = !string.IsNullOrEmpty(item.pro_StfnID) ? item.pro_StfnID : string.Empty;                    
                    string tempArrival = !string.IsNullOrEmpty(item.pro_ArrivalDate) ? item.pro_ArrivalDate : string.Empty;
                    string tempEmail = !string.IsNullOrEmpty(item.pro_Email) ? item.pro_Email : string.Empty;
                    string tempCountry = !string.IsNullOrEmpty(item.pro_Country) ? item.pro_Country : string.Empty;
                    string tempCity = !string.IsNullOrEmpty(item.pro_City) ? item.pro_City : string.Empty;
                    string tempTheme = !string.IsNullOrEmpty(item.pro_Theme) ? item.pro_Email : string.Empty;
                    string tempRemark = !string.IsNullOrEmpty(item.pro_Remark) ? item.pro_Remark : string.Empty;
                    string tempRecordDate = !string.IsNullOrEmpty(item.pro_Record_Date) ? item.pro_Record_Date : string.Empty;
                    string tempGender = !string.IsNullOrEmpty(item.pro_Gender) ? item.pro_Gender : string.Empty;
                    
                    string tempStatus = string.Empty;
                    if (!string.IsNullOrEmpty(item.pro_Status)) 
                    {
                        switch(item.pro_Status.Trim()) 
                        {
                            case "C":
                                tempStatus = "已通知";
                                break;
                            case "0":
                                tempStatus = "已錄取";
                                break;
                            case "1":
                                tempStatus = "任職中";
                                break;
                            case "R":
                                tempStatus = "已離職";
                                break;                                
                        }           
                    }

                    ProfileList.Add(new ProfiltView()
                    {
                        UID = tempUID,
                        Name = tempName,
                        Status = tempStatus,
                        DOB = tempDOB,
                        Tel1 = tempTel1,
                        Tel2 = tempTel2,
                        Address = tempAddr,
                        StfnID = tempStfn,
                        ArrivedDate = tempArrival,
                        Email = tempEmail,
                        Country = tempCountry,
                        City = tempCity,
                        Theme = tempTheme,
                        Record_Date = tempRecordDate,
                        Remark = tempRemark,
                        Gender = tempGender                        
                    });
                }              
            }
        }
        #endregion - 取得資料 -
    }
}