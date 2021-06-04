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
        public void Activar(registro registros)
        {
            registro res = dbc.registro.Find(registros.id_registro);
            res.estado_notificaciones = true;
            dbc.SaveChanges();
        }

        public void Desactivar(registro registros)
        {
            registro res = dbc.registro.Find(registros.id_registro);
            res.estado_notificaciones = false;
            dbc.SaveChanges();
        }

        public void Notificar()
        {
            List<registro> res = dbc.registro.Where(x => x.estado_notificaciones.Value).ToList();
            foreach (registro registro in res)
            {

                new Observador().Update(registro.id_registro, idNotify);
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