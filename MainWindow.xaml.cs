using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            blocks = [box1, box2, box3, box4, box5, box6, box7, box8, box9, box10, box11, box12, box13, box14, box15, box16];

            StartUp();
        }

        Char[] characters;
        Random random = new Random();
        DispatcherTimer timer;
        TextBlock[] blocks;
        TextBlock clickedBlock1, clickedBlock2;
        int length,pairs;
        char selectedChar1 = 'n', selectedChar2 = 'n';

        private void StartUp()
        {

            characters = ['l', 'l', '³', '³', 'ö', 'ö', 'à', 'à', 'Y', 'Y', 'Ñ', 'Ñ', 'N', 'N', '!', '!'];
            length = characters.Length;

            try
            {
                for (int i = 0; i < length; i++)
                {
                    int randomIndex = random.Next(characters.Length);
                    char selectedCharacter = characters[randomIndex];

                    blocks[i].Text = characters[randomIndex].ToString();

                    string str = new string(characters);

                    var aStringBuilder = new StringBuilder(str);
                    aStringBuilder.Remove(randomIndex, 1);
                    str = aStringBuilder.ToString();

                    characters = str.ToCharArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void boxClicked(TextBlock block)
        {
            block.Opacity = 1;
            if (selectedChar1 == 'n')
            {
                //first block clicked
                clickedBlock1 = block;
                selectedChar1 = block.Text[0];
            }
            else
            {
                //second block clicked                
                clickedBlock2 = block;
                selectedChar2 = block.Text[0];
                if (selectedChar1 == selectedChar2)
                {
                    //correct, disable both blocks 
                    clickedBlock1.IsEnabled = false;
                    clickedBlock1.Background=Brushes.Orange;
                    clickedBlock2.IsEnabled = false;
                    clickedBlock2.Background = Brushes.Orange;

                    pairs++;
                    if (pairs== 8)
                    {
                        //win game
                        MessageBox.Show("YOU WON!");
                        window.IsEnabled = false;
                    }
                }
                else
                {
                    //error
                    window.IsEnabled = false;
                    StartTimer();
                }
                selectedChar1 = 'n';
                selectedChar2 = 'n';
            }
            //check if game won
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            clickedBlock1.Opacity = 0;
            clickedBlock2.Opacity = 0;
            clickedBlock1 = null;
            clickedBlock2 = null;
            window.IsEnabled = true;

            timer.Stop();
        }

        private void box1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box1);
        }

        private void box2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box2);
        }

        private void box3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box3);
        }

        private void box4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box4);
        }

        private void box5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box5);
        }

        private void box6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box6);
        }

        private void box7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box7);
        }

        private void box8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box8);
        }

        private void box9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box9);
        }

        private void box10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box10);
        }

        private void box11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box11);
        }

        private void box12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box12);
        }

        private void box13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box13);
        }

        private void box14_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box14);
        }

        private void box15_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box15);
        }

        private void box16_MouseDown(object sender, MouseButtonEventArgs e)
        {
            boxClicked(box16);
        }
    }
}