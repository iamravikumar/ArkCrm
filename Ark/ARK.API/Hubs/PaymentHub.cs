using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.API.Hubs
{
    public class PaymentHub : Hub<IPaymentHub>
    {
        public async Task ReceiveMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message).ConfigureAwait(true);
        }

        private static readonly IDictionary<string, ISet<string>> users = new ConcurrentDictionary<string, ISet<string>>();

        //public static IEnumerable<string> GetUserConnections(string username)
        //{
        //    ISet<string> connections;

        //    users.TryGetValue(username, out connections);

        //    return (connections ?? Enumerable.Empty<string>());
        //}



        //public async Task AddToGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).ReceiveMessage("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        //}

        //public async Task RemoveFromGroup(string groupName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).ReceiveMessage("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        //}

        public override Task OnConnectedAsync()
        {
            AddUser(Context.User.Identity.Name, Context.ConnectionId);
            return (base.OnConnectedAsync());
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            RemoveUser(this.Context.User.Identity.Name, this.Context.ConnectionId);
            return (base.OnDisconnectedAsync(exception));
        }

        private static void AddUser(string username, string connectionId)
        {
            ISet<string> connections;

            if (users.TryGetValue(username, out connections) == false)
            {
                connections = users[username] = new HashSet<string>();
            }

            connections.Add(connectionId);
        }

        private static void RemoveUser(string username, string connectionId)
        {
            users[username].Remove(connectionId);
        }
    }
}
