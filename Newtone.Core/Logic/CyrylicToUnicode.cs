using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public class CyrylicToUnicode
    {
        private const string cyrylicChars = "й;ц;у;к;е;н;г;ш;щ;з;х;ъ;ф;ы;в;а;п;р;о;л;д;ж;э;я;ч;с;м;и;т;ь;б;ю;ё;Ё;Й;Ц;У;К;Е;Н;Г;Ш;Щ;З;Х;Ъ;Ф;Ы;В;А;П;Р;О;Л;Д;Ж;Э;Я;Ч;С;М;И;Т;Ь;Б;Ю";
        private const string cyrylicToUnicodeChars = "j;c;u;k;e;n;g;sz;ś;z;h;b;f;y;w;a;p;r;o;l;d;ż;e;ja;cz;s;m;i;t;;b;ju;je;Je;J;C;U;K;E;N;G;Sz;Ś;Z;H;B;F;Y;W;A;P;R;O;L;D;Ż;E;Ja;Cz;S;M;I;T;;B;Ju";
        public static string Convert(string cyrylicString)
        {
            //й;ц;у;к;е;н;г;ш;щ;з;х;ъ;ф;ы;в;а;п;р;о;л;д;ж;э;я;ч;с;м;и;т;ь;б;ю;ё;Ё;Й;Ц;У;К;Е;Н;Г;Ш;Щ;З;Х;Ъ;Ф;Ы;В;А;П;Р;О;Л;Д;Ж;Э;Я;Ч;С;М;И;Т;Ь;Б;Ю
            
            string[] cyrylicArray = cyrylicChars.Split(';', StringSplitOptions.None);
            string[] unicodeArray = cyrylicToUnicodeChars.Split(';', StringSplitOptions.None);

            string newString = (string)cyrylicString.Clone();

            for(int a = 0; a < cyrylicArray.Length; a++)
            {
                newString = newString.Replace(cyrylicArray[a], unicodeArray[a]);
            }

            return newString;
        }

        public static bool IsCyrylic(string text)
        {
            foreach(string item in cyrylicChars.Split(';'))
            {
                if (text.Contains(item))
                    return true;
            }
            return false;
        }
    }
}
