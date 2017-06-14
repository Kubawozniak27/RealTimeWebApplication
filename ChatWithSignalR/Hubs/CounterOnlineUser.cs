using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ChatWithSignalR.Hubs
{
    public class CounterOnlineUser : Hub
    {
        private static int counter = 0;

        public void Send()
        {
            string message = "";
            
            if (counter < 2)
                message = string.Format("Obecnie jest {0} użytkownik online", counter);
            else
                message = string.Format("Obecnie jest {0} użytkowników online.", counter);

            Clients.All.recalculateOnlineUsers(message);
        }



        
        public override Task OnConnected()
        {
            counter++;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            counter--;
            return base.OnDisconnected(stopCalled);
        }
    }
}