﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public List<Imagen> Imagenes { get; set; }

        public Articulo(int id, string codigo, string nombre, string descripcion, Marca marca, Categoria categoria, decimal precio)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Marca = marca;
            Categoria = categoria;
            Precio = precio;
            Imagenes = new List<Imagen>();
        }
    }
}
