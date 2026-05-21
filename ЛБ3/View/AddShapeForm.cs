using Model;
using System;
using System.Globalization;
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

#if DEBUG
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new Random();
#endif

        /// <summary>
        /// Инициализирует форму добавления фигуры.
        /// </summary>
        public AddShapeForm()
        {
            InitializeComponent();

            ShapeTypeComboBox.Items.Add(ShapeTypes.Circle);
            ShapeTypeComboBox.Items.Add(ShapeTypes.Rectangle);
            ShapeTypeComboBox.Items.Add(ShapeTypes.Triangle);

            ShapeTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string type = ShapeTypeComboBox.Text;

                switch (type)
                {
                    //TODO: отступы +
                    case ShapeTypes.Circle:
                    {
                        Shape = new Circle(ParseValue(
                            Value1TextBox,
                            "Введите радиус круга числом."));
                        break;
                    }

                    case ShapeTypes.Rectangle:
                    {
                        Shape = new Model.Rectangle(
                            ParseValue(
                                Value1TextBox,
                                "Введите ширину прямоугольника числом."),
                            ParseValue(
                                Value2TextBox,
                                "Введите высоту прямоугольника числом."));
                        break;
                    }

                    case ShapeTypes.Triangle:
                    {
                        Shape = new Triangle(
                            ParseValue(
                                Value1TextBox,
                                "Введите первую сторону треугольника числом."),
                            ParseValue(
                                Value2TextBox,
                                "Введите вторую сторону треугольника числом."),
                            ParseValue(
                                Value3TextBox,
                                "Введите третью сторону треугольника числом."));
                        break;
                    }

                    default:
                    {
                        throw new ArgumentException("Неизвестный тип фигуры.");
                    }
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
        /// Преобразует значение текстового поля в число.
        /// </summary>
        /// <param name="textBox">Текстовое поле.</param>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <returns>Числовое значение.</returns>
        /// <exception cref="ArgumentException">
        /// Генерируется, если значение пустое или не является числом.
        /// </exception>
        private static double ParseValue(
            TextBox textBox,
            string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                throw new ArgumentException(errorMessage);
            }

            string value = textBox.Text.Replace(',', '.');

            if (!double.TryParse(
                    value,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out double result))
            {
                throw new ArgumentException(errorMessage);
            }

            return result;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки отмены.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

#if DEBUG
        /// <summary>
        /// Генерирует случайные значения фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RandomButton_Click(object sender, EventArgs e)
        {
            int type = _random.Next(0, 3);
            ShapeTypeComboBox.SelectedIndex = type;

            switch (ShapeTypeComboBox.Text)
            {
                //TODO: отступы +
                case ShapeTypes.Circle:
                {
                    Value1TextBox.Text = _random.Next(1, 20).ToString();
                    break;
                }

                case ShapeTypes.Rectangle:
                {
                    Value1TextBox.Text = _random.Next(1, 20).ToString();
                    Value2TextBox.Text = _random.Next(1, 20).ToString();
                    break;
                }

                case ShapeTypes.Triangle:
                {
                    GenerateTriangleValues();
                    break;
                }
            }
        }

        /// <summary>
        /// Генерирует корректные стороны треугольника.
        /// </summary>
        private void GenerateTriangleValues()
        {
            int sideA = _random.Next(1, 20);
            int sideB = _random.Next(1, 20);
            int minSideC = Math.Abs(sideA - sideB) + 1;
            int maxSideC = sideA + sideB - 1;
            int sideC = _random.Next(minSideC, maxSideC + 1);

            Value1TextBox.Text = sideA.ToString();
            Value2TextBox.Text = sideB.ToString();
            Value3TextBox.Text = sideC.ToString();
        }
#endif

        /// <summary>
        /// Меняет видимость полей в зависимости от типа фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ShapeTypeComboBox_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            string type = ShapeTypeComboBox.Text;

            Value1TextBox.Visible = true;
            Value1Label.Visible = true;

            Value2TextBox.Visible = type != ShapeTypes.Circle;
            Value2Label.Visible = type != ShapeTypes.Circle;

            Value3TextBox.Visible = type == ShapeTypes.Triangle;
            Value3Label.Visible = type == ShapeTypes.Triangle;

            switch (type)
            {
                //TODO: отступы +
                case ShapeTypes.Circle:
                {
                    Value1Label.Text = "Радиус:";
                    break;
                }

                case ShapeTypes.Rectangle:
                {
                    Value1Label.Text = "Ширина:";
                    Value2Label.Text = "Высота:";
                    break;
                }

                case ShapeTypes.Triangle:
                {
                    Value1Label.Text = "Сторона A:";
                    Value2Label.Text = "Сторона B:";
                    Value3Label.Text = "Сторона C:";
                    break;
                }
            }
        }
    }
}