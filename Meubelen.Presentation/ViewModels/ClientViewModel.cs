using DatabaseContext.Entities;
using SmartCA.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Meubelen.Presentation.ViewModels
{
    public class ClientViewModel : ViewModel
    {


        private CollectionView clients;
        private Client selectedClient;
        private IList<Client> clientsList;
        public ClientViewModel() : this(null)
        {

        }


        public ClientViewModel(IView view) : base(view)
        {
            clientsList = new List<Client>()
            {
                new Client(){Key=Guid.NewGuid(),
                  FirstName="Mohamed" ,
                  LastName="Abdullah"
                },

                   new Client(){Key=Guid.NewGuid(),
                  FirstName="Hasan" ,
                  LastName="Abdullah"
                },
     new Client(){Key=Guid.NewGuid(),
                  FirstName="Ammar" ,
                  LastName="Abdullah"
                },
          new Client(){Key=Guid.NewGuid(),
                  FirstName="Shaza" ,
                  LastName="Abdullah"
                }
            };
            clients = new CollectionView(clientsList);
        }

        public CollectionView Clients { get { return clients; } }
        public Client SelectedClient { get; set; }
    }
}
