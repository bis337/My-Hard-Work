using Model;
using System;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма добавления фигуры.
    /// </summary>
    public partial class AddShapeForm : Form
    {
        /// <summary>
        /// Получает созданную фигуру.
        /// </summary>
        public IShape Shape { get; private set; }

        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Инициализирует форму добавления фигуры.
        /// </summary>
        public AddShapeForm()
        {
            InitializeComponent();

            ShapeTypeComboBox.Items.Add("Круг");
            ShapeTypeComboBox.Items.Add("Прямоугольник");
            ShapeTypeComboBox.Items.Add("Треугольник");

            ShapeTypeComboBox.SelectedIndex = 0;

#if !DEBUG
            RandomButton.Visible = false;
#endif
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления фигуры.
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string type = ShapeTypeComboBox.Text;

                if (type == "Круг")
                {
                    if (string.IsNullOrWhiteSpace(Value1TextBox.Text))
                        throw new ArgumentException("Введите радиус круга.");

                    Shape = new Circle(
                        Convert.ToDouble(Value1TextBox.Text));
                }
                else if (type == "Прямоугольник")
                {
                    if (string.IsNullOrWhiteSpace(Value1TextBox.Text) ||
                        string.IsNullOrWhiteSpace(Value2TextBox.Text))
                        throw new ArgumentException
                            ("Введите ширину и высоту прямоугольника.");

                    Shape = new Model.Rectangle(
                        Convert.ToDouble(Value1TextBox.Text),
                        Convert.ToDouble(Value2TextBox.Text));
                }
                else if (type == "Треугольник")
                {
                    if (string.IsNullOrWhiteSpace(Value1TextBox.Text) ||
                        string.IsNullOrWhiteSpace(Value2TextBox.Text) ||
                        string.IsNullOrWhiteSpace(Value3TextBox.Text))
                        throw new ArgumentException
                            ("Введите все три стороны треугольника.");

                    Shape = new Triangle(
                        Convert.ToDouble(Value1TextBox.Text),
                        Convert.ToDouble(Value2TextBox.Text),
                        Convert.ToDouble(Value3TextBox.Text));
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки отмены.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Генерирует случайные значения фигуры.
        /// </summary>
        private void RandomButton_Click(object sender, EventArgs e)
        {
            int type = _random.Next(0, 3);
            ShapeTypeComboBox.SelectedIndex = type;

            Value1TextBox.Text = _random.Next(1, 20).ToString();
            Value2TextBox.Text = _random.Next(1, 20).ToString();
            Value3TextBox.Text = _random.Next(1, 20).ToString();
        }

        /// <summary>
        /// Меняет доступность полей в зависимости от типа фигуры.
        /// </summary>
        private void ShapeTypeComboBox_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            string type = ShapeTypeComboBox.Text;

            Value2TextBox.Enabled = type != "Круг";
            Value3TextBox.Enabled = type == "Треугольник";
        }
    }
}