using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Logic
{
    public class Cache : IEnumerable<byte[]>
    {
        private List<byte[]> cacheElements;
        public Cache()
        {
            cacheElements = new List<byte[]>();
        }

        public Cache(List<byte[]> cacheData)
        {
            cacheElements = new List<byte[]>(cacheData);
        }

        public void Add(string stringData)
        {
            Add(Encoding.UTF8.GetBytes(stringData));
        }

        public void Add(byte[] data)
        {
            cacheElements.Add(data);
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < cacheElements.Count)
                cacheElements.RemoveAt(index);
        }

        public byte[] Get(int index)
        {
            if (index >= 0 && index < cacheElements.Count)
                return cacheElements[index];
            else
                return new byte[0];
        }

        public string GetString(int index)
        {
            return Encoding.UTF8.GetString(Get(index));
        }

        public static Cache FromBytes(byte[] cacheData)
        {
            return FromString(Encoding.UTF8.GetString(cacheData));
        }
        public static Cache FromString(string cacheString)
        {
            
            string[] splits = cacheString.Split("[NSEC_SEPARATOR]", StringSplitOptions.RemoveEmptyEntries);
            List<byte[]> cacheElements = new List<byte[]>();

            foreach(string item in splits)
            {
                cacheElements.Add(Encoding.UTF8.GetBytes(item));
            }

            return new Cache(cacheElements);
        }

        public override string ToString()
        {
            string buffer = "";
            for(int a = 0; a < cacheElements.Count; a++)
            {
                buffer += cacheElements[a].ToString();

                if (a < cacheElements.Count - 1)
                    buffer += "[NSEC_SEPARATOR]";
            }

            return buffer;
        }

        public byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(ToString());
        }

        public IEnumerator<byte[]> GetEnumerator()
        {
            return cacheElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cacheElements.GetEnumerator();
        }
    }
}