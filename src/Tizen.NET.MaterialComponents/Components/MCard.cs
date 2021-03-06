﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MCard : Box
    {
        Layout _layout;
        bool _hasShadow;
        Color _borderColor;

        public new IEnumerable<EvasObject> Children => base.Children.ToList<EvasObject>();

        public bool HasShadow
        {
            get
            {
                return _hasShadow;
            }
            set
            {
                _hasShadow = value;
                if (_hasShadow)
                {
                    _layout.SignalEmit(Action.ShowShadow, "");
                }
                else
                {
                    _layout.SignalEmit(Action.HideShadow, "");
                }
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                if (_borderColor == Color.Default)
                {
                    _layout.SetPartColor(PartName.Border, Color.Transparent);
                }
                else
                {
                    _layout.SetPartColor(PartName.Border, _borderColor);
                }
            }
        }

        public MCard(EvasObject parent) : base(parent)
        {
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            var handle =  base.CreateHandle(parent);
            _layout = new Layout(parent);

            if (RealHandle == IntPtr.Zero)
            {
                RealHandle = handle;
            }
            Handle = handle;

            _layout.SetTheme("layout", "frame", Styles.Material);
            _layout.SetPartContent(PartName.Content, this);
            _layout.SignalEmit(Action.ShowShadow, "");

            return _layout;
        }
    }
}
