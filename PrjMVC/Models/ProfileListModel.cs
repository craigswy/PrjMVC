using PrjMVC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
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

        public List<ProfiltView> ProfileList { get; set; }

        #endregion - Property -
        #region - Private -

        #endregion - Private -

        #region - Validation -
        #endregion - Validation -

        #region - 表單預設值 -
        #endregion - 表單預設值 -

        #region - 設定系統參數 -
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
                    string tempStatus = !string.IsNullOrEmpty(item.pro_Status) ? item.pro_Status : string.Empty;
                    string tempArrival = !string.IsNullOrEmpty(item.pro_ArrivedDate) ? item.pro_ArrivedDate : string.Empty;

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
                        ArrivedDate = tempArrival
                    });
                }              
            }
        }
        #endregion - 取得資料 -
    }
}