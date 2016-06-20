using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Store.Controllers
{

    public class SpecialOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SpecialOffer(specialoffer s)
        {
            this.Id = s.idSpecialOffer;
            this.Name = s.OfferName;
            this.Description = s.Description;
        }
    }

    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public ProductType(producttype p)
        {
            this.Id = p.idProductType;
            this.TypeName = p.TypeName;
            this.Description = p.Description;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool StockStatus { get; set; }
        public string ImagePath { get; set; }
        public float Price { get; set; }
        public string ReparingStatus { get; set; }
        public System.DateTime Date { get; set; }
        public int Quantity { get; set; }
        public SpecialOffer offer { get; set; }
        public Product(product p)
        {
            this.Id = p.idProduct;
            this.Type = new ProductType(p.producttype);
            this.Name = p.ProductName;
            this.Description = p.Description;
            this.StockStatus = p.StockQuantity > 10 ? true : false;
            this.ImagePath = p.ImagePath;
            this.Price = p.Price;
        }

        public Product(reparingproduct p)
        {
            this.Id = p.idReparingProduct;
            this.Type = new ProductType(p.producttype);
            this.Name = p.Name;
            this.Description = p.Description;
            this.ImagePath = p.ImagePath;
            this.Price = p.RepairedPrice;
            this.ReparingStatus = p.Status == 0 ? "Reparing" : (p.Status == 1 ? "Repaired" : "Others");
            this.Date = p.RepairedDate;
        }

        public Product(soldproduct p)
        {
            this.Id = p.idSoldProduct;
            this.Type = new ProductType(p.producttype);
            this.Name = p.Name;
            this.Description = p.Description;
            this.ImagePath = p.ImagePath;
            this.Price = p.SoldPrice;
            this.Date = p.SoldDate;
        }

        public Product(orderline p)
        {
            this.Id = p.idProduct;
            this.Type = new ProductType(p.product.producttype);
            this.Name = p.product.ProductName;
            this.Description = p.product.Description;
            this.ImagePath = p.product.ImagePath;
            this.Price = p.product.Price;
            this.offer = new SpecialOffer(p.specialoffer);
            this.Quantity = p.Quantity;
        }
    }

    public static class ListFunction
    {
        private static storedbEntities db = new storedbEntities();

        public static List<ProductType> listProductType()
        {
            List<ProductType> toReturn = new List<ProductType>();

            List<producttype> listType = db.producttype.ToList();
            foreach (var E in listType)
            {
                toReturn.Add(new ProductType(E));
            }

            return toReturn;
        }

        public static List<Product> listProduct()
        {
            List<Product> toReturn = new List<Product>();

            List<product> listProduct = db.product.ToList();
            foreach (var E in listProduct)
            {
                toReturn.Add(new Product(E));
            }

            return toReturn;
        }

        public static List<Product> listUserReparingProduct(string username, string password)
        {
            if (!CheckFunction.checkUsernamePassword(username, password)) return null;

            List<Product> toReturn = new List<Product>();

            List<reparingproduct> listPending = db.reparingproduct.Where(r => (r.username == username)).ToList();
            foreach (var E in listPending)
            {
                toReturn.Add(new Product(E));
            }
            return toReturn;
        }

        public static List<Product> listUserSoldProduct(string username, string password)
        {
            if (!CheckFunction.checkUsernamePassword(username, password)) return null;

            List<Product> toReturn = new List<Product>();

            List<soldproduct> listSold = db.soldproduct.Where(r => (r.username == username)).ToList();
            foreach (var E in listSold)
            {
                toReturn.Add(new Product(E));
            }
            return toReturn;
        }

        public static List<Product> listProductInCart(string username, string password)
        {
            if (!CheckFunction.checkUsernamePassword(username, password)) return null;

            List<Product> toReturn = new List<Product>();

            order o = GetFunction.getUserCurrentOrder(username);
            if (o == null) return toReturn;

            List<orderline> listOrderline = db.orderline.Where(r => (r.idOrder == o.idOrder)).ToList();
            foreach (var E in listOrderline)
            {
                toReturn.Add(new Product(E));
            }
            return toReturn;
        }
    }
}