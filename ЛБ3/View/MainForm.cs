using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Главная форма приложения для работы с фигурами.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список фигур, отображаемых в таблице.
        /// </summary>
        private readonly List<IShape> _shapes =
            new List<IShape>();

        /// <summary>
        /// Инициализирует главную форму.
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
        /// Обрабатывает добавление фигуры.
        /// </summary>
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
        /// Обрабатывает удаление фигуры.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedShape();
        }

        /// <summary>
        /// Обрабатывает клавишу Delete.
        /// </summary>
        private void ShapesGridView_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedShape();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Удаляет выбранную фигуру.
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
        /// Сохраняет фигуры в файл.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Файл фигур (*.shapes)|*.shapes"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShapeFileManager.SaveToFile(
                    _shapes,
                    dialog.FileName);
            }
        }

        /// <summary>
        /// Загружает фигуры из файла.
        /// </summary>
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
                    List<IShape> loadedShapes =
                        ShapeFileManager.LoadFromFile(
                            dialog.FileName);

                    _shapes.Clear();
                    _shapes.AddRange(loadedShapes);

                    UpdateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Ошибка загрузки:\n" + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Открывает форму поиска.
        /// </summary>
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
                    shape.CalculateArea().ToString(
                        Constants.FormatPrecision),
                    shape.CalculatePerimeter().ToString(
                        Constants.FormatPrecision),
                    shape.ToString());
            }
        }
    }
}