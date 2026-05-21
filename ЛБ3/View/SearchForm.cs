using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма поиска фигур по списку.
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Список фигур для поиска.
        /// </summary>
        private readonly List<IShape> _shapes;

        /// <summary>
        /// Инициализирует форму поиска фигур.
        /// </summary>
        /// <param name="shapes">Список фигур для поиска.</param>
        public SearchForm(List<IShape> shapes)
        {
            InitializeComponent();
            _shapes = shapes;

            InitializeResultsGrid();
        }

        /// <summary>
        /// Инициализирует таблицу результатов поиска.
        /// </summary>
        private void InitializeResultsGrid()
        {
            ResultsGridView.ReadOnly = true;
            ResultsGridView.AllowUserToAddRows = false;
            ResultsGridView.AllowUserToDeleteRows = false;
            ResultsGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            ResultsGridView.Columns.Clear();
            ResultsGridView.Columns.Add("Type", "Тип");
            ResultsGridView.Columns.Add("Area", "Площадь");
            ResultsGridView.Columns.Add("Perimeter", "Периметр");
            ResultsGridView.Columns.Add("Description", "Описание");
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            ResultsGridView.Rows.Clear();

            string search = SearchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(search))
            {
                MessageBox.Show(
                    "Введите текст для поиска.",
                    "Ошибка поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            List<IShape> results = _shapes
                .Where(shape => IsShapeMatchesSearch(shape, search))
                .ToList();

            foreach (IShape shape in results)
            {
                ResultsGridView.Rows.Add(
                    shape.Name,
                    shape.CalculateArea().ToString(Constants.FormatPrecision),
                    shape.CalculatePerimeter().ToString(
                        Constants.FormatPrecision),
                    shape.ToString());
            }

            if (results.Count == 0)
            {
                MessageBox.Show(
                    "Фигур не найдено.",
                    "Результат поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Проверяет, соответствует ли фигура поисковому запросу.
        /// </summary>
        /// <param name="shape">Фигура.</param>
        /// <param name="search">Поисковый запрос.</param>
        /// <returns>
        /// Возвращает true, если фигура соответствует запросу.
        /// </returns>
        private static bool IsShapeMatchesSearch(IShape shape, string search)
        {
            return shape.Name.ToLower().Contains(search)
                || shape.ToString().ToLower().Contains(search)
                || GetShapeParameters(shape).Contains(search);
        }

        /// <summary>
        /// Получает строку с параметрами фигуры.
        /// </summary>
        /// <param name="shape">Фигура.</param>
        /// <returns>Строка с параметрами фигуры.</returns>
        private static string GetShapeParameters(IShape shape)
        {
            if (shape is Circle circle)
            {
                return circle.Radius.ToString(Constants.FormatPrecision);
            }

            if (shape is Model.Rectangle rectangle)
            {
                return $"{rectangle.Width.ToString(Constants.FormatPrecision)} " +
                    $"{rectangle.Height.ToString(Constants.FormatPrecision)}";
            }

            if (shape is Triangle triangle)
            {
                return $"{triangle.SideA.ToString(Constants.FormatPrecision)} " +
                    $"{triangle.SideB.ToString(Constants.FormatPrecision)} " +
                    $"{triangle.SideC.ToString(Constants.FormatPrecision)}";
            }

            return string.Empty;
        }
    }
}