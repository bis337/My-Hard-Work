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
        private readonly List<IShape> _shapes = new List<IShape>();

        public MainForm()
        {
            InitializeComponent();

            ShapesGridView.ReadOnly = true;
            ShapesGridView.AllowUserToAddRows = false;

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            ShapesGridView.Columns.Clear();
            ShapesGridView.Columns.Add("Type", "Тип");
            ShapesGridView.Columns.Add("Area", "Площадь");
            ShapesGridView.Columns.Add("Perimeter", "Периметр");
            ShapesGridView.Columns.Add("Description", "Описание");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddShapeForm form = new AddShapeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _shapes.Add(form.Shape);
                UpdateGrid();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ShapesGridView.CurrentRow == null)
                return;

            int index = ShapesGridView.CurrentRow.Index;
            if (index >= 0 && index < _shapes.Count)
            {
                _shapes.RemoveAt(index);
                UpdateGrid();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Файл фигур (*.shapes)|*.shapes"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<ShapeDto> dto = _shapes
                    .Select(ShapeFactory.ConvertToDto)
                    .ToList();

                ShapeFileManager.SaveToFile(dto, dialog.FileName);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файл фигур (*.shapes)|*.shapes"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<ShapeDto> dto = 
                    ShapeFileManager.LoadFromFile(dialog.FileName);
                _shapes.Clear();

                foreach (ShapeDto item in dto)
                    _shapes.Add(ShapeFactory.CreateShape(item));

                UpdateGrid();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm(_shapes);
            form.ShowDialog();
        }

        private void UpdateGrid()
        {
            ShapesGridView.Rows.Clear();
            foreach (IShape shape in _shapes)
            {
                ShapesGridView.Rows.Add(
                    shape.Name,
                    shape.CalculateArea().ToString("F2"),
                    shape.CalculatePerimeter().ToString("F2"),
                    shape.ToString());
            }
        }
    }
}