using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UBHUtilsLib.UBHUtils;
using UBH.RWDTemplate.BLL;
using UBH.RWDTemplate.Models;

namespace UBH.RWDTemplate.Menu
{
    /// <summary>
    /// Used to generate HTML markup for Bootstrap v3.1.1
    /// </summary>
    public class BootstrapTransform
    {
        //these strings represent the classes used to generate the icons
        private readonly string BOOTSTRAP_CLASS_KPI_ICON = "glyphicon glyphicon-signal";
        private readonly string BOOTSTRAP_CLASS_WORKFLOW_ICON = "glyphicon glyphicon-inbox";

        #region Constructors
        public BootstrapTransform()
        {
        }
        #endregion

        #region Public Methods
        public string GetNavbarBeginTag()
        {
            //start the unordered list and add the Bootstrap classes to it
            var emitHTML = "<ul class=\"nav navbar-nav\">";
            return emitHTML;
        }

        public string GetNavbarEndTag()
        {
            //close the unordered list
            var emitHTML = "</ul>";
            return emitHTML;
        }

        /// <summary>
        /// Gets the HTML to create a menu element that has no children menu items.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        /// <returns>A formatted <li></li> tag."</returns>
        public string GetNonDropDownHTML(MenuItem menuItem)
        {
            //initialize the html to return
            StringBuilder markup = new StringBuilder("<li>");

            //add the anchor tag for the link
            if (!string.IsNullOrEmpty(menuItem.URL))
            {
                markup.Append("<a href=\"");
                markup.Append(menuItem.URL.Trim());
                markup.Append("\">");

                //add a class if one is specified
                if (!string.IsNullOrEmpty(menuItem.Class))
                {
                    markup.Append("<span class=\"");
                    markup.Append(menuItem.Class.Trim());
                    markup.Append("\">");

                    //add the label
                    if (!string.IsNullOrEmpty(menuItem.Label))
                    {
                        markup.Append(menuItem.Label.Trim());
                    }
                    markup.Append("</span>");

                    //check for special classes for KPI Notifications and Workflows
                    //if they exist an additional span is created with the total notifications and workflows
                    if (menuItem.Class.Contains(BOOTSTRAP_CLASS_KPI_ICON))
                    {
                        markup.Append(GetKPINotificationSpan());
                    }
                    if (menuItem.Class.Contains(BOOTSTRAP_CLASS_WORKFLOW_ICON))
                    {
                        markup.Append(GetWorkflowsSpan());
                    }
                }
                //close the anchor tag
                markup.Append("</a>");
            }

            //add closing tag
            markup.Append("</li>");
            return markup.ToString();
        }

        /// <summary>
        /// Gets the HTML for a menu item that also has children menu items.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        /// <returns>A formatted <li></li> tag."</returns>
        public string GetDropDownHTML(MenuItem menuItem)
        {
            //initialize the html to return
            StringBuilder markup = new StringBuilder("<li class=\"dropdown\">");

            //add the anchor tag for top level
            markup.Append("<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">");
            if (!string.IsNullOrEmpty(menuItem.Label))
            {
                markup.Append(menuItem.Label.Trim());
            }
            markup.Append("<b class=\"caret\"></b></a>");

            //get the collection of sub menu items
            List<MenuItem> subMenuItems = MenuItemBLL.GetListByParentId(menuItem.Identity);

            //create markup for the submenu items
            markup.Append("<ul class=\"dropdown-menu\">");
            foreach (MenuItem subItem in subMenuItems)
            {
                markup.Append("<li>");
                markup.Append("<a href=\"");
                markup.Append(subItem.URL);
                markup.Append("\">");
                if (!string.IsNullOrEmpty(subItem.Label))
                {
                    markup.Append(subItem.Label);
                }
                markup.Append("</a>");
                markup.Append("</li>");
            }
            markup.Append("</ul>");

            //add closing tag
            markup.Append("</li>");
            return markup.ToString();
        }

        /// <summary>
        /// Gets the KPI notifications for the current user and formats it as a <span>.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Number of pending notifications as a string.</returns>
        public string GetKPINotificationSpan()
        {
            int userId = UBHLogon.GetLogonUserId();
            string notificationLabel = string.Empty;
            try
            {
                //get the number of KPI's for the currently logged in user
                UBHNotification kpiNotification = new UBHNotification();
                int kpiNotifications = kpiNotification.GetPendingKPINotifications(userId);
                //do not display more than 2 digits
                if (kpiNotifications > 99)
                {
                    notificationLabel = "<span class=\"kpi-label\">99+</span>";
                }
                else
                {
                    notificationLabel = "<span class=\"kpi-label\">" + kpiNotifications.ToString() + "</span>";
                }
            }
            catch (Exception)
            {
                notificationLabel = "NA";
            }

            return notificationLabel;
        }

        /// <summary>
        /// Gets the pending workflows for the current user and formats it as a <span>.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public string GetWorkflowsSpan()
        {
            int userId = UBHLogon.GetLogonUserId();
            string workflowsLabel = string.Empty;

            try
            {
                //get the number of workflows for the currently logged in user
                UBHWorkflow workflow = new UBHWorkflow();
                int workflowNotifications = workflow.GetNumberOfWorkflowsWaitingOnEmployee(userId);

                //do not display more than 2 digits
                if (workflowNotifications > 99)
                {
                    workflowsLabel = "<span class=\"workflow-label\">99+</span>";
                }
                else
                {
                    workflowsLabel = "<span class=\"workflow-label\">" + workflowNotifications.ToString() + "</span>";
                }
            }
            catch (Exception)
            {
                //default the notification label if the database is not available
                workflowsLabel = "NA";
            }

            return workflowsLabel;
        }
        #endregion

    }
}