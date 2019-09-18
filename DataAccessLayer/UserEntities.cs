using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class UserEntities
    {
        static ProjectManagementEntities DbContext;
        static UserEntities()
        {
            DbContext = new ProjectManagementEntities();
        }

        public static List<User> GetAllUsers()
        {
            return DbContext.Users.ToList();
        }

        public static User GetUsers(int userId)
        {
            return DbContext.Users.Where(p => p.Id == userId).FirstOrDefault();
        }

        public static bool InsertUser(User userItem)
        {
            bool status;
            try
            {
                DbContext.Users.Add(userItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool UpdateUser(User userItem)
        {
            bool status;
            try
            {
                User userItemInfo = DbContext.Users.Where(p => p.Id == userItem.Id).FirstOrDefault();
                if (userItem != null)
                {
                    userItemInfo.FirstName = userItem.FirstName;
                    userItemInfo.LastName = userItem.LastName;
                    userItemInfo.EmpId = userItem.EmpId;
                    userItemInfo.Active = userItem.Active;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteUser(int id)
        {
            bool status;
            try
            {
                User prodItem = DbContext.Users.Where(p => p.Id == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.Users.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
