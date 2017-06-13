using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AFPCapital.Movil.Controls
{
    public partial class FrameBorder : ContentView
    {
        public FrameBorder()
        {
            InitializeComponent();
        }

        public string Title
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

        public View Content
        {
            get
            {
                if (stackLayoutContent.Children == null || stackLayoutContent.Children.Count == 0)
                {
                    stackLayoutContent.Children.Add(new StackLayout());
                }
                return stackLayoutContent.Children[0];
            }
            set
            {
                stackLayoutContent.Children.Clear();
                stackLayoutContent.Children.Add(value);
            }
        }
    }
}
