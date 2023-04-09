using Blazored.Toast.Services;
using Microsoft.JSInterop;
using Shipwreck.BlazorJqueryToast;
using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Services
{
    public class ToasterService:IToasterService
    {
        private readonly IJSRuntime _jsRuntime; //Yukledigimiz nuget paketi.
        public ToasterService(IJSRuntime jSRuntime) //Constructor injection
        {
            _jsRuntime = jSRuntime;
        }

        public void ShowSuccess(string message)
        {
            _jsRuntime.ShowToastAsync(new ToastOptions
            {
                Text = message,
                Position = ToastPosition.TopCenter,
                Heading = "UpSchool"
            });
        }
        public void ShowError(string message)
        {
            _jsRuntime.ShowToastAsync(new ToastOptions
            {
                Text = message,
                Position = ToastPosition.TopCenter,
                Heading = "Error!"
            });
        }
    }
}
