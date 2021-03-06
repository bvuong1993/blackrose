﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WOT.Resources;
using WOT.Class.Components;
using System.Windows.Media.Imaging;
using WOT;



namespace WOT.Class.Model {
     abstract class ObjectGame : PhoneApplicationPage {
        public Image Image;
        public TypeObject Type;

        public ObjectGame( string source, TypeObject Type) {
            this.Image = new Image();
            Uri url = new Uri(source,UriKind.Relative);
            BitmapImage bmp = new BitmapImage(url);
            this.Image.Source = bmp;
            Image.Width = 0;
            Image.Height = 0;
            Image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Image.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Image.Visibility = System.Windows.Visibility.Visible;
            
            this.Image.Margin = new Thickness(-10, -10, -10, -10);
            this.Type = Type;
        }
        public void setSize(Size size) {
            Image.Height = size.Height;
            Image.Width = size.Width;
        }
        public Size getSize() {
            return (new Size(Image.ActualWidth, Image.ActualHeight));
        }

        public void setPosition(Position position) {
            Image.Margin = new Thickness(position.X, position.Y, 0, 0);
        }
        public Position getPosition() {
            return (new Position((float)Image.Margin.Left,(float) Image.Margin.Top));
        }

        public bool IsCollided(ObjectGame obj) {
            double this_x1 = this.getPosition().X;
            double this_x2 = this_x1 + this.getSize().Width;
            double this_y1 = this.getPosition().Y;
            double this_y2 = this_y1 + this.getSize().Height;

            double obj_x1 = obj.getPosition().X;
            double obj_x2 = obj_x1 + obj.getSize().Width;
            double obj_y1 = obj.getPosition().Y;
            double obj_y2 = obj_y1 + obj.getSize().Height;

            if (((this_x1 <= obj_x1 && obj_x1 < this_x2) || (obj_x1 <= this_x1 && this_x1 < obj_x2)) &&
                ((this_y1 <= obj_y1 && obj_y1 < this_y2) || (obj_y1 <= this_y1 && this_y1 < obj_y2)))
                return true;
            return false;
        }
    }
}
