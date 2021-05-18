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

namespace Школа_КузьминаАА
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        List<Service> ServiswList = Base.EM.Service.ToList();
        public Admin()
        {
            InitializeComponent();
            DGServises.ItemsSource = ServiswList;
        }
        int i = -1;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Service S = ServiswList[i];
                Uri U = new Uri(S.MainImagePath, UriKind.RelativeOrAbsolute);
                ME.Source = U;
                //   i++;
            }

        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                TB.Text = S.Title;
                //  i++;
            }


        }

        private void BRed_Initialized(object sender, EventArgs e)
        {
            Button BtnRed = (Button)sender;
            if (BtnRed != null)
            {
                BtnRed.Uid = Convert.ToString(i);
            }

        }

        private void BRed_Click(object sender, RoutedEventArgs e)
        {
            Button BtnRed = (Button)sender;
            int ind = Convert.ToInt32(BtnRed.Uid);
            Service S = ServiswList[ind];
            MessageBox.Show(S.Title);

        }

        private void StackPanel_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                StackPanel SP = (StackPanel)sender;
                Service S = ServiswList[i];
                if (S.Discount != 0)
                {
                    SP.Background = new SolidColorBrush(Color.FromRgb(231, 250, 191));
                }
            }

        }

        private void cost_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];

                int old_c = Convert.ToInt32(S.Cost);
                int discount = Convert.ToInt32(S.Discount * 100);
                int cost = Convert.ToInt32(S.Cost);
                int c_d = cost - (cost / 100 * discount);
                int time = Convert.ToInt32(S.DurationInSeconds / 60);
                if (S.Discount == 0)
                {
                    TB.Visibility = Visibility.Collapsed;
                  


                }
                else
                {
                    
                    TB.Text = Convert.ToString( " " + c_d + " рублей за " + time + "минут");
                }

            }
        }

        private void skidka_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                if (S.Discount == 0)
                {
                    TB.Text = " ";
                    int old_c = Convert.ToInt32(S.Cost);
                    int tm = Convert.ToInt32(S.DurationInSeconds / 60);
                    TB.Text = Convert.ToString(Convert.ToInt32(S.Cost));
                    TB.Text = Convert.ToString(old_c + " рублей за " + tm + "минут");
                }
                else
                {
                   
                    TB.Text = Convert.ToString("* скидка " + S.Discount * 100 + "%");
                }

                //  i++;
            }
        }

        private void oldcost_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Service S = ServiswList[i];
            if (S.Discount == 0)
            {
                TB.Text = " ";
            }
            else
            {
                int old_c = Convert.ToInt32(S.Cost);
                TB.TextDecorations = TextDecorations.Strikethrough;
                TB.Text = Convert.ToString(old_c);
            }

           
        }
    }
}
 