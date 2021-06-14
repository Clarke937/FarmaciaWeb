using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmaciaWeb.Controllers;
using FarmaciaWeb.Models;
namespace FarmaciaWeb.Observer
{
    
    public class Sujeto : ISujeto
    {
        private arqfarmaciaEntities dbc = new arqfarmaciaEntities();
        private int idNotify;
        public void Activar(cliente cliente)
        {
            cliente cl = dbc.cliente.Find(cliente.id_cliente);
            cl.estado_notificaciones = true;
            dbc.SaveChanges();
        }

        public void Desactivar(cliente cliente)
        {
            cliente cl = dbc.cliente.Find(cliente.id_cliente);
            cl.estado_notificaciones = false;
            dbc.SaveChanges();
        }

        public void Notificar()
        {
            List<cliente> cliente = dbc.cliente.Where(x => x.estado_notificaciones == true).ToList();
            foreach (cliente cl in cliente)
            {
                new Observador().Update(cl.id_cliente, idNotify);
            }
        }

        public void CrearNotificacion(string titulo, string descripcion, decimal extras)
        {
            notificaciones notify = new notificaciones();
            notify.titulo = titulo;
            notify.descripcion = descripcion;
            notify.extras = extras;
            notify.estado = true;
            dbc.notificaciones.Add(notify);
            dbc.SaveChanges();
            idNotify = notify.id_notificacion;
            this.Notificar();
        }

    }
}