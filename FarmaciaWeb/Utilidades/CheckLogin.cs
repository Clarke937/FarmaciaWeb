using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Utilidades
{
    public class CheckLogin
    {
        private login currentUser = new login();
        private arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        public bool ValidarLogin()
        {
            if (HttpContext.Current.Session["currentUser"] != null)
            {
                this.currentUser = (login)HttpContext.Current.Session["currentUser"];
                this.currentUser.nivel_acceso = dbc.nivel_acceso.Find(currentUser.fk_nivel);
                if (this.currentUser.nivel_acceso.id_nivel != 3) return true;
                else return false;
            }

            return false;
        }
    }
}