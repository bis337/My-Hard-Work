namespace View
{
    /// <summary>
    /// Дизайнер формы поиска фигур.
    /// </summary>
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox ResultsListBox;

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
            SearchTextBox = new System.Windows.Forms.TextBox();
            SearchButton = new System.Windows.Forms.Button();
            ResultsListBox = new System.Windows.Forms.ListBox();

            SuspendLayout();

            // Поле для ввода текста поиска
            SearchTextBox.Location = new System.Drawing.Point(20, 20);
            SearchTextBox.Size = new System.Drawing.Size(200, 23);

            // Кнопка поиска
            SearchButton.Location = new System.Drawing.Point(240, 20);
            SearchButton.Size = new System.Drawing.Size(90, 25);
            SearchButton.Text = "Найти";
            SearchButton.Click += SearchButton_Click;

            // Список результатов поиска
            ResultsListBox.Location = new System.Drawing.Point(20, 60);
            ResultsListBox.Size = new System.Drawing.Size(310, 180);

            // Настройка формы
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(360, 270);

            Controls.Add(SearchTextBox);
            Controls.Add(SearchButton);
            Controls.Add(ResultsListBox);

            Text = "Поиск фигур";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}