using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Input;
using System.Windows.Forms;
using System.Security.Policy;
using OfficeOpenXml;
using System.Data;

namespace JinanDeadLineTool
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel Files(*.xlsx;*.xlsb;*.xls)|*.xlsx;*.xlsb;*.xls";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;
                    ReadExcel(openFileDialog.FileName);
                }
            }

            Console.ReadLine();
            return;
            Console.WriteLine("ctrl + c 关闭");
            HackTool hack = new HackTool();
            hack.Start();
            Console.ReadLine();
        }


        static async void ReadExcel(string path)
        {
            FileInfo fi = new FileInfo(path);
            using(ExcelPackage pack = new ExcelPackage(fi))
            {
                await pack.LoadAsync(fi);
                var ws = pack.Workbook.Worksheets[0];
                int rows = ws.Dimension.End.Row;
                int cols = ws.Dimension.End.Column;
                Console.WriteLine($"{rows}-{cols}");
                for (int i = 1; i <= rows; i++)
                {
                    string str = "";
                    for (int j = 1; j <= cols; j++)
                    {
                        str += $"{ws.Cells[i,j].Value}";
                        if (j < cols)
                        {
                            str += ",";
                        }
                    }
                    Console.WriteLine(str);
                }
            }
        }
    }


    public class HackTool
    {
        string deadlinePath = "";

        public void Start()
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {
                var path = dilog.SelectedPath;
                deadlinePath = Path.Combine(path, @"VisualizationSystemOfJinan_Data\StreamingAssets\Config\deadline.jm");
                ModeifyDate();
            }
        }


        private void ModeifyDate()
        {
            if (!File.Exists(deadlinePath))
            {
                Start();
            }
            else
            {
                string jm = File.ReadAllText(deadlinePath, Encoding.UTF8);
                var date = Utils.DateEncrypted.DeCryptDate(jm);
                Console.WriteLine("截止日期:{0}", date);
                Update();
            }
        }

        private void Update()
        {
            while (true)
            {
                Console.WriteLine("输入0修改，输入1退出");
                var input = Console.ReadLine();
                if (input == "0")
                {
                    DateTime date = DateTime.MinValue;
                    while (!GetDateInput(out date))
                    {
                        Console.WriteLine("输入错误");
                    }
                    Console.WriteLine("录入成功，是否写入。0 确定 1 取消");
                    var a = Console.ReadLine();
                    if (a == "0")
                    {
                        var mw = Utils.DateEncrypted.EncryptDate(date);
                        File.WriteAllText(deadlinePath, mw, Encoding.UTF8);
                        Console.WriteLine("写入成功");
                    }
                }
                else if (input == "1")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("输入错误");
                }
            }
        }


        private bool GetDateInput(out DateTime date)
        {
            date = DateTime.MinValue;
            Console.WriteLine("请输入截止日期 , 例如：2020-02-15");
            string input = Console.ReadLine();
            if (input.Length == 10 && DateTime.TryParse(input, out date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    
}
