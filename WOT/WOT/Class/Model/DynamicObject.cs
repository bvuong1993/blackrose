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

namespace WOT.Class.Model {
    abstract class DynamicObject : ObjectGame {
        public float Direction;
        public bool outOfRange() { // check if the object is out of playing area
            if ( this.getPosition().X < 0) return true;
            else if ( (this.getPosition().X + this.getSize().Width) > MainPage.BattleField.ActualWidth) return true;
            else if (this.getPosition().Y < 0) return true;
            else if ( (this.getPosition().Y + this.getSize().Height) > MainPage.BattleField.ActualHeight) return true;
            else return false;

        }
        public void setDirection(float value) {
            Direction = value;
        }
        public float getDirection(){
            return Direction;
        }
        public DynamicObject(string url, TypeObject Type)
            : base(url, Type) {
            this.Direction = 0;
        }

        public virtual void RotateLeft(float value) {
            Direction -= value;
        }

        public virtual void RotateRight(float value) {
            Direction += value;
        }

        public virtual void MoveForward(float value) {
            double angle = Math.PI * this.Direction / 180;
            float x = this.getPosition().X;
            float y = this.getPosition().Y;
            x += (float)Math.Sin(angle) * value;
            y-= (float)Math.Cos(angle) * value;
            this.setPosition(new Position(x,y));

        }

        public virtual void MoveBackward(float value) {
            double angle = Math.PI * this.Direction / 180;
            float x = this.getPosition().X;
            float y = this.getPosition().Y;
            x -= (float)Math.Sin(angle) * value;
            y += (float)Math.Cos(angle) * value;
            this.setPosition(new Position(x, y));
        }
    }
}
