using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hublov.ViewModels
{
    public interface IPageService
    {
        Page page { get; set; }

        Task DisplayAlert(string title, string message, string cancel);
        Task DisplayAlert(string title, string message, string confirm, string cancel);
        Task PopAsync();
        Task PushAsync(Page page);
    }
}
