using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;
using UBH.RWDTemplate.BLL;
using UBH.RWDTemplate.Models;

namespace UBH.RWDTemplate.Menu
{
    public class CorporateMenu
    {
        //top level menu items have a parent ID of 0
        private readonly int PARENT_ID = 0;

        //the menu name
        private readonly string MENU_NAME = "Corporate";

        #region Public Methods
        /// <summary>
        /// Gets the mobile friendly HTML for the corporate menu.
        /// </summary>
        /// <returns>Menu formatted as HTML markup.</returns>
        public string GetMobileFriendlyHTML()
        {
            //intialize the output
            StringBuilder outputHTML = new StringBuilder();

            //initial the Bootstrap transformation
            BootstrapTransform bootstrapMenu = new BootstrapTransform();

            //opening tags for the HTML
            outputHTML.Append(bootstrapMenu.GetNavbarBeginTag());

            //get a list of top level menu items
            List<MenuItem> menuItemList = MenuItemBLL.GetListByMenuNameParentId(MENU_NAME, PARENT_ID);

            //process each top level menu item
            foreach (var item in menuItemList)
            {
                //create dropdown menu if the top level item has children 
                if (MenuItemBLL.MenuItemHasChildren(item.Identity))
                {
                    outputHTML.Append(bootstrapMenu.GetDropDownHTML(item));
                }
                else
                {
                    //top level menu item only
                    outputHTML.Append(bootstrapMenu.GetNonDropDownHTML(item));
                }
            }
            //add closing tags
            bootstrapMenu.GetNavbarEndTag();

            return outputHTML.ToString();
        }
        #endregion

    }

}