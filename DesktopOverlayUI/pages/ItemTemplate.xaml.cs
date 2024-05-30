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
    public OverlayDisplay Overlay;
    private ImagesTab? imagesTab;
    private ImageStyleTab? imageStyleTab;
    private TextTab? textTab;
    private TextStyleTab? textStyleTab;
    private LocationTab locationTab;

    private OverlayDriver _overlayDriver;


    public ItemTemplate(string itemType)
    {
        InitializeComponent();

        //TextMenuButton.Content = "Text";



        Overlay = new OverlayDisplay("Image", null, null);
        _overlayDriver = new OverlayDriver(Overlay);


        switch (itemType)
        {
            case "Image":
            {
                imagesTab = new ImagesTab(Overlay,_overlayDriver);
                var imageMenuButton = new NavigationItem(MenuPanel, this, imagesTab, "General");
                MenuPanel.Children.Add(imageMenuButton);
                imageStyleTab = new ImageStyleTab(Overlay,_overlayDriver);
                var imageStyleMenuButton = new NavigationItem(MenuPanel, this, imageStyleTab, "Style");
                MenuPanel.Children.Add(imageStyleMenuButton);
                imageMenuButton.SetSelected(true);
                break;
            }
            case "Text":
            {
                textTab = new TextTab(Overlay);
                textStyleTab = new TextStyleTab(Overlay);
                var textMenuButton = new NavigationItem(MenuPanel, this, textTab, "General");
                MenuPanel.Children.Add(textMenuButton);
                textMenuButton.SetSelected(true);
                var textStyleMenuButton = new NavigationItem(MenuPanel, this, textStyleTab, "Style");
                MenuPanel.Children.Add(textStyleMenuButton);
                break;
            }
        }
        locationTab = new LocationTab(Overlay);
        var locationMenuButton = new NavigationItem(MenuPanel, this, locationTab, "Location");
        MenuPanel.Children.Add(locationMenuButton);

        //DirectXTest.Graphics.CreateImage(new Uri("C:\\Users\\Michael\\Source\\Repos\\smashmike1\\DesktopOverlay\\DesktopOverlayUI\\pages\\f13ca1208198058a.png").LocalPath);


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