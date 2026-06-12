using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Сохраняет и загружает фигуры в файлы с конкретными DTO.
    /// </summary>
    public static class ShapeFileManager
    {
        /// <summary>
        /// Сохраняет список фигур в файл.
        /// </summary>
        public static void SaveToFile(List<IShape> shapes, string path)
        {
            List<object> dtoList = new List<object>();
            foreach (var shape in shapes)
            {
                dtoList.Add(ShapeFactory.ConvertToData(shape));
            }

            using FileStream stream = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(
                typeof(List<object>),
                new Type[] { typeof(CircleData), typeof(RectangleData), typeof(TriangleData) });
            serializer.Serialize(stream, dtoList);
        }

        /// <summary>
        /// Загружает список фигур из файла.
        /// </summary>
        public static List<IShape> LoadFromFile(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(
                typeof(List<object>),
                new Type[] { typeof(CircleData), typeof(RectangleData), typeof(TriangleData) });

            List<object> dtoList = (List<object>)serializer.Deserialize(stream);
            List<IShape> shapes = new List<IShape>();

            foreach (var dto in dtoList)
            {
                shapes.Add(ShapeFactory.CreateShape(dto));
            }

            return shapes;
        }
    }
}