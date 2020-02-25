using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pe.Stracon.SGC.Presentacion.Hubs
{
    /// <summary>
    /// 
    /// </summary>
    public class Chat : Hub
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            // Call the addMessage method on all clients            
            Clients.All.addMessage(message);
        }
    }
}