using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Класс для сохранения и загрузки фигур в файлы с конкретными DTO.
    /// </summary>
    public static class ShapeFileManager
    {
        /// <summary>
        /// Сохраняет список фигур в файл.
        /// </summary>
        /// <param name="shapes">Список фигур.</param>
        /// <param name="path">Путь к файлу.</param>
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
        /// Загружает список фигур из файла с проверкой корректности данных.
        /// Если хотя бы одна фигура некорректна, генерируется исключение.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Список корректных фигур.</returns>
        /// <exception cref="ArgumentException">
        /// Генерируется, если в файле найдены некорректные данные.
        /// </exception>
        public static List<IShape> LoadFromFile(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(
                typeof(List<object>),
                new Type[] { typeof(CircleData), typeof(RectangleData), typeof(TriangleData) });

            List<object> dtoList;
            try
            {
                dtoList = (List<object>)serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    "Ошибка чтения файла: данные повреждены или имеют неверный формат.", ex);
            }

            List<IShape> shapes = new List<IShape>();

            foreach (var dto in dtoList)
            {
                try
                {
                    IShape shape = ShapeFactory.CreateShape(dto);
                    shapes.Add(shape);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(
                        $"Некорректные данные фигуры: {ex.Message}", ex);
                }
            }

            return shapes;
        }
    }
}