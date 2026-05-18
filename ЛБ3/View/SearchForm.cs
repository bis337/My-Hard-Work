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
        private readonly List<IShape> _shapes;

        public SearchForm(List<IShape> shapes)
        {
            InitializeComponent();
            _shapes = shapes;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ResultsListBox.Items.Clear();

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
                .Where(shape => shape.Name.ToLower().Contains(search))
                .ToList();

            foreach (IShape shape in results)
                ResultsListBox.Items.Add(shape.ToString());

            if (results.Count == 0)
            {
                MessageBox.Show(
                    "Фигур не найдено.",
                    "Результат поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}