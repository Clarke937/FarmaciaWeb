using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaciaWeb.Models;


namespace FarmaciaWeb.Observer
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton() {}
        
        public static Singleton Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public arqfarmaciaEntities Contexto()
        {
            arqfarmaciaEntities dbc = new arqfarmaciaEntities();
            return dbc;
        }
    }
}