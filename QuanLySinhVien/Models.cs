using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuanLySinhVien
{
    // ===================== SINH VIÊN (Bài 4.6) =====================
    // INotifyPropertyChanged: đổi 1 thuộc tính là DataGridView / các ô nhập tự cập nhật theo
    public class Student : INotifyPropertyChanged
    {
        private string studentId = "";
        private string fullName = "";
        private int age;
        private string gender = "";
        private string avatarPath = "";

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value ?? ""; OnPropertyChanged(); }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value ?? ""; OnPropertyChanged(); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value ?? ""; OnPropertyChanged(); }
        }

        public string AvatarPath
        {
            get { return avatarPath; }
            set { avatarPath = value ?? ""; OnPropertyChanged(); OnPropertyChanged(nameof(AvatarName)); }
        }

        // Chỉ để hiển thị tên file ảnh trên lưới
        public string AvatarName
        {
            get { return string.IsNullOrEmpty(avatarPath) ? "" : Path.GetFileName(avatarPath); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string ten = null)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(ten));
        }
    }

    // ===================== SẢN PHẨM (Form chức năng khác - Bài 4.7) =====================
    public class Product : INotifyPropertyChanged
    {
        private string productId = "";
        private string productName = "";
        private decimal price;
        private int quantity;

        public string ProductId
        {
            get { return productId; }
            set { productId = value ?? ""; OnPropertyChanged(); }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value ?? ""; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalValue)); }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalValue)); }
        }

        public decimal TotalValue
        {
            get { return price * quantity; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string ten = null)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(ten));
        }
    }
}
