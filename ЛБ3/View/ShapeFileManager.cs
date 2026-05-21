using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Класс для сохранения и загрузки фигур в файл и из файла.
    /// </summary>
    public static class ShapeFileManager
    {
        //TODO: XML
        public static void SaveToFile(List<ShapeDto> shapes, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ShapeDto>));
            using FileStream stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, shapes);
        }

        public static List<ShapeDto> LoadFromFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ShapeDto>));
            using FileStream stream = new FileStream(path, FileMode.Open);
            return (List<ShapeDto>)serializer.Deserialize(stream);
        }
    }
}