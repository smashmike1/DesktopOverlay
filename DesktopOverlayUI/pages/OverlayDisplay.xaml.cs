﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Windows.UI.WindowManagement;
using WinRT;
using Wpf.Ui.Controls;
using static System.Net.Mime.MediaTypeNames;
using Image = Wpf.Ui.Controls.Image;
using TextBlock = Wpf.Ui.Controls.TextBlock;

namespace DesktopOverlayUI.pages
{
    /// <summary>
    /// Interaction logic for OverlayDisplay.xaml
    /// </summary>
    public partial class OverlayDisplay
    {

        public Point OriginPoint { get; set; }



        public TextBlock OverlayTextBlock= new TextBlock
        {
            Text = "",
            FontSize = 24,
            Foreground = Brushes.Black,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            IsHitTestVisible = false,
            Visibility = Visibility.Collapsed
        };

        public Image OverlayImage = new Image
        {
            Source = null,
            Width = 100,
            Height = 100,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            IsHitTestVisible = false,
            Visibility = Visibility.Collapsed,
            HorizontalContentAlignment = HorizontalAlignment.Stretch,
            VerticalContentAlignment = VerticalAlignment.Stretch,
            Stretch = Stretch.Fill,
            
        };

        public string OverlayText {
            get => OverlayTextBlock.Text;
            set => OverlayTextBlock.Text = value;
        }

        public ImageSource? OverlayImageSource
        {
            get => OverlayImage.Source;
            set => OverlayImage.Source = value;
        }

        

        public OverlayDisplay(string overlayType, ImageSource? image, string? str)
        {
            InitializeComponent();

            OriginPoint = new Point(Left,Top);
            OverlayText = str;
            Content.As<Grid>().Children.Add(OverlayTextBlock);
            OverlayImageSource = image;
            Content.As<Grid>().Children.Add(OverlayImage);

            foreach (UIElement item in Content.As<Grid>().Children)
            {
                item.IsHitTestVisible = false;
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
        }


        public void SetText(string text)
        {
            OverlayText = text;
            OverlayTextBlock.Text = OverlayText;
            OverlayTextBlock.Visibility = Visibility.Visible;
        }

        public void SetImage(ImageSource image)
        {
            var imageControl = new Wpf.Ui.Controls.Image()
            {
                Source = image,
                Width = 100,
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                IsHitTestVisible = false
            };
            OverlayTextBlock.Visibility = Visibility.Collapsed;
            Content.As<Grid>().Children.Add(imageControl);
        }


    }

    public static class WindowsServices
    {
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
    }
}
