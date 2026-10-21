using System.Globalization;

namespace QuanLySinhVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Định dạng số kiểu Việt Nam: 1.500.000
            CultureInfo vi = new CultureInfo("vi-VN");
            CultureInfo.DefaultThreadCurrentCulture = vi;
            Thread.CurrentThread.CurrentCulture = vi;

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}
