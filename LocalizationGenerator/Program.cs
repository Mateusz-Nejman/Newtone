using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace LocalizationGenerator
{
    static class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\Languages\Localization.resx");
            var root = doc.SelectSingleNode("root");

            StringBuilder baseBuilder = new StringBuilder("public abstract class LocalizationBase{\n");
            StringBuilder propertyBuilder = new StringBuilder();

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
                baseBuilder.AppendLine($"public string Base{name} {{ get; }}");
                propertyBuilder.Append($"/// <summary>\n/// Wyszukuje zlokalizowany ciąg podobny do ciągu {value}\n/// </summary>\n");
                propertyBuilder.Append($"public static string {name} {{ get {{ return CurrentLocalization.Base{name}; }} }}\n");
            }

            baseBuilder.Append("}");
            string template = File.ReadAllText("baseTemplate.txt");
            template = template.Replace("[BODY]", propertyBuilder + "\n" + baseBuilder);
            File.WriteAllText(@"..\..\..\..\Newtone.Core\Languages\Localization.cs", template);

            Generate("pl");
            Generate("en");
            Generate("ru");
            Console.WriteLine("End");
        }

        static void Generate(string lang)
        {
            string input = lang == "pl" ? "" : "." + lang;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\Languages\Localization" + input + ".resx");

            var root = doc.SelectSingleNode("root");

            StringBuilder baseBuilder = new StringBuilder("namespace Newtone.Core.Languages{public class Localization" + lang.ToUpper() + " : Localization.LocalizationBase{\n");

            foreach (XmlNode item in root.SelectNodes("data"))
            {
                string name = item.Attributes["name"].InnerText;
                string value = item.SelectSingleNode("value").InnerText;
                baseBuilder.AppendLine($"public new string Base{name} {{ get; }} = \"{value}\";");
            }

            baseBuilder.Append("}}");
            File.WriteAllText(@"..\..\..\..\Newtone.Core\Languages\Localization" + lang.ToUpper() + ".cs", baseBuilder.ToString());
        }
    }
}
