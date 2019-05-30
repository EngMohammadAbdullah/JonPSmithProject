using DatabaseContext.Entities;
using Meubelen.Presentation.Views;
using SmartCA.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubelen.Presentation.ViewModels
{
    public class OrderViewModel : ViewModel
    {

        #region Private Fields

        private IList<Order> ordersList;
        private Client selectedClient;
        private DelegateCommand getClient;
        #endregion

        public OrderViewModel()
        {

        }


        public OrderViewModel(IView view) : base(view)
        {
            getClient = new DelegateCommand(this.GetClient);
        }

        public DelegateCommand GetClientCommand
        {
            get
            {
                return this.getClient;
            }
        }
        private void GetClient(object sender, EventArgs e)
        {
            var clientView = new Clients();

            clientView.ShowDialog();


            SelectedClient = (clientView.DataContext as
                    ClientViewModel).SelectedClient;

        }

      
        public Client SelectedClient { get; set; }
    }
}
