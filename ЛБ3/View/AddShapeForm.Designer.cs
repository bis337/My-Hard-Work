namespace View
{
    /// <summary>
    /// Дизайнер формы добавления фигуры.
    /// </summary>
    partial class AddShapeForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox ShapeTypeComboBox;
        private System.Windows.Forms.TextBox Value1TextBox;
        private System.Windows.Forms.TextBox Value2TextBox;
        private System.Windows.Forms.TextBox Value3TextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button RandomButton;

        /// <summary>
        /// Освобождает ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Инициализация элементов формы.
        /// </summary>
        private void InitializeComponent()
        {
            ShapeTypeComboBox = new System.Windows.Forms.ComboBox();
            Value1TextBox = new System.Windows.Forms.TextBox();
            Value2TextBox = new System.Windows.Forms.TextBox();
            Value3TextBox = new System.Windows.Forms.TextBox();
            OkButton = new System.Windows.Forms.Button();
            CancelButton = new System.Windows.Forms.Button();
            RandomButton = new System.Windows.Forms.Button();

            SuspendLayout();

            // Комбобокс для выбора типа фигуры
            ShapeTypeComboBox.Location = new System.Drawing.Point(20, 20);
            ShapeTypeComboBox.Size = new System.Drawing.Size(200, 23);
            ShapeTypeComboBox.SelectedIndexChanged += ShapeTypeComboBox_SelectedIndexChanged;

            // Поле ввода первого значения фигуры (радиус/сторона)
            Value1TextBox.Location = new System.Drawing.Point(20, 60);

            // Поле ввода второго значения фигуры (высота/сторона)
            Value2TextBox.Location = new System.Drawing.Point(20, 100);

            // Поле ввода третьего значения фигуры (сторона треугольника)
            Value3TextBox.Location = new System.Drawing.Point(20, 140);

            // Кнопка подтверждения добавления фигуры
            OkButton.Location = new System.Drawing.Point(20, 190);
            OkButton.Size = new System.Drawing.Size(75, 30);
            OkButton.Text = "Добавить";
            OkButton.Click += OkButton_Click;

            // Кнопка отмены добавления фигуры
            CancelButton.Location = new System.Drawing.Point(110, 190);
            CancelButton.Size = new System.Drawing.Size(90, 30);
            CancelButton.Text = "Отмена";
            CancelButton.Click += CancelButton_Click;

            // Кнопка генерации случайных значений фигуры
            RandomButton.Location = new System.Drawing.Point(220, 190);
            RandomButton.Size = new System.Drawing.Size(90, 30);
            RandomButton.Text = "Случайно";
            RandomButton.Click += RandomButton_Click;

            // Настройка формы
            ClientSize = new System.Drawing.Size(340, 250);
            Controls.Add(ShapeTypeComboBox);
            Controls.Add(Value1TextBox);
            Controls.Add(Value2TextBox);
            Controls.Add(Value3TextBox);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);
            Controls.Add(RandomButton);
            Text = "Добавление фигуры";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}