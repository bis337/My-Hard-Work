namespace View
{
    /// <summary>
    /// Дизайнер главной формы приложения.
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// Контейнер компонентов формы.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Таблица отображения фигур.
        /// </summary>
        private System.Windows.Forms.DataGridView ShapesGridView;

        /// <summary>
        /// Кнопка добавления фигуры.
        /// </summary>
        private System.Windows.Forms.Button AddButton;

        /// <summary>
        /// Кнопка удаления фигуры.
        /// </summary>
        private System.Windows.Forms.Button RemoveButton;

        /// <summary>
        /// Кнопка сохранения фигур.
        /// </summary>
        private System.Windows.Forms.Button SaveButton;

        /// <summary>
        /// Кнопка загрузки фигур.
        /// </summary>
        private System.Windows.Forms.Button LoadButton;

        /// <summary>
        /// Кнопка поиска фигур.
        /// </summary>
        private System.Windows.Forms.Button SearchButton;

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
        /// Инициализация элементов главной формы.
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

            // 
            // ShapesGridView
            // 
            ShapesGridView.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            ShapesGridView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ShapesGridView.Location = new System.Drawing.Point(12, 12);
            ShapesGridView.Name = "ShapesGridView";
            ShapesGridView.RowTemplate.Height = 25;
            ShapesGridView.Size = new System.Drawing.Size(760, 350);
            ShapesGridView.KeyDown += ShapesGridView_KeyDown;

            // 
            // AddButton
            // 
            AddButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            AddButton.Location = new System.Drawing.Point(12, 380);
            AddButton.Size = new System.Drawing.Size(100, 40);
            AddButton.Text = "Добавить";
            AddButton.Click += AddButton_Click;

            // 
            // RemoveButton
            // 
            RemoveButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            RemoveButton.Location = new System.Drawing.Point(130, 380);
            RemoveButton.Size = new System.Drawing.Size(100, 40);
            RemoveButton.Text = "Удалить";
            RemoveButton.Click += RemoveButton_Click;

            // 
            // SaveButton
            // 
            SaveButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            SaveButton.Location = new System.Drawing.Point(250, 380);
            SaveButton.Size = new System.Drawing.Size(100, 40);
            SaveButton.Text = "Сохранить";
            SaveButton.Click += SaveButton_Click;

            // 
            // LoadButton
            // 
            LoadButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            LoadButton.Location = new System.Drawing.Point(370, 380);
            LoadButton.Size = new System.Drawing.Size(100, 40);
            LoadButton.Text = "Загрузить";
            LoadButton.Click += LoadButton_Click;

            // 
            // SearchButton
            // 
            SearchButton.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            SearchButton.Location = new System.Drawing.Point(490, 380);
            SearchButton.Size = new System.Drawing.Size(100, 40);
            SearchButton.Text = "Поиск";
            SearchButton.Click += SearchButton_Click;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 450);
            MinimumSize = new System.Drawing.Size(650, 350);

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