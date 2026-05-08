namespace PersonalLibraryManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            searchLable = new Label();
            searchTXT = new TextBox();
            SearchBTN = new Button();
            BookList_dataGridView = new DataGridView();
            ThietLapBTN = new Button();
            Search_GroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)BookList_dataGridView).BeginInit();
            Search_GroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // searchLable
            // 
            searchLable.AutoSize = true;
            searchLable.Location = new Point(2, 25);
            searchLable.Name = "searchLable";
            searchLable.Size = new Size(63, 15);
            searchLable.TabIndex = 0;
            searchLable.Text = "Tiềm kiếm";
            // 
            // searchTXT
            // 
            searchTXT.Location = new Point(104, 22);
            searchTXT.Name = "searchTXT";
            searchTXT.PlaceholderText = "Nhập tên tác phẩm hoặc tên tác giả";
            searchTXT.Size = new Size(432, 23);
            searchTXT.TabIndex = 1;
            // 
            // SearchBTN
            // 
            SearchBTN.BackColor = SystemColors.MenuHighlight;
            SearchBTN.BackgroundImageLayout = ImageLayout.Center;
            SearchBTN.Cursor = Cursors.No;
            SearchBTN.ForeColor = SystemColors.ButtonHighlight;
            SearchBTN.Location = new Point(557, 22);
            SearchBTN.Name = "SearchBTN";
            SearchBTN.Size = new Size(75, 23);
            SearchBTN.TabIndex = 2;
            SearchBTN.Text = "Tiềm kiếm";
            SearchBTN.TextImageRelation = TextImageRelation.TextBeforeImage;
            SearchBTN.UseVisualStyleBackColor = false;
            SearchBTN.Click += SearchBTN_Click;
            // 
            // BookList_dataGridView
            // 
            BookList_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BookList_dataGridView.Location = new Point(12, 115);
            BookList_dataGridView.Name = "BookList_dataGridView";
            BookList_dataGridView.Size = new Size(920, 323);
            BookList_dataGridView.TabIndex = 3;
            // 
            // ThietLapBTN
            // 
            ThietLapBTN.BackColor = SystemColors.MenuHighlight;
            ThietLapBTN.BackgroundImageLayout = ImageLayout.Center;
            ThietLapBTN.Cursor = Cursors.No;
            ThietLapBTN.ForeColor = SystemColors.ButtonHighlight;
            ThietLapBTN.Location = new Point(651, 22);
            ThietLapBTN.Name = "ThietLapBTN";
            ThietLapBTN.Size = new Size(75, 23);
            ThietLapBTN.TabIndex = 4;
            ThietLapBTN.Text = "Thiết lập lại";
            ThietLapBTN.TextImageRelation = TextImageRelation.TextBeforeImage;
            ThietLapBTN.UseVisualStyleBackColor = false;
            ThietLapBTN.Click += ThietLapBTN_Click;
            // 
            // Search_GroupBox
            // 
            Search_GroupBox.Controls.Add(ThietLapBTN);
            Search_GroupBox.Controls.Add(SearchBTN);
            Search_GroupBox.Controls.Add(searchTXT);
            Search_GroupBox.Controls.Add(searchLable);
            Search_GroupBox.Location = new Point(115, 31);
            Search_GroupBox.Name = "Search_GroupBox";
            Search_GroupBox.Size = new Size(729, 64);
            Search_GroupBox.TabIndex = 5;
            Search_GroupBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 450);
            Controls.Add(Search_GroupBox);
            Controls.Add(BookList_dataGridView);
            MinimumSize = new Size(790, 450);
            Name = "MainForm";
            Text = "Danh sách tác phẩm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)BookList_dataGridView).EndInit();
            Search_GroupBox.ResumeLayout(false);
            Search_GroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label searchLable;
        private TextBox searchTXT;
        private Button SearchBTN;
        private DataGridView BookList_dataGridView;
        private Button ThietLapBTN;
        private GroupBox Search_GroupBox;
    }
}
