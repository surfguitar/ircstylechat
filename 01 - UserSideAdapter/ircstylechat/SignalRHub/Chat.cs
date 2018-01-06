using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Microsoft.AspNet.SignalR;
using System.Text.RegularExpressions;

namespace ircstylechat.SignalRHub
{
    public class Chat : Hub
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();

        public void JoinChat(string name)
        {
            var trimmedName = Regex.Replace(name, "<.*?>", string.Empty);

            Clients.Caller.Name = trimmedName;
            Users.Add(Context.ConnectionId, trimmedName);

            Clients.All.addMessage(DateTime.UtcNow.ToString() + " " + WebUtility.HtmlEncode(Clients.Caller.Name) + " joined the chat.");

            foreach (var user in Users)
            {
                Clients.Caller.NewUser(user.Value, user.Key);
            }

            Clients.AllExcept(Context.ConnectionId).NewUser(trimmedName, Context.ConnectionId);
        }


    }
}