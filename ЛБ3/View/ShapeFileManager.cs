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
        //TODO: XML +
        /// <summary>
        /// Сохраняет данные фигур в файл.
        /// </summary>
        /// <param name="shapes">Список данных фигур.</param>
        /// <param name="path">Путь к файлу.</param>
        public static void SaveToFile(List<ShapeData> shapes, string path)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<ShapeData>));
            using FileStream stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, shapes);
        }

        /// <summary>
        /// Загружает данные фигур из файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Список данных фигур.</returns>
        public static List<ShapeData> LoadFromFile(string path)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<ShapeData>));
            using FileStream stream = new FileStream(path, FileMode.Open);
            return (List<ShapeData>)serializer.Deserialize(stream);
        }
    }
}