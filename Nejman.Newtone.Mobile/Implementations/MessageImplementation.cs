using Nejman.Newtone.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nejman.Newtone.Mobile.Implementations
{
    public class MessageImplementation : IMessage
    {
        public void Show(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Show(string title, string message, string accept, string cancel)
        {
            bool result;

            if(accept == "")
            {
                await App.Current.MainPage.DisplayAlert(title, message, cancel);
                result = false;
            }
            else
            {
                result = await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            }

            return result ? accept : cancel;
        }

        public async Task<string> Show(string title, string cancel, string[] buttons)
        {
            var result = await App.Current.MainPage.DisplayActionSheet(title, cancel, null, buttons);

            return result ?? cancel;
        }

        public async Task<string> ShowPrompt(string title, string message, string accept, string cancel, string placeholder, string initialValue)
        {
            var result = await App.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, -1, null, initialValue);

            return result;
        }
    }
}
