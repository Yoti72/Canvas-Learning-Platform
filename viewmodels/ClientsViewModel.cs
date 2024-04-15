using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApp.Models;


namespace Maui.Canvas.viewmodels
{
    internal class ClientsViewModel
    {
        private Person underlyingClient;
        public string ClientName
        {
            get { return underlyingClient?.Name ?? string.Empty; }
            set { underlyingClient.Name = value; }
        }

        public ClientsViewModel(Person client)
        {
            underlyingClient = new Person{Name = "test person"};
        }
    }


}


