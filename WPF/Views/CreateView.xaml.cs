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
using WPF.Controllers;

namespace WPF
{
    /// <summary>
    /// Logique d'interaction pour CreateView.xaml
    /// </summary>
    public partial class CreateView : Page
    {
        public String name;
        public String source;
        public String destination;
        public String type;
        public CreateView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            name = Nametxt.Text;
            source = Sourcetxt.Text;
            destination = Destinationtxt.Text;
            type = Typetxt.Text;
            /*this.Validate.Click += new RoutedEventHandler(OnClick);
            this.displayText.Text += name;
            this.displayText.Text += source;
            this.displayText.Text += destination;
            this.displayText.Text += type;*/

            ControllerCreate launch = new ControllerCreate();
        }
    }
}
