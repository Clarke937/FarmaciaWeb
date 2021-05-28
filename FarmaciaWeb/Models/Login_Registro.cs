using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace FarmaciaWeb.Models
{
    public class Login_Registro
    {
        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")]
        [Remote("CheckUserExist", "Registro",ErrorMessage = "Este usuario ya existe", HttpMethod = "POST")]
        [StringLength(25,ErrorMessage = "El usuario debe tener entre 6 y 25 caracteres", MinimumLength = 6)]
        public string usuario { get; set; }


        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(50, ErrorMessage = "La contraseña debe tener entre 8 y 50 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string contrasenia { get; set; }


        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(50, ErrorMessage = "La contraseña debe tener entre 8 y 50 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("contrasenia")]
        public string repetir_contrasenia { get; set; }


        [Required(ErrorMessage = "Debe ingresar sus nombres")]
        [StringLength(50, ErrorMessage = "Nombres debe tener entre 2 y 50 caracteres", MinimumLength = 2)]
        public string nombres { get; set; }


        [Required(ErrorMessage = "Debe ingresar sus apellidos")]
        [StringLength(50, ErrorMessage = "Apellidos debe tener entre 2 y 50 caracteres", MinimumLength = 2)]
        public string apellidos { get; set; }


        [Required(ErrorMessage = "Debe ingresar su numero de dui")]
        [StringLength(10, ErrorMessage = "Dui debe tener 10 caracteres", MinimumLength = 10)]
        public string dui { get; set; }


        [Required(ErrorMessage = "Debe ingresar su numero de nit")]
        [StringLength(17, ErrorMessage = "Nit debe tener 10 caracteres", MinimumLength = 17)]
        public string nit { get; set; }


        [Required(ErrorMessage = "Debe ingresar su direccion")]
        [StringLength(255,ErrorMessage = "Detalle su dirección en 25 caracteres o mas", MinimumLength = 25)]
        public string direccion { get; set; }


        [Required]
        [Range(1,3,ErrorMessage = "Seleccione una opción de genero")]
        public int genero { get; set; }
        
        
        [Required]
        [Range(18,150,ErrorMessage = "Debe ser mayor de 18 años")]
        public int edad { get; set; }

    }
}