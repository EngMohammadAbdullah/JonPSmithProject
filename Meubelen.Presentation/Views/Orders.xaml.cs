using Meubelen.Presentation.ViewModels;
using SmartCA.Infrastructure.UI;
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

namespace Meubelen.Presentation
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window, IView
    {
        public Orders()
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel(this);
        }
    }
}
