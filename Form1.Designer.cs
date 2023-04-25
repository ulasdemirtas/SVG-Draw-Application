namespace SVGDrawer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            openInBrowserToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            rectangletoolStripMenuItem1 = new ToolStripMenuItem();
            ellipsetoolStripMenuItem2 = new ToolStripMenuItem();
            linetoolStripMenuItem3 = new ToolStripMenuItem();
            textToolStripMenuItem = new ToolStripMenuItem();
            freeDrawToolStripMenuItem = new ToolStripMenuItem();
            transformToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            rotateToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pictureBox = new PictureBox();
            statusLabel = new StatusStrip();
            colorDialog1 = new ColorDialog();
            nudStrokeWidth = new NumericUpDown();
            label1 = new Label();
            btnStrokeColor = new Button();
            btnFillColor = new Button();
            chkTransparentFill = new CheckBox();
            lineToolStripMenuItem = new ToolStripMenuItem();
            txtContent = new TextBox();
            label3 = new Label();
            fontDialog1 = new FontDialog();
            btnFont = new Button();
            zoomTrackBar = new HScrollBar();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStrokeWidth).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1066, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, printToolStripMenuItem, printPreviewToolStripMenuItem, toolStripSeparator2, openInBrowserToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(201, 26);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(201, 26);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(198, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(201, 26);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(201, 26);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(198, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(201, 26);
            printToolStripMenuItem.Text = "&Print";
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new Size(201, 26);
            printPreviewToolStripMenuItem.Text = "Print Pre&view";
            printPreviewToolStripMenuItem.Click += printPreviewToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(198, 6);
            // 
            // openInBrowserToolStripMenuItem
            // 
            openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            openInBrowserToolStripMenuItem.Size = new Size(201, 26);
            openInBrowserToolStripMenuItem.Text = "Open in Browser";
            openInBrowserToolStripMenuItem.Click += openInBrowserToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(201, 26);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, deleteToolStripMenuItem, zoomToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(179, 26);
            undoToolStripMenuItem.Text = "&Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(179, 26);
            redoToolStripMenuItem.Text = "&Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(176, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(179, 26);
            cutToolStripMenuItem.Text = "Cu&t";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(179, 26);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(179, 26);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(176, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(179, 26);
            deleteToolStripMenuItem.Text = "&Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(179, 26);
            zoomToolStripMenuItem.Text = "Zoom";
            zoomToolStripMenuItem.Click += zoomToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectToolStripMenuItem, rectangletoolStripMenuItem1, ellipsetoolStripMenuItem2, linetoolStripMenuItem3, textToolStripMenuItem, freeDrawToolStripMenuItem, transformToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.Size = new Size(160, 26);
            selectToolStripMenuItem.Text = "Select";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // rectangletoolStripMenuItem1
            // 
            rectangletoolStripMenuItem1.Name = "rectangletoolStripMenuItem1";
            rectangletoolStripMenuItem1.Size = new Size(160, 26);
            rectangletoolStripMenuItem1.Text = "Rectangle";
            rectangletoolStripMenuItem1.Click += rectangletoolStripMenuItem1_Click;
            // 
            // ellipsetoolStripMenuItem2
            // 
            ellipsetoolStripMenuItem2.Name = "ellipsetoolStripMenuItem2";
            ellipsetoolStripMenuItem2.Size = new Size(160, 26);
            ellipsetoolStripMenuItem2.Text = "Ellipse";
            ellipsetoolStripMenuItem2.Click += ellipsetoolStripMenuItem2_Click;
            // 
            // linetoolStripMenuItem3
            // 
            linetoolStripMenuItem3.Name = "linetoolStripMenuItem3";
            linetoolStripMenuItem3.Size = new Size(160, 26);
            linetoolStripMenuItem3.Text = "Line";
            linetoolStripMenuItem3.Click += LinetoolStripMenuItem3_Click;
            // 
            // textToolStripMenuItem
            // 
            textToolStripMenuItem.Name = "textToolStripMenuItem";
            textToolStripMenuItem.Size = new Size(160, 26);
            textToolStripMenuItem.Text = "Text";
            textToolStripMenuItem.Click += textToolStripMenuItem_Click;
            // 
            // freeDrawToolStripMenuItem
            // 
            freeDrawToolStripMenuItem.Name = "freeDrawToolStripMenuItem";
            freeDrawToolStripMenuItem.Size = new Size(160, 26);
            freeDrawToolStripMenuItem.Text = "Free Hand";
            freeDrawToolStripMenuItem.Click += freeDrawToolStripMenuItem_Click;
            // 
            // transformToolStripMenuItem
            // 
            transformToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, rotateToolStripMenuItem });
            transformToolStripMenuItem.Name = "transformToolStripMenuItem";
            transformToolStripMenuItem.Size = new Size(160, 26);
            transformToolStripMenuItem.Text = "Transform";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(136, 26);
            toolStripMenuItem1.Text = "Scale";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // rotateToolStripMenuItem
            // 
            rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            rotateToolStripMenuItem.Size = new Size(136, 26);
            rotateToolStripMenuItem.Text = "Rotate";
            rotateToolStripMenuItem.Click += rotateToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new Size(224, 26);
            contentsToolStripMenuItem.Text = "&View Help";
            contentsToolStripMenuItem.Click += contentsToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(221, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(224, 26);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(26, 127);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1008, 572);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // statusLabel
            // 
            statusLabel.ImageScalingSize = new Size(20, 20);
            statusLabel.Location = new Point(0, 727);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1066, 22);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "statusLabel";
            // 
            // nudStrokeWidth
            // 
            nudStrokeWidth.Location = new Point(26, 85);
            nudStrokeWidth.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudStrokeWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStrokeWidth.Name = "nudStrokeWidth";
            nudStrokeWidth.Size = new Size(59, 27);
            nudStrokeWidth.TabIndex = 3;
            nudStrokeWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudStrokeWidth.ValueChanged += nudStrokeWidth_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 54);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 4;
            label1.Text = "Stroke";
            // 
            // btnStrokeColor
            // 
            btnStrokeColor.Location = new Point(88, 50);
            btnStrokeColor.Name = "btnStrokeColor";
            btnStrokeColor.Size = new Size(87, 29);
            btnStrokeColor.TabIndex = 5;
            btnStrokeColor.Text = "Color";
            btnStrokeColor.UseVisualStyleBackColor = true;
            btnStrokeColor.Click += btnStrokeColor_Click;
            // 
            // btnFillColor
            // 
            btnFillColor.Location = new Point(88, 83);
            btnFillColor.Name = "btnFillColor";
            btnFillColor.Size = new Size(87, 31);
            btnFillColor.TabIndex = 6;
            btnFillColor.Text = "Fill Color";
            btnFillColor.UseVisualStyleBackColor = true;
            btnFillColor.Click += btnFillColor_Click;
            // 
            // chkTransparentFill
            // 
            chkTransparentFill.AutoSize = true;
            chkTransparentFill.Location = new Point(181, 90);
            chkTransparentFill.Name = "chkTransparentFill";
            chkTransparentFill.Size = new Size(75, 24);
            chkTransparentFill.TabIndex = 7;
            chkTransparentFill.Text = "Set Fill";
            chkTransparentFill.UseVisualStyleBackColor = true;
            chkTransparentFill.CheckedChanged += chkTransparentFill_CheckedChanged;
            // 
            // lineToolStripMenuItem
            // 
            lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            lineToolStripMenuItem.Size = new Size(32, 19);
            // 
            // txtContent
            // 
            txtContent.Location = new Point(285, 68);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(175, 46);
            txtContent.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 45);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 11;
            label3.Text = "Enter Your Text";
            // 
            // btnFont
            // 
            btnFont.Location = new Point(482, 82);
            btnFont.Name = "btnFont";
            btnFont.Size = new Size(75, 33);
            btnFont.TabIndex = 0;
            btnFont.Text = "Fonts";
            btnFont.Click += btnFont_Click;
            // 
            // zoomTrackBar
            // 
            zoomTrackBar.Cursor = Cursors.Hand;
            zoomTrackBar.Dock = DockStyle.Bottom;
            zoomTrackBar.Location = new Point(0, 701);
            zoomTrackBar.Maximum = 500;
            zoomTrackBar.Minimum = 10;
            zoomTrackBar.Name = "zoomTrackBar";
            zoomTrackBar.Size = new Size(1066, 26);
            zoomTrackBar.TabIndex = 12;
            zoomTrackBar.Tag = "";
            zoomTrackBar.Value = 100;
            zoomTrackBar.Scroll += hScrollBar1_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1066, 749);
            Controls.Add(zoomTrackBar);
            Controls.Add(btnFont);
            Controls.Add(label3);
            Controls.Add(txtContent);
            Controls.Add(chkTransparentFill);
            Controls.Add(btnFillColor);
            Controls.Add(btnStrokeColor);
            Controls.Add(label1);
            Controls.Add(nudStrokeWidth);
            Controls.Add(statusLabel);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "SVG Drawer v1.0";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStrokeWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem rectangletoolStripMenuItem1;
        private ToolStripMenuItem ellipsetoolStripMenuItem2;
        private ToolStripMenuItem linetoolStripMenuItem3;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private PictureBox pictureBox;
        private ToolStripMenuItem selectToolStripMenuItem;
        private StatusStrip statusLabel;
        private ColorDialog colorDialog1;
        private NumericUpDown nudStrokeWidth;
        private Label label1;
        private Button btnStrokeColor;
        private Button btnFillColor;
        private CheckBox chkTransparentFill;
        private ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private TextBox txtContent;
        private Label label3;
        private FontDialog fontDialog1;
        private Button btnFont;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem freeDrawToolStripMenuItem;
        private ToolStripMenuItem transformToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem rotateToolStripMenuItem;
        private ToolStripMenuItem openInBrowserToolStripMenuItem;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private HScrollBar zoomTrackBar;
    }
}