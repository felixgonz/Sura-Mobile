using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AFPCapital.Movil.Controls
{
    public partial class ButtonBorder : ContentView
    {
        public event EventHandler Clicked;

        public ButtonBorder()
        {
            InitializeComponent();

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += async (s, e) => {
                if (Clicked != null)
                {
                    await this.ScaleTo(0.98);
                    //await Task.Delay(200);
                    await this.ScaleTo(1);
                    this.Clicked(s, e);
                }
            };

            this.frameContent.GestureRecognizers.Add(tgr);
            this.label.GestureRecognizers.Add(tgr);
        }

        public string Text
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }

        public Color Background
        {
            get
            {
                return frameContent.BackgroundColor;
            }
            set
            {
                frameContent.BackgroundColor = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return frameBorder.BackgroundColor;
            }
            set
            {
                frameBorder.BackgroundColor = value;
            }
        }

        public Color TextColor
        {
            get
            {
                return label.TextColor;
            }
            set
            {
                label.TextColor = value;
            }
        }

        public Font Font
        {
            get
            {
                return label.Font;
            }
            set
            {
                label.Font = value;
            }
        }

    }
}
