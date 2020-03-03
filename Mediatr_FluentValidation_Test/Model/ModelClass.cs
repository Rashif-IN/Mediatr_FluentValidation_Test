using System;
using System.Collections;

namespace Mediatr_FluentValidation_Test.Model
{
    
    public enum kelamin
    {
        man = 0,
        woman = 1,
        unknown = 2
    }
    
    public class Customers
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string password { get; set; }
        public kelamin gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
    public class Customer_Payment_Card
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string name_on_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
    public class Merhcant
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
    public class Products
    {
        public int id { get; set; }
        public int merhcant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
    public class Auth
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
