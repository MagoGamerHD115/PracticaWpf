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
using System.Windows.Shapes;

namespace Login_interactivo
{
    /// <summary>
    /// Lógica de interacción para Aplicacion.xaml
    /// </summary>
    public partial class Aplicacion : Window
    {
        private MediaPlayer mediaPlayer;
        private bool isMuted = false;

        public Aplicacion()
        {
            InitializeComponent();
            cargarmusica();
            this.Closing += Window_Closing;

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void cargarmusica()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("music2.mp3", UriKind.Relative));
            mediaPlayer.Play();
            mediaPlayer.IsMuted = false;
            mediaPlayer.Volume = 0.2;
        }
        private void Sonido_Click(object sender, MouseButtonEventArgs e)
        {
            if (isMuted)
            {
                mediaPlayer.Volume = 0.2;  
                isMuted = false;
             }
            else
            {
                mediaPlayer.Volume = 0;   
                isMuted = true;
             }
        }
    }
}
