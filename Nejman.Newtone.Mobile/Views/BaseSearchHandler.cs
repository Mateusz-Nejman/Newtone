using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Views
{
    public class BaseSearchHandler : SearchHandler
    {
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = CoreGlobal.GetHistory()
                    .Where(history => history.ToLowerInvariant().Contains(newValue.ToLowerInvariant()))
                    .Select(history => new SearchModel() { Text = history }).ToList();
            }
        }
    }
}
