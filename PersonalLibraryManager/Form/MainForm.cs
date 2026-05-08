using PersonalLibraryManager.Models;

namespace PersonalLibraryManager
{
    public partial class MainForm : Form
    {
        private readonly LibraryContext _context;

        public MainForm(LibraryContext context)
        {
            InitializeComponent();
            _context = context;
            // Thiết lập Anchor = None (không neo cạnh nào)
            Search_GroupBox.Anchor = AnchorStyles.Top;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load dữ liệu ban đầu
            LoadDataWithEF();

            // Cấu hình DataGridView (nếu chưa setup sẵn)
            SetupDataGridView();

            SetupDataGridViewMargins();
        }

        private void LoadDataWithEF()
        {
            try
            {
                IQueryable<Book> query = _context.Books;

                // Lấy dữ liệu
                List<BookViewModel> books = query.Select(b => new BookViewModel
                {
                    Id = b.Id,  // Thêm Id nếu cần cho thao tác sau
                    TenSach = b.Title,
                    TacGia = b.Author,
                    NamPhatHanh = b.Year,
                    TheLoai = b.Genre,
                    ThoiGianDoc = b.ReadingTime
                })
                    .ToList();

                // Gán vào DataGridView
                BookList_dataGridView.DataSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataWithEF(string? searchText)
        {
            try
            {
                IQueryable<Book> query = _context.Books;

                // Nếu có từ khóa tìm kiếm
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query = query.Where(b => b.Title.Contains(searchText) ||
                                              b.Author.Contains(searchText));
                }

                // Lấy dữ liệu
                var books = query
                    .Select(b => new
                    {
                        b.Id,  // Thêm Id nếu cần cho thao tác sau
                        TenSach = b.Title,
                        TacGia = b.Author,
                        NamPhatHanh = b.Year,
                        TheLoai = b.Genre,
                        DanhGia = b.Review,
                        ThoiGianDoc = b.ReadingTime
                    })
                    .ToList();

                // Gán vào DataGridView
                BookList_dataGridView.DataSource = books;

                // Cập nhật thông báo
                MessageBox.Show($"Đã tìm thấy {books.Count} cuốn sách");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm phương thức tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = searchTXT.Text.Trim();
            LoadDataWithEF(searchText);
        }

        // Thêm phương thức refresh/làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchTXT.Clear();
            LoadDataWithEF(null);
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            // Tùy chỉnh giao diện
            BookList_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Chọn toàn bộ hàng khi click
            BookList_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Không cho phép chọn nhiều hàng
            BookList_dataGridView.MultiSelect = false;
            // Không cho phép chỉnh sửa trực tiếp
            BookList_dataGridView.ReadOnly = true;
            // Ẩn cột header
            BookList_dataGridView.RowHeadersVisible = false;

            // Định dạng cột ngày tháng
            if (BookList_dataGridView.Columns["ThoiGianDoc"] != null)
            {
                BookList_dataGridView.Columns["ThoiGianDoc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            // Ẩn cột Id nếu không muốn hiển thị
            //if (BookList_dataGridView.Columns["Id"] != null)
            //{
            //    BookList_dataGridView.Columns["Id"].Visible = false;
            //}
        }

        // Xem chi tiết sách khi double-click
        private void BookList_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy Id của sách được chọn
                int bookId = Convert.ToInt32(BookList_dataGridView.Rows[e.RowIndex].Cells["Id"].Value);

                // Mở form chi tiết (nếu có)
                // var detailForm = new BookDetailForm(bookId, _context);
                // detailForm.ShowDialog();

                // Hoặc hiển thị MessageBox tạm thời
                string bookTitle = BookList_dataGridView.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
                MessageBox.Show($"Bạn đã chọn: {bookTitle}", "Thông báo");
            }
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            LoadDataWithEF(searchTXT.Text.ToString());
        }

        private void ThietLapBTN_Click(object sender, EventArgs e)
        {

            LoadDataWithEF();
            searchTXT.Text = string.Empty;
        }

        private void SetupDataGridViewMargins()
        {
            // Thiết lập Anchor để kéo giãn theo 4 hướng
            BookList_dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                                            AnchorStyles.Left | AnchorStyles.Right;

            // Thiết lập Margin (khoảng cách với viền form)
            BookList_dataGridView.Margin = new Padding(40); // Cách đều 4 phía 20px
        }

        // Cập nhật khi form resize
        private void MainForm_Resize(object sender, EventArgs e)
        {
            BookList_dataGridView.Size = new Size(
                this.ClientSize.Width - 40,
                this.ClientSize.Height - 20
            );

            // Căn giữa hoàn toàn
            Search_GroupBox.Left = (this.ClientSize.Width - Search_GroupBox.Width) / 2;
            Search_GroupBox.Top = (this.ClientSize.Height - Search_GroupBox.Height) / 2;
        }
    }
}