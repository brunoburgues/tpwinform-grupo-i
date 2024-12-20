﻿using BaseDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpwinfom_grupo_i
{
    public partial class Editar : Form
    {
        List<Marca> marcas;
        List<Categoria> categorias;
        public Editar(int i)
        {
            InitializeComponent();
            if (i == 0)
            {
                lbObjeto.Text = "Marca";
                MarcaDB marcaDB = new MarcaDB();
                marcas = marcaDB.listarMarcas();
                dgv.DataSource = marcas;
            }else
            {
                lbObjeto.Text = "Categoria";
                CategoriaDB categoriaDB = new CategoriaDB();
                categorias = categoriaDB.listarCategoria(); 
                dgv.DataSource = categorias;
            }
            dgv.Columns["Id"].Visible = false;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (lbObjeto.Text == "Marca")
            {
                Marca marca = (Marca)dgv.CurrentRow.DataBoundItem;
                tbNombre.Text = marca.Nombre;
            }else
            {
                Categoria categoria = (Categoria)dgv.CurrentRow.DataBoundItem;
                tbNombre.Text = categoria.Nombre;
            }
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (lbObjeto.Text == "Marca")
            {
                dgv.DataSource = marcas.FindAll(a => a.Nombre.IndexOf(tbBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }else
            {
                dgv.DataSource = categorias.FindAll(A => A.Nombre.IndexOf(tbBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (lbObjeto.Text == "Marca")
            {
                Marca marca = (Marca)dgv.CurrentRow.DataBoundItem;
                DialogResult result = MessageBox.Show("Estas seguro de modificar la marca " + marca.Nombre, "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MarcaDB marcaDB = new MarcaDB();
                    marcaDB.editar(marca, tbNombre.Text);
                    dgv.DataSource = marcaDB.listarMarcas();
                }
            }else
            {
                Categoria categoria = (Categoria)dgv.CurrentRow.DataBoundItem;
                DialogResult result = MessageBox.Show("Estas seguro de modificar la categoria " + categoria.Nombre, "Confirmar", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    CategoriaDB categoriaDB = new CategoriaDB();
                    categoriaDB.editar(categoria, tbNombre.Text);
                    dgv.DataSource = categoriaDB.listarCategoria();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbObjeto.Text == "Marca")
                {
                    Marca marca = (Marca)dgv.CurrentRow.DataBoundItem;
                    DialogResult result = MessageBox.Show("Seguro que quieres eliminar la marca " + marca.Nombre + "¿Esta es una accion irreversible?", "Confirmar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MarcaDB marcaDB = new MarcaDB();
                        marcaDB.eliminar(marca.Id);
                        dgv.DataSource = marcaDB.listarMarcas();
                    }
                }
                else
                {
                    Categoria categoria = (Categoria)dgv.CurrentRow.DataBoundItem;
                    DialogResult result = MessageBox.Show("Seguro que quieres eliminar la categoria " + categoria.Nombre + " ¿Esta es una accion irreversible?", "Confirmar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        CategoriaDB categoriaDB = new CategoriaDB();
                        categoriaDB.eliminar(categoria.Id);
                        dgv.DataSource = categoriaDB.listarCategoria();
                    }
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
    }
}
