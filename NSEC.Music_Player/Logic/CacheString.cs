using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace NSEC.Music_Player.Logic
{
    public class CacheString : IEnumerable<string>
    {
        private readonly List<string> cacheElements;
        public CacheString()
        {
            cacheElements = new List<string>();
        }

        public int Count
        {
            get
            {
                return cacheElements == null ? 0 : cacheElements.Count;
            }
        }

        public CacheString(List<string> cacheData)
        {
            cacheElements = new List<string>(cacheData);
        }

        public void Add(string stringData)
        {
            if (!cacheElements.Contains(stringData))
                cacheElements.Add(stringData);
        }

        public void Add(string[] stringData)
        {
            foreach (string data in stringData)
                Add(data);
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < cacheElements.Count)
                cacheElements.RemoveAt(index);
        }

        public string Get(int index)
        {
            if (index >= 0 && index < cacheElements.Count)
                return cacheElements[index];
            else
                return "";
        }

        public static CacheString FromBytes(byte[] cacheData)
        {
            return FromString(Encoding.UTF8.GetString(cacheData));
        }
        public static CacheString FromString(string cacheString)
        {

            string[] splits = cacheString.Split("[NSEC_SEPARATOR]", StringSplitOptions.RemoveEmptyEntries);

            return new CacheString(new List<string>(splits));
        }

        public override string ToString()
        {
            string buffer = "";
            for (int a = 0; a < cacheElements.Count; a++)
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

        public IEnumerator<string> GetEnumerator()
        {
            return cacheElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cacheElements.GetEnumerator();
        }
    }
}