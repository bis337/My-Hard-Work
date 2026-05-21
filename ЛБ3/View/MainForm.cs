using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Главная форма приложения для работы с фигурами.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список фигур.
        /// </summary>
        private readonly List<IShape> _shapes = new List<IShape>();

        /// <summary>
        /// Инициализирует главную форму приложения.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ShapesGridView.ReadOnly = true;
            ShapesGridView.AllowUserToAddRows = false;
            ShapesGridView.AllowUserToDeleteRows = false;
            ShapesGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            ShapesGridView.MultiSelect = false;

            InitializeGrid();
        }

        /// <summary>
        /// Инициализирует таблицу фигур.
        /// </summary>
        private void InitializeGrid()
        {
            ShapesGridView.Columns.Clear();
            ShapesGridView.Columns.Add("Type", "Тип");
            ShapesGridView.Columns.Add("Area", "Площадь");
            ShapesGridView.Columns.Add("Perimeter", "Периметр");
            ShapesGridView.Columns.Add("Description", "Описание");

            ShapesGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddShapeForm form = new AddShapeForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _shapes.Add(form.Shape);
                UpdateGrid();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedShape();
        }

        /// <summary>
        /// Обрабатывает нажатие клавиши в таблице фигур.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события клавиатуры.</param>
        private void ShapesGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedShape();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Удаляет выбранную фигуру из списка.
        /// </summary>
        private void RemoveSelectedShape()
        {
            if (ShapesGridView.CurrentRow == null)
            {
                return;
            }

            int index = ShapesGridView.CurrentRow.Index;

            if (index >= 0 && index < _shapes.Count)
            {
                _shapes.RemoveAt(index);
                UpdateGrid();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки сохранения фигур.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Файл фигур (*.shapes)|*.shapes"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<ShapeData> data = _shapes
                    .Select(ShapeFactory.ConvertToData)
                    .ToList();

                ShapeFileManager.SaveToFile(data, dialog.FileName);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки загрузки фигур.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файл фигур (*.shapes)|*.shapes"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<ShapeData> data =
                        ShapeFileManager.LoadFromFile(dialog.FileName);

                    List<IShape> loadedShapes = new List<IShape>();

                    foreach (ShapeData item in data)
                    {
                        loadedShapes.Add(ShapeFactory.CreateShape(item));
                    }

                    _shapes.Clear();
                    _shapes.AddRange(loadedShapes);

                    UpdateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка загрузки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска фигур.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm(_shapes);
            form.ShowDialog();
        }

        /// <summary>
        /// Обновляет таблицу фигур.
        /// </summary>
        private void UpdateGrid()
        {
            ShapesGridView.Rows.Clear();

            foreach (IShape shape in _shapes)
            {
                ShapesGridView.Rows.Add(
                    shape.Name,
                    shape.CalculateArea().ToString(Constants.FormatPrecision),
                    shape.CalculatePerimeter().ToString(
                        Constants.FormatPrecision),
                    shape.ToString());
            }
        }
    }
}