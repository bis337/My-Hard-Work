using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Сохраняет и загружает фигуры через DTO.
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

            XmlSerializer serializer = new XmlSerializer(
                typeof(List<object>),
                new Type[]
                {
                    typeof(CircleData),
                    typeof(RectangleData),
                    typeof(TriangleData)
                });

            using FileStream stream =
                new FileStream(path, FileMode.Create);

            serializer.Serialize(stream, dtoList);
        }

        /// <summary>
        /// Загружает список фигур из файла.
        /// </summary>
        public static List<IShape> LoadFromFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(List<object>),
                new Type[]
                {
                    typeof(CircleData),
                    typeof(RectangleData),
                    typeof(TriangleData)
                });
             
            using FileStream stream =
                new FileStream(path, FileMode.Open);

            var dtoList = (List<object>)serializer.Deserialize(stream);

            List<IShape> shapes = new List<IShape>();

            foreach (var dto in dtoList)
            {
                ValidateDto(dto);
                shapes.Add(ShapeFactory.CreateShape(dto));
            }

            return shapes;
        }

        /// <summary>
        /// Проверяет корректность DTO.
        /// </summary>
        private static void ValidateDto(object dto)
        {
            if (dto is CircleData c)
            {
                //TODO: {}+
                if (!IsValid(c.Radius))
                {
                    throw new InvalidDataException(
                        "Некорректный радиус.");
                }
            }

            if (dto is RectangleData r)
            {
                //TODO: {}+
                if (!IsValid(r.Width) || !IsValid(r.Height))
                {
                    throw new InvalidDataException(
                        "Некорректный прямоугольник.");
                }
            }

            if (dto is TriangleData t)
            {
                //TODO: {}+
                if (!IsValid(t.SideA) ||
                    !IsValid(t.SideB) ||
                    !IsValid(t.SideC))
                {
                    throw new InvalidDataException(
                        "Некорректный треугольник.");
                }
            }
        }

        /// <summary>
        /// Проверяет число.
        /// </summary>
        private static bool IsValid(double value)
        {
            return !(double.IsNaN(value) ||
                     double.IsInfinity(value) ||
                     value <= 0);
        }
    }
}