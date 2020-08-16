using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core.Logic;
using Newtone.Mobile.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.Logic
{
    public class NavigationWrapper
    {
        #region Properties
        private INavigation Navigation { get; set; }
        public IReadOnlyList<Page> NavigationStack
        {
            get => Navigation.NavigationStack;
        }
        public IReadOnlyList<Page> ModalStack
        {
            get => Navigation.ModalStack;
        }
        #endregion
        #region Constructors
        public NavigationWrapper(INavigation nav)
        {
            
            Navigation = nav;
        }
        #endregion
        #region Public Methods
        public async Task PushAsync(Page page)
        {
            if(Navigation.NavigationStack.Count > 0)
            {
                if (Navigation.NavigationStack.Last() is INavigationContainer container)
                {
                    if(!container.IsBlocked())
                    {
                        container.Block();
                        await Navigation?.PushAsync(page);
                    }
                }
            }
            else
                await Navigation?.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            bool navBlocked = false;
            bool modalBlocked = false;
            if (Navigation.NavigationStack.Count > 0)
            {
                if (Navigation.NavigationStack.Last() is INavigationContainer container)
                {
                    container.Block();
                    navBlocked = true;
                }
            }
            else
                navBlocked = true;

            if (Navigation.ModalStack.Count > 0)
            {
                if (Navigation.ModalStack.Last() is INavigationContainer container)
                {
                    container.Block();
                    modalBlocked = true;
                    var modal = Navigation.ModalStack.Last();
                    var modal1 = page;
                    Console.WriteLine("NavModal " + modal.GetType() + " -> " + modal1.GetType());

                    if (modal.GetType() != modal1.GetType())
                        modalBlocked = false;

                    if(modal is ModalPage modalPage1 && modal1 is ModalPage modalPage2)
                    {
                        Console.WriteLine("ModalPAge");
                        if (modalPage1.GetContentType() != modalPage2.GetContentType())
                            modalBlocked = false;
                    }
                }
            }
            Console.WriteLine("n " + navBlocked + " " + modalBlocked);

            if(!navBlocked || !modalBlocked)
            {
                await Navigation?.PushModalAsync(page);
            }
            
        }

        public async Task PopAsync()
        {
            await Navigation?.PopAsync();
            if (Navigation.NavigationStack.Count > 0)
            {
                if (Navigation.NavigationStack.Last() is INavigationContainer container)
                    container.Unblock();
            }
        }
        public async Task PopModalAsync()
        {
            
            await Navigation?.PopModalAsync();
            Console.WriteLine("PMA " + Navigation.NavigationStack.Count + " " + Navigation.ModalStack.Count);
            if (Navigation.NavigationStack.Count > 0)
            {
                if (Navigation.NavigationStack.Last() is INavigationContainer container)
                    container.Unblock();
            }

            if (Navigation.ModalStack.Count > 0)
            {
                if (Navigation.ModalStack.Last() is INavigationContainer container)
                    container.Unblock();
            }
        }
        public async void Pop()
        {
            Console.WriteLine("Pop");
            if (Navigation.ModalStack.Count > 0)
                await PopModalAsync();
            else
            {
                if (Navigation.NavigationStack.Count > 0)
                    await PopAsync();
            }
        }
        #endregion
    }
}