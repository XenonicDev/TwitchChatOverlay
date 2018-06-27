﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace TwitchChatOverlay
{
    /// <summary>
    /// Interaction logic for Overlay.xaml
    /// </summary>
    public partial class Overlay : Window
    {
        public double ChatFontSize;
        public bool ChatBold;
        public Thickness OutlineThickness;

        public Overlay()
        {
            InitializeComponent();
        }

        public void AddMessage(string FormattedMessage, SolidColorBrush Brush, SolidColorBrush OutlineBrush)
        {
            int Index = (int)(Height * 0.3) / (int)ChatFontSize;

            if (ChatStack.Children.Count > Index)
            {
                ChatStack.Children.RemoveAt(0);
            }

            Border NewMessage = new Border();
            NewMessage.Child = new TextBlock();

            ChatStack.Children.Add(new Border
            {
                BorderBrush = OutlineBrush,
                BorderThickness = OutlineThickness,
                Child = new TextBlock
                {
                    Text = FormattedMessage,
                    FontSize = ChatFontSize,
                    Foreground = Brush,
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    FontWeight = ChatBold ? FontWeights.Bold : FontWeights.Regular,
                }
            });
        }

        private void Application_Exitting(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
