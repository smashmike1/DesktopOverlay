﻿using DesktopOverlayUI.pages.overlayMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using WinRT;
using Wpf.Ui;
using Wpf.Ui.Animations;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;
using GameOverlay.Drawing;
using GameOverlay.Windows;
using Image = GameOverlay.Drawing.Image;
using NavigationService = Wpf.Ui.NavigationService;

namespace DesktopOverlayUI.pages;

/// <summary>
/// Interaction logic for template.xaml
/// </summary>
public partial class ItemTemplate : Page
{
    public readonly BaseDisplay Base;


    public ItemTemplate(string itemType)
    {
        InitializeComponent();

        //TextMenuButton.Content = "Text";


        Base = new BaseDisplay();
        var overlayDriver = new OverlayDriver(Base);


        switch (itemType)
        {
            case "Image":
            {
                var imagesTab = new ImagesTab(Base, overlayDriver);
                var imageMenuButton = new NavigationItem(MenuPanel, this, imagesTab, "General");
                MenuPanel.Children.Add(imageMenuButton);
                var imageStyleTab = new ImageStyleTab(Base, overlayDriver);
                var imageStyleMenuButton = new NavigationItem(MenuPanel, this, imageStyleTab, "Style");
                MenuPanel.Children.Add(imageStyleMenuButton);
                imageMenuButton.SetSelected(true);
                break;
            }
            case "Text":
            {
                var textTab = new TextTab(Base, overlayDriver);
                var textStyleTab = new TextStyleTab(Base, overlayDriver);
                var textMenuButton = new NavigationItem(MenuPanel, this, textTab, "General");
                MenuPanel.Children.Add(textMenuButton);
                textMenuButton.SetSelected(true);
                var textStyleMenuButton = new NavigationItem(MenuPanel, this, textStyleTab, "Style");
                MenuPanel.Children.Add(textStyleMenuButton);
                break;
            }
        }

        var locationTab = new LocationTab(Base, overlayDriver);
        var locationMenuButton = new NavigationItem(MenuPanel, this, locationTab, "Location");
        MenuPanel.Children.Add(locationMenuButton);
    }


    public void SetView(Uri uri)
    {
        ApplyTransition();
        FrameDisplay.Navigate(uri);
    }

    public void SetView(Page page)
    {
        ApplyTransition();
        FrameDisplay.Navigate(page);
    }

    public void ApplyTransition()
    {
        TransitionAnimationProvider.ApplyTransition(FrameDisplay, Transition.FadeInWithSlide, 200);
    }
}