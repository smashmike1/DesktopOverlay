﻿using DesktopOverlayUI.pages.overlayMenu;
using System;
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
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace DesktopOverlayUI.pages
{
    /// <summary>
    /// Interaction logic for template.xaml
    /// </summary>
    public partial class ItemTemplate : Page
    {
        public ItemTemplate()
        {
            InitializeComponent();
        }

        public ItemTemplate(string itemType)
        {
            InitializeComponent();
            if (itemType.Equals("Image"))
            {
                ImageTab.Visibility = Visibility.Visible;
            } else if (itemType.Equals("Text"))
            {
                TextTab.Visibility = Visibility.Visible;
                TextStyleTab textStyleTab = new TextStyleTab();
                StyleTab.TargetPageType = typeof(TextStyleTab);
            }


        }

        
    }
}