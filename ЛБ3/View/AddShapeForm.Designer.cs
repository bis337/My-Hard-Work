namespace View
{
    /// <summary>
    /// Дизайнер формы добавления фигуры.
    /// </summary>
    partial class AddShapeForm
    {
        /// <summary>
        /// Контейнер компонентов формы.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Выпадающий список выбора типа фигуры.
        /// </summary>
        private System.Windows.Forms.ComboBox ShapeTypeComboBox;

        /// <summary>
        /// Подпись первого значения.
        /// </summary>
        private System.Windows.Forms.Label Value1Label;

        /// <summary>
        /// Подпись второго значения.
        /// </summary>
        private System.Windows.Forms.Label Value2Label;

        /// <summary>
        /// Подпись третьего значения.
        /// </summary>
        private System.Windows.Forms.Label Value3Label;

        /// <summary>
        /// Поле ввода первого значения фигуры.
        /// </summary>
        private System.Windows.Forms.TextBox Value1TextBox;

        /// <summary>
        /// Поле ввода второго значения фигуры.
        /// </summary>
        private System.Windows.Forms.TextBox Value2TextBox;

        /// <summary>
        /// Поле ввода третьего значения фигуры.
        /// </summary>
        private System.Windows.Forms.TextBox Value3TextBox;

        /// <summary>
        /// Кнопка подтверждения добавления фигуры.
        /// </summary>
        private System.Windows.Forms.Button OkButton;

        /// <summary>
        /// Кнопка отмены добавления фигуры.
        /// </summary>
        private System.Windows.Forms.Button CancelButton;

#if DEBUG
        //TODO: if endif +
        /// <summary>
        /// Кнопка генерации случайных значений.
        /// </summary>
        private System.Windows.Forms.Button RandomButton;
#endif

        /// <summary>
        /// Освобождает ресурсы.
        /// </summary>
        /// <param name="disposing">
        /// Указывает, нужно ли освобождать управляемые ресурсы.
        /// </param>
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
            Value1Label = new System.Windows.Forms.Label();
            Value2Label = new System.Windows.Forms.Label();
            Value3Label = new System.Windows.Forms.Label();
            Value1TextBox = new System.Windows.Forms.TextBox();
            Value2TextBox = new System.Windows.Forms.TextBox();
            Value3TextBox = new System.Windows.Forms.TextBox();
            OkButton = new System.Windows.Forms.Button();
            CancelButton = new System.Windows.Forms.Button();

#if DEBUG
            //TODO: if endif +
            RandomButton = new System.Windows.Forms.Button();
#endif

            SuspendLayout();

            ShapeTypeComboBox.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            ShapeTypeComboBox.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            ShapeTypeComboBox.Location = new System.Drawing.Point(20, 20);
            ShapeTypeComboBox.Size = new System.Drawing.Size(300, 23);
            ShapeTypeComboBox.SelectedIndexChanged
                += ShapeTypeComboBox_SelectedIndexChanged;

            Value1Label.Location = new System.Drawing.Point(20, 60);
            Value1Label.Size = new System.Drawing.Size(100, 23);
            Value1Label.Text = "Значение 1:";

            Value1TextBox.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            Value1TextBox.Location = new System.Drawing.Point(130, 60);
            Value1TextBox.Size = new System.Drawing.Size(190, 23);

            Value2Label.Location = new System.Drawing.Point(20, 100);
            Value2Label.Size = new System.Drawing.Size(100, 23);
            Value2Label.Text = "Значение 2:";

            Value2TextBox.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            Value2TextBox.Location = new System.Drawing.Point(130, 100);
            Value2TextBox.Size = new System.Drawing.Size(190, 23);

            Value3Label.Location = new System.Drawing.Point(20, 140);
            Value3Label.Size = new System.Drawing.Size(100, 23);
            Value3Label.Text = "Значение 3:";

            Value3TextBox.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            Value3TextBox.Location = new System.Drawing.Point(130, 140);
            Value3TextBox.Size = new System.Drawing.Size(190, 23);

            OkButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            OkButton.Location = new System.Drawing.Point(20, 190);
            OkButton.Size = new System.Drawing.Size(75, 30);
            OkButton.Text = "Добавить";
            OkButton.Click += OkButton_Click;

            CancelButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            CancelButton.Location = new System.Drawing.Point(110, 190);
            CancelButton.Size = new System.Drawing.Size(90, 30);
            CancelButton.Text = "Отмена";
            CancelButton.Click += CancelButton_Click;

#if DEBUG
            //TODO: if endif +
            RandomButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            RandomButton.Location = new System.Drawing.Point(220, 190);
            RandomButton.Size = new System.Drawing.Size(90, 30);
            RandomButton.Text = "Случайно";
            RandomButton.Click += RandomButton_Click;
#endif

            ClientSize = new System.Drawing.Size(340, 250);
            MinimumSize = new System.Drawing.Size(340, 250);

            Controls.Add(ShapeTypeComboBox);
            Controls.Add(Value1Label);
            Controls.Add(Value2Label);
            Controls.Add(Value3Label);
            Controls.Add(Value1TextBox);
            Controls.Add(Value2TextBox);
            Controls.Add(Value3TextBox);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);

#if DEBUG
            //TODO: if endif +
            Controls.Add(RandomButton);
#endif

            Text = "Добавление фигуры";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}