using Microsoft.AspNetCore.SignalR;
using UpSchool.Domain.Dtos;

namespace UpSchool.WebApi.Hubs
{
    //Buradaki kodlari clientlar calistirirlar.
    public class SeleniumLogHub: Hub
    {
        public async Task SendLogNotificationAsync(SeleniumLogDto log) //Crawler ve blazor uzerinden tetikkleyebiliriz.
        {
            //ConnectionId istegi gonderen yapinin, tekrar ayni islem yapilmamasi icin
            //SendAsync Blazor hangi isimle dinleyecek onu yazariz.
           await  Clients.AllExcept(Context.ConnectionId).SendAsync("NewSeleniumLogAdded", log);
        }
    }
}
