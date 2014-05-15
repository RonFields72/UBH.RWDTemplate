using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UBH.RWDTemplate.DAL;
using UBH.RWDTemplate.Models;

namespace UBH.RWDTemplate.BLL
{
    public class MenuItemBLL
    {
        #region Constructors
        public MenuItemBLL()
        {
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Gets a single menu item using the identity.
        /// </summary>
        /// <param name="menuItemId">The menu item identity.</param>
        /// <returns>MenuItem object.</returns>
        public static MenuItem GetById(int menuItemId)
        {
            MenuItemDAL menuItems = new MenuItemDAL();
            var theItem = menuItems.GetById(menuItemId);
            return theItem;
        }

        /// <summary>
        /// Gets a list of all the menu items.
        /// </summary>
        /// <returns>Collection of MenuItem objects ordered by identity.</returns>
        public static List<MenuItem> GetList()
        {
            //return a list of all the menu items
            MenuItemDAL menuItems = new MenuItemDAL();
            List<MenuItem> itemList = menuItems.GetAll();

            //order by identity
            if (itemList.Any())
            {
                itemList = itemList.OrderByDescending(x => x.Identity).ToList();
            }

            return itemList;
        }

        public static List<MenuItem> GetListByParentId(int parentId)
        {
            //return a list of all the sub menu items in the correct sort order
            MenuItemDAL menuItems = new MenuItemDAL();
            List<MenuItem> itemList = menuItems.GetByParentId(parentId);

            //order the list using the sort order from the database
            if (itemList.Any())
            {
                itemList = itemList.OrderBy(x => x.SortOrder).ToList();
            }

            return itemList;
        }

        public static List<MenuItem> GetListByMenuNameParentId(string menuName, int parentId)
        {
            //return a list of all the menu items in the correct sort order
            MenuItemDAL menuItems = new MenuItemDAL();
            List<MenuItem> itemList = menuItems.GetByMenuNameParentId(menuName, parentId);

            //order the list using the sort order from the database
            if (itemList.Any())
            {
                itemList = itemList.OrderBy(x => x.SortOrder).ToList();
            }

            return itemList;
        }

        public static int Insert(string menuName, string label, int parentId, int sortOrder, string url, string cssClass, string target)
        {
            MenuItemDAL menuItem = new MenuItemDAL();
            var newId = menuItem.Insert(menuName, label, parentId, sortOrder, url, cssClass, target);
            return newId;
        }

        public static void Update(int menuItemId, string menuName, string label, int parentId, int sortOrder, string url, string cssClass, string target)
        {
            MenuItemDAL menuItem = new MenuItemDAL();
            menuItem.Update(menuItemId, menuName, label, parentId, sortOrder, url, cssClass, target);
        }

        public static void Delete(int menuItemId)
        {
            MenuItemDAL menuItem = new MenuItemDAL();
            menuItem.Delete(menuItemId);
        }

        public static bool MenuItemHasChildren(int menuItemId)
        {
            List<MenuItem> listOfChildren = GetListByParentId(menuItemId);
            if (listOfChildren.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}