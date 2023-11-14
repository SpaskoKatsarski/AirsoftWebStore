namespace AirsoftWebStore.Web.Hubs
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    using static Common.GeneralApplicationConstants;

    public class RequestHub : Hub
    {
        private List<string> connectedAdmins = new List<string>();

        public override async Task OnConnectedAsync()
        {
            if (this.IsUserAdmin(Context.User))
            {
                connectedAdmins.Add(Context.ConnectionId);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (this.IsUserAdmin(Context.User))
            {
                connectedAdmins.Remove(Context.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            foreach (var connectionId in connectedAdmins)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
            }
        }

        private bool IsUserAdmin(ClaimsPrincipal user) => user.IsInRole(AdminRoleName);
    }
}
