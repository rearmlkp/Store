using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Store.Controllers
{
    public static class CheckFunction
    {
        private static storedbEntities db = new storedbEntities();
        private static HashAlgorithm algo = SHA256.Create();

        public static bool checkUsernamePassword(string username,string password)
        {
            byte[] pass = algo.ComputeHash(Encoding.UTF8.GetBytes(password));
            List<user> listUser = db.user.Where(r => (r.username == username && r.password == pass)).ToList();
            if (listUser.Count == 0) return false;
            return true;
        }

        public static bool checkEmailAlready(string email)
        {
            List<user> listUser = db.user.Where(r => (r.Email == email)).ToList();
            if (listUser.Count == 0) return true;
            return false;
        }
    }
}