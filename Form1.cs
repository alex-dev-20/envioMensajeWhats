using System.Threading;
//using System.Threading.Tasks;

namespace whatsApp_formulario
{
    public partial class Form1 : Form
    {
        int contador = 0;     //contador que va recorriendo el arreglo de los numeros telefonicos
        string[] nombre = new string[] { "alexis", "juan", "pedro" };                  //nombre de la persona
        string[] telefono = new string[] { "0123456789", "0123456789", "0123456789" }; //numero telefonico a la persona que se va a enviar el mensaje
                                           //el numero telefonico es en 10 digitos 
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();                                         //se inicializar el timer al precionar el boton
              
        }

        private void timer1_Tick(object sender, EventArgs e)
        {        

            
            if (contador <= telefono.Length)
            {
                try
                {
                    var web = new WebBrowser();
                    web.Navigate("whatsapp://send?phone=" + telefono[contador] + "&text=" +txtSaludo.Text.Replace(" ","+") + " " + nombre[contador] + " " + txtMensaje.Text.Replace(" ", "+") + "");
                    Thread.Sleep(1300);   //se espera un 1.3 segundos antes de enviar el mensaje
                    SendKeys.Send("{ENTER}");
                    contador += 1;
                }
                catch
                {
                    timer1.Stop();
                    contador = 0;
                }
            }
       
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            txtMensaje.ResetText();
            txtSaludo.ResetText();
            contador = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}