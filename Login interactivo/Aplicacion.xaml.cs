using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Login_interactivo
{
    public partial class Aplicacion : Window
    {
        private MediaPlayer mediaPlayer;
        private bool isMuted = false;
        private bool isMenuOpen = false;
        private bool isConfigMenuOpen = false;

        public Aplicacion()
        {
            InitializeComponent();
            cargarmusica();
            LoadImages();
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

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleMenu();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has hecho clic en un botón del menú");
        }

        private void GamesButton_Click(object sender, RoutedEventArgs e)
        {
            GameLibraryView.Visibility = Visibility.Visible;
            ConfigMenuOverlay.Visibility = Visibility.Collapsed;
            isConfigMenuOpen = false;
        }

        private void ToggleMenu()
        {
            double targetWidth = isMenuOpen ? 0 : 200;
            DoubleAnimation animation = new DoubleAnimation(MenuPanel.Width, targetWidth, TimeSpan.FromSeconds(0.3));
            MenuPanel.BeginAnimation(WidthProperty, animation);
            isMenuOpen = !isMenuOpen;

            if (!isMenuOpen)
            {
                ConfigMenuOverlay.Visibility = Visibility.Collapsed;
                isConfigMenuOpen = false;
            }
        }

        private void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleConfigMenu();
        }

        private void ToggleConfigMenu()
        {
            if (isConfigMenuOpen)
            {
                ConfigMenuOverlay.Visibility = Visibility.Collapsed;
            }
            else
            {
                ConfigMenuOverlay.Visibility = Visibility.Visible;
                GameLibraryView.Visibility = Visibility.Collapsed;
            }
            isConfigMenuOpen = !isConfigMenuOpen;
        }

        private void SoundSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Configuración de sonido");
            // Aquí puedes implementar la lógica para ajustar el volumen
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Acerca de: Información sobre la aplicación");
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cerrando sesión...");
            // Implementar lógica para cerrar sesión
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cerrando el programa...");
            this.Close();
        }
        private void LoadImages()
        {
            try
            {
                var imageControls = new[]
                {
                    AlbionImage,
                    CodImage,
                    AddGameImage,
                    WallpaperImage,
                    BatmanImage
                };

                var imagePaths = new[]
                {
                    "/Images/albion.jpg",
                    "/Images/cod.jpg",
                    "/Images/6459958.png",
                    "/Images/wallpaper.jpg",
                    "/Images/batman.jpg"
                };

                for (int i = 0; i < imageControls.Length; i++)
                {
                    if (imageControls[i] != null)
                    {
                        var uri = new Uri(imagePaths[i], UriKind.Relative);
                        var bitmap = new BitmapImage(uri);
                        imageControls[i].Source = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las imágenes: {ex.Message}");
            }
        }
    }
}