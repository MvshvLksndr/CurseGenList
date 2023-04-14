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

namespace ListWPD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<string> content = new List<string>();
        public int Page = 0;
        int MaxOnPage = 15;

        CurseGen curse = new CurseGen();
        public MainWindow()
        {
           
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                content.Add(curse.GetRandomSentence(10)); ;
            }

            int pages = GetMaxPages();
            for (int i = 0; i < pages; i++)
            {
                Button button = new Button();
                button.Padding = new Thickness(5);
                button.Content = i +1;
                button.Click += Button_Click;
                button.Margin = new Thickness(5);

                dpBtns.Children.Add(button);
            }

            UpdateList();



        }
        public void UpdateList()
        {
            lvContent.ItemsSource = content.Skip(Page * MaxOnPage).Take(MaxOnPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            Page = Convert.ToInt32(b.Content) - 1;
            UpdateList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Page <= 0) return;
            Page--;
            UpdateList();
        }

        private void btnFrwrd_Click(object sender, RoutedEventArgs e)
        {
            if(Page >= GetMaxPages()-1) return;
            Page++;
            UpdateList();
        }

        public int GetMaxPages()
        {
            int max = 1+ (int)content.Count / MaxOnPage;

            return max;
        }
    }
}
