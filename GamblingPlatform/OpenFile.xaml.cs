using System;
using System.Windows;
using System.Windows.Forms;

namespace GamblingPlatform
{
    /// <summary>
    /// OpenFile.xaml 的交互逻辑
    /// </summary>
    public partial class OpenFile : Window
    {
        public OpenFile()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filePath = new OpenFileDialog(); //定义一个文件打开空间
            //filePath.InitialDirectory = Application.StartupPath;//设置打开目录，.exe文件所在目录
            filePath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            filePath.Filter = "所有文件|（*.*）|Excel文件|*.xls;*.xlsx";
            filePath.RestoreDirectory = true;
            filePath.FilterIndex = 1;
            if (filePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_FilePath.Text = filePath.FileName.ToString();

            }
        }
    }
}
