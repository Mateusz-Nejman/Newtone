using Newtone.Core.Models;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public abstract class NListViewItem : INFocusElement, IPropertyChangeBase
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Fields
        private Frame frame;
        private bool isNFocused = false;
        #endregion
        #region Properties
        public bool IsNFocused
        {
            get => isNFocused;
            set
            {
                isNFocused = value;
                OnIsNFocusedChanged();
            }
        }

        public Color NFocusColor { get; set; } = Color.White;

        public INFocusElement NextFocusLeft { get; set; }

        public INFocusElement NextFocusRight { get; set; }

        public INFocusElement NextFocusUp { get; set; }

        public INFocusElement NextFocusDown { get; set; }

        public NUntouchedListView ParentListView { get; set; }
        public INFocusElement PrevionsElement { get; set; } //not used
        #endregion
        #region Constructors
        protected NListViewItem()
        {
            FocusContext.Register(this);
        }

        ~NListViewItem()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private void OnIsNFocusedChanged()
        {
            if (frame != null)
            {
                frame.BorderColor = IsNFocused ? NFocusColor : Color.Transparent;
            }

            if(IsNFocused && ParentListView.NItemAppearing?.CanExecute(ParentListView.NFocusedIndex) == true)
            {
                ParentListView.NItemAppearing?.Execute(ParentListView.NFocusedIndex);
            }

            PrevionsElement = null;
        }
        #endregion
        #region Public Methods
        public void FocusLeft()
        {
            if (ParentListView.NOrientation == ScrollOrientation.Horizontal)
            {
                System.Diagnostics.Debug.WriteLine("Horizontal");
                ParentListView.FocusLeft();
            }
            else
            {
                if(FocusContext.FocusLeft(this))
                {
                    ParentListView.SetActive(false);
                }
            }
        }

        public void FocusRight()
        {
            if (ParentListView.NOrientation == ScrollOrientation.Horizontal)
            {
                ParentListView.FocusRight();
                
            }
            else
            {
                if(FocusContext.FocusRight(this))
                {
                    ParentListView.SetActive(false);
                }
            }
        }

        public void FocusUp()
        {
            if (ParentListView.NOrientation == ScrollOrientation.Vertical)
            {
                ParentListView.FocusUp();
            }
            else
            {
                if (FocusContext.FocusUp(this))
                {
                    ParentListView.SetActive(false);
                }
            }
        }

        public void FocusDown()
        {
            if (ParentListView.NOrientation == ScrollOrientation.Vertical)
            {
                ParentListView.FocusDown();
            }
            else
            {
                if (FocusContext.FocusDown(this))
                {
                    ParentListView.SetActive(false);
                }
            }
        }

        public virtual void FocusAction()
        {

        }

        public virtual void LongFocusAction()
        {

        }

        public void SetFrame(Frame frame)
        {
            this.frame = frame;
        }

        public void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((property.Body as MemberExpression).Member.Name));
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
