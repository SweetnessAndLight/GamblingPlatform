using System;
using System.Windows;
using ExcelHelper;

namespace GamblingPlatform
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string FilePath = @"D:\Workspaces\GamblingPlatform\Data\大乐透历史数据.xlsx";
        ExcelReader eR = new ExcelReader();

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            DG_DLT.DataContext = eR.ReadExcelFile(FilePath);
        }



        private void Init_DLT()
        {
        }
    }
}
