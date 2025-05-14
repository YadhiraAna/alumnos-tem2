using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumnos_tem2.Utilities
{
    internal class Formas
    {
        public static void InicializarForma(Form form_parent, Form form_child)//sera llamado en el constructor
        {
            //propiedades basicas
            form_child.MdiParent = form_parent;//asignar un padre a estudiantes(sera MDI)
            form_child.FormBorderStyle = FormBorderStyle.Sizable;//su tamaño puede ser ajustado
            form_child.MaximizeBox = true;//puede maximizar
            form_child.MinimizeBox = true;//puede minimizar
            form_child.WindowState = FormWindowState.Normal;//regresar al estado inicial
            //propiedades de control
            form_child.ControlBox = true;//mostrar bontones de control(minimizar,max,cerrar)
            form_child.ShowIcon = true;//mostrar icono en la barra de titulo
            form_child.ShowInTaskbar = false;//no mostrar en la barrra de tarea (ya que es un ventana)
            //propiedades de tamaño
            form_child.AutoScaleMode = AutoScaleMode.Font;//modo escalado
            form_child.ClientSize = new Size(800, 600);//tamaño inicial
            form_child.MinimumSize = new Size(400, 300);//tamaño minimo
            form_child.MaximumSize = new Size(3440, 1440);//tamaño maximo
            //propiedades de inicio
            form_child.StartPosition = FormStartPosition.CenterScreen;//posicion inicial
            //propiedades de comportamiento
            form_child.AutoScroll = true;//permitir si el contenido es smayor que la ventana
            form_child.KeyPreview = true;//permitir que el formulario reciba eventos de teclado

        }

    }
}
