﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Logic
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
            if (Navigation.NavigationStack.Count > 0)
            {
                if (Navigation.NavigationStack.Last() is INavigationContainer container && !container.IsBlocked())
                {
                    container.Block();
                    await Navigation?.PushAsync(page);
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
            {
                navBlocked = true;
            }

            if (Navigation.ModalStack.Count > 0 && Navigation.ModalStack.Last() is INavigationContainer modalContainer)
            {
                modalContainer.Block();
                modalBlocked = true;
                var modal = Navigation.ModalStack.Last();
                var modal1 = page;

                if (modal.GetType() != modal1.GetType())
                {
                    modalBlocked = false;
                }

                if (modal is Views.TV.ModalPage modalTVPage1 && modal1 is Views.TV.ModalPage modalTVPage2 && modalTVPage1.GetContentType() != modalTVPage2.GetContentType())
                {
                    modalBlocked = false;
                }

                if (modal is ModalPage modalPage1 && modal1 is ModalPage modalPage2 && modalPage1.GetContentType() != modalPage2.GetContentType())
                {
                    modalBlocked = false;
                }
            }

            if (!navBlocked || !modalBlocked)
            {
                await Navigation?.PushModalAsync(page);
            }

        }

        public async Task PopAsync()
        {
            await Navigation?.PopAsync();
            if (Navigation.NavigationStack.Count > 0 && Navigation.NavigationStack.Last() is INavigationContainer container)
            {
                container.Unblock();
            }
        }
        public async Task PopModalAsync()
        {
            try
            {
                await Navigation?.PopModalAsync();
            }
            catch
            {
                //Ignore
            }
            if (Navigation.NavigationStack.Count > 0 && Navigation.NavigationStack.Last() is INavigationContainer container)
            {
                container.Unblock();
            }

            if (Navigation.ModalStack.Count > 0 && Navigation.ModalStack.Last() is INavigationContainer modalContainer)
            {
                modalContainer.Unblock();
            }
        }
        public async Task Pop()
        {
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
