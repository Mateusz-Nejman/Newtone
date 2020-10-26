﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace LocalizationGenerator
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Projekty\CS\Newtone\LocalizationGenerator\Languages\Localization.resx");
            var root = doc.SelectSingleNode("root");

            string buffer = "public abstract class LocalizationBase{\n";
            string propertyBuffer = "";

            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> names = new List<string>();

            foreach (XmlNode item in root.SelectNodes("data"))
            {
                string name = item.Attributes["name"].InnerText;
                string value = item.SelectSingleNode("value").InnerText;
                dict.Add(name, value);
                names.Add(name);
            }

            names.Sort();

            foreach (var name in names)
            {
                string value = dict[name];
                buffer += $"public string {name} = \"{value}\";\n";
                propertyBuffer += $"/// <summary>\n/// Wyszukuje zlokalizowany ciąg podobny do ciągu {value}\n/// </summary>\n";
                propertyBuffer += $"public static string {name} {{ get {{ return CurrentLocalization.{name}; }} }}\n";
            }

            buffer += "}";
            string template = File.ReadAllText("baseTemplate.txt");
            template = template.Replace("[BODY]", propertyBuffer + "\n" + buffer);
            File.WriteAllText(@"D:\Projekty\CS\Newtone\Newtone.Core\Languages\Localization.cs", template);

            Generate("en");
            Generate("ru");
            Console.WriteLine("End");
        }

        static void Generate(string lang)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Projekty\CS\Newtone\LocalizationGenerator\Languages\Localization." + lang + ".resx");

            var root = doc.SelectSingleNode("root");

            string buffer = "namespace Newtone.Core.Languages{public class Localization" + lang.ToUpper() + " : Localization.LocalizationBase{\npublic Localization" + lang.ToUpper() + "(){\n";

            foreach (XmlNode item in root.SelectNodes("data"))
            {
                string name = item.Attributes["name"].InnerText;
                string value = item.SelectSingleNode("value").InnerText;
                buffer += $"this.{name} = \"{value}\";\n";
            }

            buffer += "}}}";
            File.WriteAllText(@"D:\Projekty\CS\Newtone\Newtone.Core\Languages\Localization" + lang.ToUpper() + ".cs", buffer);
        }
    }
}
