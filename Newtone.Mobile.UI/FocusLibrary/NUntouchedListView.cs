using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public class NUntouchedListView : ScrollView, INFocusElement
    {
        #region Fields
        protected StackLayout container;
        private bool active = false;
        #endregion
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NUntouchedListView), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NFocusColorProperty =
            BindableProperty.Create("NFocusColor", typeof(Color), typeof(NUntouchedListView), Color.White);

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NUntouchedListView));
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NUntouchedListView));
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NUntouchedListView));
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NUntouchedListView));

        public static readonly BindableProperty NOrientationProperty =
            BindableProperty.Create("NOrientation", typeof(ScrollOrientation), typeof(NUntouchedListView), propertyChanged: OrientationChanged);

        public static readonly BindableProperty NItemSourceProperty =
            BindableProperty.Create("NItemSource", typeof(ObservableCollection<NListViewItem>), typeof(NUntouchedListView), propertyChanged: ItemSourceChanged);

        public static readonly BindableProperty NItemTemplateProperty =
            BindableProperty.Create("NItemTemplate", typeof(Func<NListViewItem, View>), typeof(NUntouchedListView));

        public static readonly BindableProperty NFocusedIndexProperty =
            BindableProperty.Create("NFocusedIndex", typeof(int), typeof(NUntouchedListView), -1,
                BindingMode.TwoWay, propertyChanged: null);

        public static readonly BindableProperty NItemWidthProperty =
            BindableProperty.Create("NItemWidth", typeof(int), typeof(NUntouchedListView), -1);
        public static readonly BindableProperty NItemHeightProperty =
            BindableProperty.Create("NItemHeight", typeof(int), typeof(NUntouchedListView), -1);

        public static readonly BindableProperty NItemSelectedProperty =
            BindableProperty.Create("NItemSelected", typeof(ICommand), typeof(NUntouchedListView));

        public static readonly BindableProperty NItemAppearingProperty =
            BindableProperty.Create("NItemAppearing", typeof(ICommand), typeof(NUntouchedListView));

        public bool IsNFocused
        {
            set { SetValue(IsNFocusedProperty, value); }
            get { return (bool)GetValue(IsNFocusedProperty); }
        }

        public Color NFocusColor
        {
            set { SetValue(NFocusColorProperty, value); }
            get { return (Color)GetValue(NFocusColorProperty); }
        }

        public INFocusElement NextFocusLeft
        {
            set { SetValue(NextFocusLeftProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusLeftProperty); }
        }

        public INFocusElement NextFocusRight
        {
            set { SetValue(NextFocusRightProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusRightProperty); }
        }

        public INFocusElement NextFocusUp
        {
            set { SetValue(NextFocusUpProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusUpProperty); }
        }

        public INFocusElement NextFocusDown
        {
            set { SetValue(NextFocusDownProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusDownProperty); }
        }

        public Func<NListViewItem, View> NItemTemplate
        {
            set { SetValue(NItemTemplateProperty, value); }
            get { return (Func<NListViewItem, View>)GetValue(NItemTemplateProperty); }
        }

        public ScrollOrientation NOrientation
        {
            set { SetValue(NOrientationProperty, value); }
            get { return (ScrollOrientation)GetValue(NOrientationProperty); }
        }

        public ObservableCollection<NListViewItem> NItemSource
        {
            set { SetValue(NItemSourceProperty, value); }
            get { return (ObservableCollection<NListViewItem>)GetValue(NItemSourceProperty); }
        }

        public int NFocusedIndex
        {
            set
            {
                int old = NFocusedIndex;
                SetValue(NFocusedIndexProperty, value);
                FocusSpecified(old, value);
                NItemSelected?.Execute(value);
                if(container.Children.Count > value)
                {
                    this.ScrollToAsync(container.Children[value], ScrollToPosition.MakeVisible, false);
                }
                
            }
            get { return (int)GetValue(NFocusedIndexProperty); }
        }

        public int NItemWidth
        {
            set { SetValue(NItemWidthProperty, value); }
            get { return (int)GetValue(NItemWidthProperty); }
        }

        public int NItemHeight
        {
            set { SetValue(NItemHeightProperty, value); }
            get { return (int)GetValue(NItemHeightProperty); }
        }

        public ICommand NItemSelected
        {
            set { SetValue(NItemSelectedProperty, value); }
            get { return (ICommand)GetValue(NItemSelectedProperty); }
        }

        public ICommand NItemAppearing
        {
            set { SetValue(NItemAppearingProperty, value); }
            get { return (ICommand)GetValue(NItemAppearingProperty); }
        }
        #endregion
        #region Constructors
        public NUntouchedListView()
        {
            FocusContext.Register(this);
            container = new StackLayout
            {
                Spacing = 0
            };
            Content = container;

            this.IsEnabled = false;
        }

        ~NUntouchedListView()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NUntouchedListView focusButton = (NUntouchedListView)bindable;
            bool isFocused = (bool)newValue;

            if (isFocused)
            {
                focusButton.active = true;
            }

            if(isFocused && focusButton.NItemSource.Count > 0 && focusButton.NFocusedIndex == -1)
            {
                focusButton.NFocusedIndex = 0;
                focusButton.NItemSource[0].IsNFocused = true;
                (focusButton.container.Children[0] as Frame).BorderColor = focusButton.NFocusColor;
            }

            if(isFocused && focusButton.NFocusedIndex >= 0)
            {
                focusButton.NItemSource[focusButton.NFocusedIndex].IsNFocused = true;
                (focusButton.container.Children[focusButton.NFocusedIndex] as Frame).BorderColor = focusButton.NFocusColor;
            } 
        }

        private static void OrientationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ScrollOrientation orientation = (ScrollOrientation)newValue;

            NUntouchedListView listView = bindable as NUntouchedListView;
            listView.Orientation = orientation;
            listView.container.Orientation = orientation == ScrollOrientation.Horizontal ? StackOrientation.Horizontal : StackOrientation.Vertical;
        }

        private static void ItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NUntouchedListView listView = bindable as NUntouchedListView;
            Device.BeginInvokeOnMainThread(listView.Rerender);

            if (oldValue is ObservableCollection<NListViewItem> oldList)
            {
                oldList.CollectionChanged -= listView.NItemSource_CollectionChanged;
            }

            if (newValue is ObservableCollection<NListViewItem> newList)
            {
                listView.NItemSource.CollectionChanged += listView.NItemSource_CollectionChanged;
            }
        }

        protected void NItemSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                container.Children.Insert(e.NewStartingIndex, CreateItem((NListViewItem)e.NewItems[0]));
                NItemSource[e.NewStartingIndex].NFocusColor = NFocusColor;
                NItemSource[e.NewStartingIndex].ParentListView = this;
                NItemSource[e.NewStartingIndex].SetFrame(container.Children[e.NewStartingIndex] as Frame);

                if(e.NewStartingIndex == 0 && IsNFocused)
                {
                    NItemSource[0].IsNFocused = true;
                }

                bool prev = e.NewStartingIndex > 0;
                bool next = e.NewStartingIndex < NItemSource.Count - 1;

                if (NOrientation == ScrollOrientation.Horizontal)
                {
                    if (prev)
                    {
                        NItemSource[e.NewStartingIndex - 1].NextFocusRight = NItemSource[e.NewStartingIndex];
                    }

                    if (next)
                    {
                        NItemSource[e.NewStartingIndex + 1].NextFocusLeft = NItemSource[e.NewStartingIndex];
                    }

                    NItemSource[e.NewStartingIndex].NextFocusUp = NextFocusUp;
                    NItemSource[e.NewStartingIndex].NextFocusDown = NextFocusDown;
                }
                else
                {
                    if (prev)
                    {
                        NItemSource[e.NewStartingIndex - 1].NextFocusDown = NItemSource[e.NewStartingIndex];
                    }

                    if (next)
                    {
                        NItemSource[e.NewStartingIndex+1].NextFocusUp = NItemSource[e.NewStartingIndex];
                    }

                    NItemSource[e.NewStartingIndex].NextFocusLeft = NextFocusLeft;
                    NItemSource[e.NewStartingIndex].NextFocusRight = NextFocusRight;
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                container.Children.RemoveAt(e.OldStartingIndex);

                bool prev = e.OldStartingIndex > 0;
                bool next = e.OldStartingIndex < NItemSource.Count - 1;

                if (container.Children.Count > 0 && NFocusedIndex >= container.Children.Count)
                {
                    NFocusedIndex = container.Children.Count - 1;
                }

                if (NOrientation == ScrollOrientation.Horizontal)
                {
                    if(prev)
                    {
                        NItemSource[e.OldStartingIndex - 1].NextFocusRight = next ? NItemSource[e.OldStartingIndex] : null;
                    }
                    
                    if(next)
                    {
                        NItemSource[e.OldStartingIndex].NextFocusLeft = prev ? NItemSource[e.OldStartingIndex-1] : null;
                    }
                }
                else
                {
                    if (prev)
                    {
                        NItemSource[e.OldStartingIndex - 1].NextFocusDown = next ? NItemSource[e.OldStartingIndex] : null;
                    }

                    if (next)
                    {
                        NItemSource[e.OldStartingIndex].NextFocusUp = prev ? NItemSource[e.OldStartingIndex - 1] : null;
                    }
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Replace)
            {
                container.Children[e.NewStartingIndex] = CreateItem((NListViewItem)e.NewItems[0]);
                NItemSource[e.NewStartingIndex].NFocusColor = NFocusColor;
                NItemSource[e.NewStartingIndex].ParentListView = this;
                NItemSource[e.NewStartingIndex].SetFrame(container.Children[e.NewStartingIndex] as Frame);

                if (e.NewStartingIndex == NFocusedIndex && active)
                {
                    NItemSource[e.NewStartingIndex].IsNFocused = true;
                }

                if (e.NewStartingIndex > 0)
                {
                    if (NOrientation == ScrollOrientation.Horizontal)
                    {
                        NItemSource[e.NewStartingIndex - 1].NextFocusRight = NItemSource[e.NewStartingIndex];
                        NItemSource[e.NewStartingIndex].NextFocusLeft = NItemSource[e.NewStartingIndex - 1];
                        NItemSource[e.NewStartingIndex].NextFocusUp = NextFocusUp;
                        NItemSource[e.NewStartingIndex].NextFocusDown = NextFocusDown;
                    }
                    else
                    {
                        NItemSource[e.NewStartingIndex - 1].NextFocusDown = NItemSource[e.NewStartingIndex];
                        NItemSource[e.NewStartingIndex].NextFocusUp = NItemSource[e.NewStartingIndex - 1];
                        NItemSource[e.NewStartingIndex].NextFocusLeft = NextFocusLeft;
                        NItemSource[e.NewStartingIndex].NextFocusRight = NextFocusRight;
                    }
                }

                if (e.NewStartingIndex < NItemSource.Count - 1)
                {
                    if (NOrientation == ScrollOrientation.Horizontal)
                    {
                        NItemSource[e.NewStartingIndex + 1].NextFocusLeft = NItemSource[e.NewStartingIndex];
                        NItemSource[e.NewStartingIndex].NextFocusRight = NItemSource[e.NewStartingIndex + 1];
                        NItemSource[e.NewStartingIndex].NextFocusUp = NextFocusUp;
                        NItemSource[e.NewStartingIndex].NextFocusDown = NextFocusDown;
                    }
                    else
                    {
                        NItemSource[e.NewStartingIndex + 1].NextFocusUp = NItemSource[e.NewStartingIndex];
                        NItemSource[e.NewStartingIndex].NextFocusDown = NItemSource[e.NewStartingIndex + 1];
                        NItemSource[e.NewStartingIndex].NextFocusLeft = NextFocusLeft;
                        NItemSource[e.NewStartingIndex].NextFocusRight = NextFocusRight;
                    }
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Reset)
            {
                container.Children.Clear();
            }

            container.IsVisible = true;
        }

        private Frame CreateItem(NListViewItem item)
        {
            Frame frame = new Frame()
            {
                Padding = 10,
                Margin = 0,
                BorderColor = Color.Transparent,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = NItemWidth,
                HeightRequest = NItemHeight,
            };
            var view = NItemTemplate.Invoke(item);
            view.VerticalOptions = LayoutOptions.CenterAndExpand;
            view.HorizontalOptions = LayoutOptions.CenterAndExpand;
            frame.Content = view;

            return frame;
        }

        private bool FocusPrev()
        {
            if (NFocusedIndex - 1 >= 0 && NFocusedIndex - 1 < NItemSource.Count)
            {
                NFocusedIndex--;
                return true;
            }

            return false;
        }

        private void FocusSpecified(int old, int index)
        {
            INFocusElement oldElement = null;
            INFocusElement newElement = null;

            if(old >= 0 && old < NItemSource.Count)
            {
                oldElement = NItemSource[old];
            }

            if(index >= 0 && index < NItemSource.Count)
            {
                newElement = NItemSource[index];
            }

            FocusContext.ChangeFocus(oldElement, newElement);
        }
        #endregion
        #region Public Methods
        public void SetActive(bool active)
        {
            this.active = active;
        }
        public Frame GetFrame(int index)
        {
            return index >= 0 && index < NItemSource.Count ? container.Children[index] as Frame : null;
        }

        public View GetCurrentItemView()
        {
            if (NFocusedIndex < 0)
                return container.Children[0];

            if (NFocusedIndex >= container.Children.Count)
                return container.Children[container.Children.Count - 1];

            return container.Children[NFocusedIndex];
        }
        public void FocusLeft()
        {
            if(NOrientation == ScrollOrientation.Horizontal)
            {
                if(!FocusPrev() && FocusContext.FocusLeft(this))
                {
                    active = false;
                }
            }
            else
            {
                if (FocusContext.FocusLeft(this))
                {
                    active = false;
                }
            }
        }

        public void FocusRight()
        {
            if (NOrientation == ScrollOrientation.Horizontal)
            {
                if(!FocusNext() && FocusContext.FocusRight(this))
                {
                    active = false;
                }
            }
            else
            {
                if(FocusContext.FocusRight(this))
                {
                    active = false;
                }
            }
        }

        public void FocusUp()
        {
            if (NOrientation == ScrollOrientation.Vertical)
            {
                if(!FocusPrev() && FocusContext.FocusUp(this))
                {
                    active = false;
                }
            }
            else
            {
                if(FocusContext.FocusUp(this))
                {
                    active = false;
                }
            }
        }

        public void FocusDown()
        {
            if (NOrientation == ScrollOrientation.Vertical)
            {
                if(!FocusNext() && FocusContext.FocusDown(this))
                {
                    active = false;
                }
            }
            else
            {
                if (FocusContext.FocusDown(this))
                {
                    active = false;
                }
            }
        }

        public void FocusAction()
        {
            if(NFocusedIndex >= 0 && NFocusedIndex < NItemSource.Count)
            {
                NItemSource[NFocusedIndex].FocusAction();
            }
        }

        public void LongFocusAction()
        {
            if (NFocusedIndex >= 0 && NFocusedIndex < NItemSource.Count)
            {
                NItemSource[NFocusedIndex].LongFocusAction();
            }
        }

        private bool FocusNext()
        {
            if (NFocusedIndex + 1 >= 0 && NFocusedIndex + 1 < NItemSource.Count)
            {
                NFocusedIndex++;
                return true;
            }

            return false;
        }

        public void Rerender()
        {
            NItemSource_CollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            for (int a = 0; a < NItemSource.Count; a++)
            {
                NItemSource_CollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, NItemSource[a], a));
            }
        }
        #endregion
    }
}
