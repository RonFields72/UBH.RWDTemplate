using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using UBH.RWDTemplate.BLL;
using UBH.RWDTemplate.Menu;
using UBHUtilsLib.UBHUtils;

namespace UBH.RWDTemplate
{
    public partial class SiteMaster : MasterPage
    {

        #region Properties
        public int LogonUserId
        {
            get { return Convert.ToInt32(ViewState["LogonUserId"]); }
            set { ViewState["LogonUserId"] = value; }
        }
        public string LogonUserName
        {
            get { return ViewState["LogonUserName"].ToString(); }
            set { ViewState["LogonUserName"] = value; }
        }
        #endregion

        #region Protected Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //get user id and name
                LogonUserId = UBHLogon.GetLogonUserId();
                LogonUserName = UBHLogon.GetLogonUser();

                //load html into menu
                CorporateMenu menu = new CorporateMenu();
                litMenuHTML.Text = menu.GetMobileFriendlyHTML();
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Loads a value from the web.config value.
        /// </summary>
        /// <param name="configurationName">Name of the configuration from the xml file.</param>
        /// <returns>The value as a string.</returns>
        private string LoadConfigValue(string configurationName)
        {
            string configString = string.Empty;
            configString = WebConfigurationManager.AppSettings[configurationName].ToString();

            if (!string.IsNullOrEmpty(configString))
            {
                return configString;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}