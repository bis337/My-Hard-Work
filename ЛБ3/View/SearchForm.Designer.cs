namespace View
{
    /// <summary>
    /// Дизайнер формы поиска фигур.
    /// </summary>
    partial class SearchForm
    {
        /// <summary>
        /// Контейнер компонентов формы.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Поле ввода текста поиска.
        /// </summary>
        private System.Windows.Forms.TextBox SearchTextBox;

        /// <summary>
        /// Кнопка поиска.
        /// </summary>
        private System.Windows.Forms.Button SearchButton;

        /// <summary>
        /// Таблица результатов поиска.
        /// </summary>
        private System.Windows.Forms.DataGridView ResultsGridView;

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
            SearchTextBox = new System.Windows.Forms.TextBox();
            SearchButton = new System.Windows.Forms.Button();
            ResultsGridView = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (ResultsGridView)).BeginInit();
            SuspendLayout();

            SearchTextBox.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            SearchTextBox.Location = new System.Drawing.Point(20, 20);
            SearchTextBox.Size = new System.Drawing.Size(320, 23);

            SearchButton.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            SearchButton.Location = new System.Drawing.Point(360, 20);
            SearchButton.Size = new System.Drawing.Size(90, 25);
            SearchButton.Text = "Найти";
            SearchButton.Click += SearchButton_Click;

            ResultsGridView.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            ResultsGridView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsGridView.Location = new System.Drawing.Point(20, 60);
            ResultsGridView.Name = "ResultsGridView";
            ResultsGridView.RowTemplate.Height = 25;
            ResultsGridView.Size = new System.Drawing.Size(430, 250);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(470, 330);
            MinimumSize = new System.Drawing.Size(470, 330);

            Controls.Add(SearchTextBox);
            Controls.Add(SearchButton);
            Controls.Add(ResultsGridView);

            Text = "Поиск фигур";

            ((System.ComponentModel.ISupportInitialize)
                (ResultsGridView)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}