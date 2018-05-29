using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taller_de_validaciones.Objetos;

namespace taller_de_validaciones
{
    public partial class Form1 : Form
    {
      

        public Form1()

        {
            InitializeComponent();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tipo documentos
            System.Collections.Generic.List<Objetos.TipoDocumento>
            tiposDocumento = new List<Objetos.TipoDocumento>();

            tiposDocumento.Add(new Objetos.TipoDocumento() { Id = 1, Nombre = "TI" });
            tiposDocumento.Add(new Objetos.TipoDocumento() { Id = 2, Nombre = "CC" });
            tiposDocumento.Add(new Objetos.TipoDocumento() { Id = 3, Nombre = "CE" });
            tiposDocumento.Add(new Objetos.TipoDocumento() { Id = 4, Nombre = "NUIP" });
            cbxTipoDoc.DataSource = tiposDocumento;
            cbxTipoDoc.DisplayMember = "Nombre";

            // rangos
            System.Collections.Generic.List<Objetos.Rango>
            rangos = new List<Objetos.Rango>();

            rangos.Add(new Objetos.Rango() { Id = 1, Nombre = "Rango A" });
            rangos.Add(new Objetos.Rango() { Id = 2, Nombre = "Rango B" });
            rangos.Add(new Objetos.Rango() { Id = 3, Nombre = "Rango C" });

            cbRango.DataSource = rangos;
            cbRango.DisplayMember = "Nombre";


        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // validar nombre
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, "Ingrese un nombre");
                return;
            }
            else
            {
                erpMensaje.SetError(txtNombre,"");        
            }
            //----------------------------------//

            // validar documento vacio
            if (string.IsNullOrEmpty(txtNumDocumento.Text))
            {
                erpMensaje.SetError(txtNumDocumento, "Debe ingresar un numero de documento");
                return;
            }
            //----------------------------------//

            // validar documento >0
            if(Convert.ToInt64( txtNumDocumento.Text) <= 0)
            {
                erpMensaje.SetError(txtNumDocumento, "El documento debe ser mayor a 0");
                return;
            }
            //----------------------------------//

            // validar nuip entre 1.000millones y 9.999millones

            if (((TipoDocumento)cbxTipoDoc.SelectedItem).Id == 4)


            { if (Convert.ToInt64( txtNumDocumento.Text) <= 1000000000)
                {
                    MessageBox.Show("debe ingresar un numero mayor a 1.000.000.000");

                }
                    
               if (Convert.ToInt64(txtNumDocumento.Text) >= 9999999999)
                {
                    MessageBox.Show("debe ingresar un numero menor  a 9.999.999.999");
                }
                return;
            }
            //----------------------------------//
            //validar costo del servicio vacio
            if (string.IsNullOrEmpty(txtCosto .Text))
            {
                erpMensaje.SetError(txtCosto, "Debe ingresar un  costo del servicio");
                return;
            }
            //----------------------------------//
            
            // COSTO DEL SERVICIO MAYOR  A 0
            if (Convert.ToInt64(txtCosto.Text) <= 0)
            {
                erpMensaje.SetError(txtCosto, "El numero ingresado debe ser mayor a 0");
                return;
            }
            //----------------------------------//

            // mostrar mensaje de registro
            Objetos.Servicio Registro = new Objetos.Servicio();
            Registro.Nombre = txtNombre.Text;
            Registro.NumeroDocumento = Convert.ToInt64(txtNumDocumento.Text);
            Registro.CostoServicio = Convert.ToInt64(txtCosto.Text);
            MessageBox.Show("Registro Ingresado Exitosamente");
            
        }



        

        private void btnCalcular_Click(object sender, EventArgs e)
        { double CostoServicio= 0 ;

            if (((Rango)cbRango.SelectedItem).Id == 1)
            {
                 CostoServicio = (Convert.ToInt64(txtCosto.Text)-((Convert.ToInt64(txtCosto.Text)*0.30)));
            }
            if (((Rango)cbRango.SelectedItem).Id == 2)
            {
                 CostoServicio = (Convert.ToInt64(txtCosto.Text)-((Convert.ToInt64(txtCosto.Text)*0.20)));
            }
            if (((Rango)cbRango.SelectedItem).Id == 3)
            {
                 CostoServicio = (Convert.ToInt64(txtCosto.Text)-((Convert.ToInt64(txtCosto.Text)*0.10)));
            }

            MessageBox.Show("El costo del servicio es: " + CostoServicio);
        }
                

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }
        //validar letras en el campo costo  
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar == 8 || (int)e.KeyChar >= 48 && (int)e.KeyChar <= 59))
            {
                e.Handled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
