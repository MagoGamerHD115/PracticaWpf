using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Login_interactivo
{
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer;
        private bool isMuted = false;


        public MainWindow()
        {
            InitializeComponent();
            cargarmusica();
            this.Closing += Window_Closing;   
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mediaPlayer.Stop();   
        }

        private void cargarmusica()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("music1.mp3", UriKind.Relative));   
            mediaPlayer.Play();
            mediaPlayer.IsMuted = false;
            mediaPlayer.Volume = 0.2;   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            validacion();
        }

        private void validacion()
        {
            Aplicacion aplicacion = new Aplicacion();
            if (!string.IsNullOrWhiteSpace(Email.Text) && !string.IsNullOrWhiteSpace(Contra.Text))
            {
                if (Email.Text == "admin" && Contra.Text == "1234")
                {
                    MessageBox.Show("¡Usuario exitoso!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    aplicacion.Show();
                    this.Close();   
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña son incorrectos. Intenta de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa ambos campos (email y contraseña).", "Campos Vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
