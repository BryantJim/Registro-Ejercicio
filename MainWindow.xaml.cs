using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EjercicioRegistro.Entidades;
//using System.Windows.Forms;
using EjercicioRegistro.BLL;

namespace EjercicioRegistro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {

            ID_TextBox.Text = string.Empty;
            Nombre_TexBox.Text = string.Empty;
            Apellido_TexBox.Text = string.Empty;
            Telefono_TextBox.Text = string.Empty;
            Cedula_TexBox.Text = string.Empty;
            Direccion_TexBoxx.Text = string.Empty;
            FechaNacimiento_DataP.Text = string.Empty;
        }

        private Persona LlenarClase()
        {
            Persona persona = new Persona();
            persona.ID = Convert.ToInt32(ID_TextBox.Text);
            persona.Nombre = Nombre_TexBox.Text;
            persona.Apellido = Apellido_TexBox.Text;
            persona.Telefono = Telefono_TextBox.Text;
            persona.Cedula = Cedula_TexBox.Text;
            persona.Direccion = Direccion_TexBoxx.Text;
            //persona.FechaNaci = Convert.ToDateTime(FechaNacimiento_DataP);

            return persona;
        }

        private void LlenarCampo(Persona persona)
        {
            ID_TextBox.Text =Convert.ToString(persona.ID);
            Nombre_TexBox.Text = persona.Nombre;
            Apellido_TexBox.Text = persona.Apellido;
            Telefono_TextBox.Text = persona.Telefono;
            Cedula_TexBox.Text = persona.Cedula;
            Direccion_TexBoxx.Text = persona.Direccion;
            //FechaNacimiento_DataP.Text = Convert.ToString(persona.FechaNaci);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(Nombre_TexBox.Text))
            {
                Nombre_TexBox.Focus();
                paso = false;
            }
                

            if (string.IsNullOrWhiteSpace(Apellido_TexBox.Text))
            {
                Apellido_TexBox.Focus();
                paso = false;
            }
                

            if (string.IsNullOrWhiteSpace(Telefono_TextBox.Text))
            {
                Telefono_TextBox.Focus();
                paso = false;
            }
                

            if (string.IsNullOrWhiteSpace(Cedula_TexBox.Text))
            {
                Cedula_TexBox.Focus();
                paso = false;
            }
                

            if (string.IsNullOrWhiteSpace(Direccion_TexBoxx.Text))
            {
                Direccion_TexBoxx.Focus();
                paso = false;
            }
                

            /*if (string.IsNullOrWhiteSpace(FechaNacimiento_DataP.Text))
                FechaNacimiento_DataP.Focus();*/

            return paso;
        }

        private bool ExisteEnLaBaseDatos()
        {
            Persona persona = PersonasBLL.Buscar((int)Convert.ToInt32(ID_TextBox.Text));

            return persona != null;
        }

        private void Nuevo_Button_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Guardar_Button_Click(object sender, RoutedEventArgs e)
        {
            Persona persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenarClase();

            if (ID_TextBox.Text != null)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if(!ExisteEnLaBaseDatos())
                {
                    System.Windows.MessageBox.Show("No se puede modificar una persona que no existe");
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }


            if (paso)
            {
                Limpiar();
                System.Windows.MessageBox.Show("Persona fue Guardada", "Exito!");
            }
            else
            {
                System.Windows.MessageBox.Show("Persona no se pudo guardar");
            }
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            Persona persona = new Persona();
            int.TryParse(ID_TextBox.Text, out Id);

            Limpiar();

            persona = PersonasBLL.Buscar(Id);

            if (persona != null)
            {
                System.Windows.MessageBox.Show("Persona Encontrada");
                LlenarCampo(persona);
            }
            else
            {
                System.Windows.MessageBox.Show("Persona no Encontrada");
            }
        }

        private void Eliminar_Button_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            int.TryParse(ID_TextBox.Text, out Id);

            Limpiar();

            if (PersonasBLL.Eliminar(Id))
                System.Windows.MessageBox.Show("Persona Eliminada");
            else
                System.Windows.MessageBox.Show("Persona no pudo ser Eliminada");
        }
    }
}
