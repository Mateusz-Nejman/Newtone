using System.Collections.Generic;

namespace Nejman.Xamarin.FocusLibrary
{
    public static class FocusContext
    {
        private static readonly List<INFocusElement> elements = new List<INFocusElement>();
        public static bool FocusLeft(INFocusElement element)
        {
            return ChangeFocus(element, element.NextFocusLeft);
        }

        public static bool FocusRight(INFocusElement element)
        {
            return ChangeFocus(element, element.NextFocusRight);
        }

        public static bool FocusUp(INFocusElement element)
        {
            return ChangeFocus(element, element.NextFocusUp);
        }

        public static bool FocusDown(INFocusElement element)
        {
            return ChangeFocus(element, element.NextFocusDown);
        }

        public static void Register(INFocusElement element)
        {
            if (!elements.Contains(element))
                elements.Add(element);
        }

        public static void Unregister(INFocusElement element)
        {
            if (elements.Contains(element))
                elements.Remove(element);
        }

        public static INFocusElement GetFocusElement()
        {
            INFocusElement focusElement = null;
            foreach(var element in elements)
            {
                if (element.IsNFocused)
                    focusElement = element;
            }

            if (focusElement != null)
                return focusElement;

            if (elements.Count > 0)
            {
                elements[0].IsNFocused = true;
                return elements[0];
            }

            return null;
        }

        public static bool ChangeFocus(INFocusElement oldElement, INFocusElement newElement)
        {
            if(oldElement != null)
                oldElement.IsNFocused = true;
            if (newElement != null)
                System.Diagnostics.Debug.WriteLine(newElement.GetType());

            if (oldElement == newElement)
            {
                return false;
            }

            if (newElement != null)
            {
                if (oldElement != null)
                {
                    oldElement.IsNFocused = false;
                }
                UnfocusAll();
                newElement.PrevionsElement = oldElement;
                newElement.IsNFocused = true;
                return true;
            }

            return false;
        }

        public static void UnfocusAll()
        {
            foreach (var element in elements)
            {
                element.IsNFocused = false;
            }
        }
    }
}
