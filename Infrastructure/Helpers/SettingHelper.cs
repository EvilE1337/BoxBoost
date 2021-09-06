using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoxBoost.Infrastructure.Helpers
{
    internal static class SettingHelper
    {
        internal static void SaveSetting<T>(T data)
        {
            XmlSerializer formatter = new XmlSerializer(data.GetType());
            using (FileStream fs = new FileStream(data.GetType().Name + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        internal static T LoadSetting<T>(T data)
        {
            string pathFile = data.GetType().Name + ".xml";
            if (File.Exists(pathFile))
            {
                XmlSerializer xSer = new XmlSerializer(data.GetType());
                StreamReader reader = new StreamReader(pathFile);
                T DeserializeData = (T)xSer.Deserialize(reader);
                reader.Close();
                return DeserializeData;
            }
            return data;
        }

    }
}
