namespace View
{
    /// <summary>
    /// Дизайнер главной формы приложения.
    /// </summary>
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView ShapesGridView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SearchButton;

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
            ShapesGridView = new System.Windows.Forms.DataGridView();
            AddButton = new System.Windows.Forms.Button();
            RemoveButton = new System.Windows.Forms.Button();
            SaveButton = new System.Windows.Forms.Button();
            LoadButton = new System.Windows.Forms.Button();
            SearchButton = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)
                (ShapesGridView)).BeginInit();
            SuspendLayout();

            // Таблица для отображения фигур
            ShapesGridView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ShapesGridView.Location = new System.Drawing.Point(12, 12);
            ShapesGridView.Name = "ShapesGridView";
            ShapesGridView.RowTemplate.Height = 25;
            ShapesGridView.Size = new System.Drawing.Size(760, 350);

            // Кнопка добавления фигуры
            AddButton.Location = new System.Drawing.Point(12, 380);
            AddButton.Size = new System.Drawing.Size(100, 40);
            AddButton.Text = "Добавить";
            AddButton.Click += AddButton_Click;

            // Кнопка удаления фигуры
            RemoveButton.Location = new System.Drawing.Point(130, 380);
            RemoveButton.Size = new System.Drawing.Size(100, 40);
            RemoveButton.Text = "Удалить";
            RemoveButton.Click += RemoveButton_Click;

            // Кнопка сохранения фигур в файл
            SaveButton.Location = new System.Drawing.Point(250, 380);
            SaveButton.Size = new System.Drawing.Size(100, 40);
            SaveButton.Text = "Сохранить";
            SaveButton.Click += SaveButton_Click;

            // Кнопка загрузки фигур из файла
            LoadButton.Location = new System.Drawing.Point(370, 380);
            LoadButton.Size = new System.Drawing.Size(100, 40);
            LoadButton.Text = "Загрузить";
            LoadButton.Click += LoadButton_Click;

            // Кнопка поиска фигур
            SearchButton.Location = new System.Drawing.Point(490, 380);
            SearchButton.Size = new System.Drawing.Size(100, 40);
            SearchButton.Text = "Поиск";
            SearchButton.Click += SearchButton_Click;

            // Настройки формы
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 450);

            Controls.Add(ShapesGridView);
            Controls.Add(AddButton);
            Controls.Add(RemoveButton);
            Controls.Add(SaveButton);
            Controls.Add(LoadButton);
            Controls.Add(SearchButton);

            Name = "MainForm";
            Text = "Фигуры";

            ((System.ComponentModel.ISupportInitialize)
                (ShapesGridView)).EndInit();
            ResumeLayout(false);
        }
    }
}