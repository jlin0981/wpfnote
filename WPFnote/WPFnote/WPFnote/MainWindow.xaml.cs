﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFnote
{

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>

    public partial class MainWindow : Window
    {
        // 分辨 BTN
        string fileName = " ";
        string newFileName = " ";
        string nowText = " ";
        string savedText = " ";

        public MainWindow()
        {
            InitializeComponent();
        }
        // 儲存 (選擇檔案位置)
        void Save()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                System.IO.File.WriteAllText(dlg.FileName, Textarea.Text);
                fileName = dlg.FileName;
                savedText = nowText; ;
                Title.Text = dlg.SafeFileName + ".txt";
            }
        }

        // 打開 (選擇檔案位置)
        void Open()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                Textarea.Text = System.IO.File.ReadAllText(dlg.FileName);
                fileName = dlg.FileName;
                savedText = Textarea.Text;
                Title.Text = dlg.SafeFileName + ".txt";
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileName == newFileName)
            {
                Save();
            }
            else
            {
                System.IO.File.WriteAllText(fileName, Textarea.Text);
                savedText = nowText;
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    Open();
                }
                else
                {
                    Open();
                }
            else
            {
                Open();
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
            {
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    Textarea.Text = "";
                }
                else
                {
                    Textarea.Text = "";
                }
            }
            else
            {
                Textarea.Text = "";
            }
        }

        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        //改變字體大小

        private void ChangeSmall_Click(object sender, RoutedEventArgs e)
        {
            Textarea.FontSize = Textarea.FontSize - 5;
        }

        private void ChangeNormal_Click(object sender, RoutedEventArgs e)
        {
            Textarea.FontSize = 20;
        }

        private void ChangeBig_Click(object sender, RoutedEventArgs e)
        {
            Textarea.FontSize = Textarea.FontSize + 5;
        }

        //改變顏色

        private void ChangeGray_Click(object sender, RoutedEventArgs e)
        {
            Textarea.Background = Brushes.DarkGray;
            Textarea.Foreground = Brushes.White;
            Title.Background = Brushes.Gray;
            Title.Foreground = Brushes.White;
            CloseBtn.Background = Brushes.Gray;
            CloseBtn.Foreground = Brushes.White;
            CloseBtn.BorderBrush = Brushes.Gray;
            MaxBtn.Background = Brushes.Gray;
            MaxBtn.Foreground = Brushes.White;
            MaxBtn.BorderBrush = Brushes.Gray;
            MinBtn.Background = Brushes.Gray;
            MinBtn.Foreground = Brushes.White;
            MinBtn.BorderBrush = Brushes.Gray;
            TitleBar.Background = Brushes.Gray;
        }

        private void ChangeWhite_Click(object sender, RoutedEventArgs e)
        {
            Textarea.Background = Brushes.White;
            Textarea.Foreground = Brushes.Gray;
            Title.Background = Brushes.White;
            Title.Foreground = Brushes.Gray;
            MaxBtn.Background = Brushes.White;
            MaxBtn.Foreground = Brushes.Gray;
            MaxBtn.BorderBrush = Brushes.White;
            MinBtn.Background = Brushes.White;
            MinBtn.Foreground = Brushes.Gray;
            MinBtn.BorderBrush = Brushes.White;
            CloseBtn.Background = Brushes.White;
            CloseBtn.Foreground = Brushes.Gray;
            CloseBtn.BorderBrush = Brushes.White;
            TitleBar.Background = Brushes.White;
        }

        private void Textarea_TextChanged(object sender, TextChangedEventArgs e)
        {
            nowText = Textarea.Text;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
            {
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        // 縮小

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; // 視窗還原
            }
            else
            {
                this.WindowState = WindowState.Maximized; // 視窗最大化
            }
        }
    }
}

