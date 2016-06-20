using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Controllers
{
    public static class GetFunction
    {
        private static storedbEntities db = new storedbEntities();

        public static order getUserCurrentOrder(string username)
        {
            List<order> listOrder = db.order.Where(r => (r.username == username && r.OrderStatus == 0)).ToList();
            if (listOrder.Count == 0) return null;

            return listOrder.Last();
        }
    }
}