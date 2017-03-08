using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mhanxx.src
{
    public partial class TreeView : System.Windows.Forms.TreeView
    {
        public TreeView()
        {
            InitializeComponent();
        }

        public TreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
