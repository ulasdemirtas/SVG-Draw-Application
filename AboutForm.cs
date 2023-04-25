using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVGDrawer
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            string aboutText = "SVG Drawer Application v1.0\n\n" +
    "This application allows users to create and edit SVG images using various drawing tools.\n\n " +
    "Users can save and load their projects in SVG formatand also review on web browser\n\n" +
    "Copyright © 2023 Ulas Demirtas. All rights reserved.\n\n" +
    "For more information, visit our website or contact the support team.";

            label1.Text = aboutText;
        }
    }
}
