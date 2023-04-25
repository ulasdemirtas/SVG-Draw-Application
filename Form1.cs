using Svg;
using Svg.Pathing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace SVGDrawer
{
    public partial class Form1 : Form
    {
        private SvgDocument _currentSvg;
        private SvgElement _selectedElement;
        private SvgElement _currentElement;
        private PointF _startPoint;
        private string _currentMode = "Select";
        private Color _fillColor = Color.Transparent;
        private Color _strokeColor = Color.Black;
        private float _strokeWidth = 1f;
        private List<SvgDocument> _undoList = new List<SvgDocument>();
        private List<SvgDocument> _redoList = new List<SvgDocument>();
        private SvgElement _clipboardElement;
        private bool _draggingElement = false;
        private Font _font = new Font("Arial", 12);
        private MultiSelect _multiSelect;
        private SvgDocument _svgDoc;
        private SvgPath _currentPath;
        private FileManager _fileManager;
        private Transformation _transformation;
        private SvgPath _drawingPath;
        private GridRuler _gridRuler;
        private PictureBox _gridPictureBox;
        private float cumulativeDx = 0;
        private float cumulativeDy = 0;
        private SvgZoom _svgZoom = new SvgZoom();
        private bool _zoomEnabled = false;

        public Form1()
        {
            InitializeComponent();
            _gridRuler = new GridRuler(20);
            InitializeSvgDocument();
            NewSvg();
            UpdateStatusStrip();
            _multiSelect = new MultiSelect();
            _fileManager = new FileManager();
            _transformation = new Transformation();
            _fileManager = new FileManager(_currentSvg, UpdatePictureBox);

            this.Load += (sender, e) =>
            {
                UpdatePictureBox();
            };
            this.MouseWheel += Form1_MouseWheel;
            pictureBox.Focus();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    _svgZoom.ZoomIn();
                }
                else
                {
                    _svgZoom.ZoomOut();
                }
                SetZoomLevel(_svgZoom.ZoomLevel);
            }
        }
        private void SetZoomLevel(float zoomLevel)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.ClientSize = new Size((int)(_currentSvg.Width * zoomLevel), (int)(_currentSvg.Height * zoomLevel));
            pictureBox.Invalidate();
        }


        private void UpdateGrid()
        {
            // Create a new image with the grid drawn on it
            Bitmap imageWithGrid = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(imageWithGrid))
            {
                _gridRuler.DrawGrid(g, this.ClientSize.Width, this.ClientSize.Height);
            }

            // Set the picture box's image to the new image
            _gridPictureBox.Image = imageWithGrid;
        }
        private void InitializeSvgDocument()
        {
            _svgDoc = new SvgDocument();
            _drawingPath = new SvgPath();
        }



        private void NewSvg()
        {
            _currentSvg = new SvgDocument
            {
                Width = new SvgUnit(SvgUnitType.Pixel, pictureBox.Width),
                Height = new SvgUnit(SvgUnitType.Pixel, pictureBox.Height)
            };
            _selectedElement = null;
            UpdatePictureBox();
        }
        private void UpdatePictureBox()
        {
            pictureBox.Image?.Dispose();

            Bitmap imageWithGrid = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(imageWithGrid))
            {
                _gridRuler.DrawGrid(g, pictureBox.Width, pictureBox.Height);
                g.DrawImage(_currentSvg.Draw(), 0, 0, pictureBox.Width, pictureBox.Height);
            }

            pictureBox.Image = imageWithGrid;
        }


        private void UpdateStatusStrip()
        {
            statusLabel.Text = $"Current mode: {_currentMode}";
        }

        private SvgElement CreateSvgElement(string type)
        {
            SvgElement element = type switch
            {
                "Rectangle" => new SvgRectangle
                {
                    Fill = new SvgColourServer(chkTransparentFill.Checked ? _fillColor : Color.Transparent),
                    Stroke = new SvgColourServer(_strokeColor),
                    StrokeWidth = _strokeWidth
                },
                "Ellipse" => new SvgEllipse
                {
                    Fill = new SvgColourServer(chkTransparentFill.Checked ? _fillColor : Color.Transparent),
                    Stroke = new SvgColourServer(_strokeColor),
                    StrokeWidth = _strokeWidth
                },
                "Line" => new SvgLine
                {
                    StartX = _startPoint.X,
                    StartY = _startPoint.Y,
                    Stroke = new SvgColourServer(_strokeColor),
                    StrokeWidth = _strokeWidth
                },
                "Text" => new SvgText
                {
                    Text = txtContent.Text,
                    FontSize = new SvgUnit(SvgUnitType.Point, _font.SizeInPoints),
                    FontFamily = _font.FontFamily.Name,
                    Fill = new SvgColourServer(_strokeColor),
                    X = new SvgUnitCollection() { _startPoint.X },
                    Y = new SvgUnitCollection() { _startPoint.Y }
                },
                "Freehand" => new SvgPath
                {
                    Stroke = new SvgColourServer(_strokeColor),
                    StrokeWidth = _strokeWidth,
                    PathData = new SvgPathSegmentList()
                },

                _ => throw new ArgumentException("Invalid element type")
            };

            return element;
        }
        private PointF GetSvgCoordinates(PointF screenCoordinates)
        {
            var scaleX = _currentSvg.Width.Value / pictureBox.Width;
            var scaleY = _currentSvg.Height.Value / pictureBox.Height;
            return new PointF(screenCoordinates.X * scaleX, screenCoordinates.Y * scaleY);
        }
        private void SelectElementAt(PointF point, bool multiSelect = false)
        {
            SvgElement clickedElement = null;

            foreach (SvgElement element in _currentSvg.Children)
            {
                if (IsPointInsideElement(point, element))
                {
                    clickedElement = element;
                    break;
                }
            }

            if (clickedElement != null)
            {
                if (multiSelect)
                {
                    if (_multiSelect.Contains(clickedElement))
                    {
                        _multiSelect.Remove(clickedElement);
                        (clickedElement as dynamic).Stroke = new SvgColourServer(Color.Black);
                    }
                    else
                    {
                        _multiSelect.Add(clickedElement);
                        (clickedElement as dynamic).Stroke = new SvgColourServer(Color.Red);
                    }
                }
                else
                {
                    _multiSelect.Clear();
                    _multiSelect.Add(clickedElement);
                    (clickedElement as dynamic).Stroke = new SvgColourServer(Color.Red);
                }
            }
            else if (!multiSelect)
            {
                _multiSelect.Clear();
            }

            UpdatePictureBox();
        }
        private bool IsPointInsideElement(PointF point, SvgElement element)
        {
            if (element is SvgRectangle rect)
            {
                return point.X >= rect.X && point.X <= rect.X + rect.Width &&
                       point.Y >= rect.Y && point.Y <= rect.Y + rect.Height;
            }
            else if (element is SvgEllipse ellipse)
            {
                float dx = point.X - ellipse.CenterX;
                float dy = point.Y - ellipse.CenterY;
                return (dx * dx) / (ellipse.RadiusX * ellipse.RadiusX) + (dy * dy) / (ellipse.RadiusY * ellipse.RadiusY) <= 1;
            }

            else if (element is SvgText text)
            {
                float fontSize = text.FontSize.Value;
                float width = text.Text.Length * fontSize / 2;
                float height = fontSize;
                return point.X >= text.X[0] && point.X <= text.X[0] + width &&
                       point.Y >= text.Y[0] - height && point.Y <= text.Y[0];
            }
            return false;
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentMode.StartsWith("Draw"))
            {
                string shapeType = _currentMode.Substring(5);


                if (shapeType == "Text")
                {
                    PointF currentPoint = GetSvgCoordinates(e.Location);
                    SvgText newTextElement = new SvgText
                    {
                        Text = txtContent.Text,
                        FontSize = new SvgUnit(SvgUnitType.Point, _font.SizeInPoints),
                        FontFamily = _font.FontFamily.Name,
                        Fill = new SvgColourServer(_strokeColor),
                        X = new SvgUnitCollection() { currentPoint.X },
                        Y = new SvgUnitCollection() { currentPoint.Y }
                    };

                    _currentSvg.Children.Add(newTextElement);
                    UpdatePictureBox();
                }
                else
                {
                    SaveState();
                    _currentElement = CreateSvgElement(shapeType);
                    _startPoint = GetSvgCoordinates(e.Location);
                    _currentSvg.Children.Add(_currentElement);
                    if (_currentElement is SvgLine line)
                    {
                        line.StartX = _startPoint.X;
                        line.StartY = _startPoint.Y;
                        line.EndX = _startPoint.X;
                        line.EndY = _startPoint.Y;
                    }
                }
            }
            else if (_currentMode == "Select")
            {
                bool multiSelect = (ModifierKeys & Keys.Control) == Keys.Control;
                SelectElementAt(GetSvgCoordinates(e.Location), multiSelect);
                if (_multiSelect.SelectedElements.Count > 0)
                {
                    _draggingElement = true;
                    _startPoint = GetSvgCoordinates(e.Location);
                    cumulativeDx = 0;
                    cumulativeDy = 0;
                }
            }

            if (e.Button == MouseButtons.Left && _currentMode == "Draw Freehand")
            {
                SaveState();
                _drawingPath = new SvgPath
                {
                    Stroke = new SvgColourServer(_strokeColor),
                    StrokeWidth = _strokeWidth,
                    PathData = new SvgPathSegmentList()
                };
                PointF startPoint = GetSvgCoordinates(e.Location);
                _drawingPath.PathData.Add(new SvgMoveToSegment(startPoint));
                _currentSvg.Children.Add(_drawingPath);
                _startPoint = startPoint;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _currentElement = null;
            _draggingElement = false;

            if (_selectedElement != null && _currentMode == "Select" && _multiSelect.SelectedElements.Count == 0)
            {
                PointF currentPoint = GetSvgCoordinates(e.Location);
                float dx = currentPoint.X - _startPoint.X;
                float dy = currentPoint.Y - _startPoint.Y;

                MoveElement(_selectedElement, dx, dy, true);

                _startPoint = currentPoint;
                UpdatePictureBox();
            }
            else if (_multiSelect.SelectedElements.Count > 0 && _draggingElement && _currentMode == "Select")
            {
                PointF currentPoint = GetSvgCoordinates(e.Location);
                float dx = currentPoint.X - _startPoint.X;
                float dy = currentPoint.Y - _startPoint.Y;

                foreach (SvgElement selectedElement in _multiSelect.SelectedElements)
                {
                    MoveElement(selectedElement, dx, dy, true);
                }

                _startPoint = currentPoint;
                UpdatePictureBox();
            }

            if (e.Button == MouseButtons.Left && _currentMode == "Draw Freehand")
            {
                _drawingPath = null;
                UpdatePictureBox();
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentMode == "Select" && _selectedElement != null && e.Button == MouseButtons.Left)
            {
                if (_selectedElement is SvgVisualElement visualElement)
                {
                    float newWidth = e.X - visualElement.Bounds.X;
                    float newHeight = e.Y - visualElement.Bounds.Y;

                    _transformation.ResizeElement(visualElement, newWidth, newHeight);

                    UpdatePictureBox();
                }
            }
            else
            {
                if (_currentElement != null)
                {
                    PointF currentPoint = GetSvgCoordinates(e.Location);

                    if (_currentElement is SvgRectangle rect)
                    {
                        rect.X = Math.Min(_startPoint.X, currentPoint.X);
                        rect.Y = Math.Min(_startPoint.Y, currentPoint.Y);
                        rect.Width = Math.Abs(_startPoint.X - currentPoint.X);
                        rect.Height = Math.Abs(_startPoint.Y - currentPoint.Y);
                    }
                    else if (_currentElement is SvgEllipse ellipse)
                    {
                        float centerX = (_startPoint.X + currentPoint.X) / 2;
                        float centerY = (_startPoint.Y + currentPoint.Y) / 2;
                        ellipse.CenterX = centerX;
                        ellipse.CenterY = centerY;
                        ellipse.RadiusX = Math.Abs((_startPoint.X - currentPoint.X) / 2);
                        ellipse.RadiusY = Math.Abs((_startPoint.Y - currentPoint.Y) / 2);
                    }
                    else if (_currentElement is SvgLine line)
                    {
                        line.EndX = currentPoint.X;
                        line.EndY = currentPoint.Y;
                    }
                    UpdatePictureBox();
                }
                else if (_selectedElement != null && _draggingElement && _currentMode == "Select" && _multiSelect.SelectedElements.Count == 0)
                {
                    PointF currentPoint = GetSvgCoordinates(e.Location);
                    float dx = currentPoint.X - _startPoint.X;
                    float dy = currentPoint.Y - _startPoint.Y;

                    MoveElement(_selectedElement, dx, dy, false);

                    _startPoint = currentPoint;
                    UpdatePictureBox();
                }
                else if (_multiSelect.SelectedElements.Count > 0 && _draggingElement && _currentMode == "Select")
                {
                    PointF currentPoint = GetSvgCoordinates(e.Location);
                    float dx = currentPoint.X - _startPoint.X;
                    float dy = currentPoint.Y - _startPoint.Y;

                    foreach (SvgElement selectedElement in _multiSelect.SelectedElements)
                    {
                        MoveElement(selectedElement, dx, dy, false);
                    }

                    _startPoint = currentPoint;
                    UpdatePictureBox();
                }
                if (e.Button == MouseButtons.Left && _currentMode == "Draw Freehand" && _currentElement != null)
                {
                    SvgPath drawingPath = _currentElement as SvgPath;
                    PointF currentPoint = GetSvgCoordinates(e.Location);
                    SvgMoveToSegment startPointSegment = new SvgMoveToSegment(_startPoint);
                    SvgLineSegment lineSegment = new SvgLineSegment(_startPoint, currentPoint);

                    drawingPath.PathData.Add(startPointSegment);
                    drawingPath.PathData.Add(lineSegment);

                    _startPoint = currentPoint;
                    UpdatePictureBox();
                }
            }
        }


        private void MoveElement(SvgElement element, float dx, float dy, bool applyAlignment)
        {
            if (applyAlignment)
            {
                dx = _gridRuler.AlignToGrid(cumulativeDx);
                dy = _gridRuler.AlignToGrid(cumulativeDy);
                cumulativeDx = 0;
                cumulativeDy = 0;
            }
            else
            {
                cumulativeDx += dx;
                cumulativeDy += dy;
            }

            if (element is SvgRectangle rect)
            {
                rect.X += dx;
                rect.Y += dy;
            }
            else if (element is SvgEllipse ellipse)
            {
                ellipse.CenterX += dx;
                ellipse.CenterY += dy;
            }
            else if (element is SvgText text)
            {
                text.X = new SvgUnitCollection() { text.X[0] + dx };
                text.Y = new SvgUnitCollection() { text.Y[0] + dy };
            }
        }


        private void btnFillColor_Click(object sender, EventArgs e)
        {
            if (!chkTransparentFill.Checked)
            {
                using (var fillColorDialog = new ColorDialog())
                {
                    if (fillColorDialog.ShowDialog() == DialogResult.OK)
                    {
                        _fillColor = fillColorDialog.Color;
                    }
                }
            }
            else
            {
                _fillColor = Color.Transparent;
            }

            if (_selectedElement != null)
            {
                if (_selectedElement is SvgRectangle rect)
                {
                    rect.Fill = new SvgColourServer(_fillColor);
                }
                else if (_selectedElement is SvgEllipse ellipse)
                {
                    ellipse.Fill = new SvgColourServer(_fillColor);
                }
                UpdatePictureBox();
            }
        }
        private void btnStrokeColor_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _strokeColor = colorDialog.Color;
                    if (_selectedElement != null)
                    {
                        if (_selectedElement is SvgRectangle rect)
                        {
                            rect.Stroke = new SvgColourServer(_strokeColor);
                        }
                        else if (_selectedElement is SvgEllipse ellipse)
                        {
                            ellipse.Stroke = new SvgColourServer(_strokeColor);
                        }
                        UpdatePictureBox();
                    }
                }
            }
        }
        private void nudStrokeWidth_ValueChanged(object sender, EventArgs e)
        {
            _strokeWidth = (float)nudStrokeWidth.Value;
            if (_selectedElement != null)
            {
                if (_selectedElement is SvgRectangle rect)
                {
                    rect.StrokeWidth = _strokeWidth;
                }
                else if (_selectedElement is SvgEllipse ellipse)
                {
                    ellipse.StrokeWidth = _strokeWidth;
                }
                UpdatePictureBox();
            }
        }
        private void btnStrokeColor_Click_1(object sender, EventArgs e)
        {

        }
        private void chkTransparentFill_CheckedChanged(object sender, EventArgs e)
        { }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_multiSelect.SelectedElements.Count > 0)
            {
                _fileManager.CutSelectedElement(_multiSelect);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_multiSelect.SelectedElements.Count > 0)
            {
                _fileManager.CopySelectedElement(_multiSelect);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileManager.PasteElement();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fileManager.DeleteSelectedElements(_multiSelect);
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = _font;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _font = fontDialog.Font;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        { }
        // Undo and redo functionality

        private void Undo()
        {
            if (_undoList.Count > 0)
            {
                _redoList.Add(_currentSvg);
                _currentSvg = _undoList[_undoList.Count - 1];
                _undoList.RemoveAt(_undoList.Count - 1);
                UpdatePictureBox();
            }
        }
        private void Redo()
        {
            if (_redoList.Count > 0)
            {
                _undoList.Add(_currentSvg);
                _currentSvg = _redoList[_redoList.Count - 1];
                _redoList.RemoveAt(_redoList.Count - 1);
                UpdatePictureBox();
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSvg();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SVG files (*.svg)|*.svg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentSvg = _fileManager.OpenSvg(openFileDialog.FileName);
                    UpdatePictureBox();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SVG files (*.svg)|*.svg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileManager.SaveSvg(saveFileDialog.FileName, _currentSvg);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rectangletoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetCurrentMode("Draw Rectangle");
        }

        private void ellipsetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetCurrentMode("Draw Ellipse");
        }

        private void LinetoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SetCurrentMode("Draw Line");
        }
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentMode("Draw Text");
        }
        private void freeDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentMode("Draw Freehand");
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentMode("Select");
        }
        private void SaveState()
        {
            SvgDocument newState = SvgDocument.FromSvg<SvgDocument>(_currentSvg.GetXML());
            _undoList.Add(newState);
            ClearRedoList();
        }
        private void ClearRedoList()
        {
            _redoList.Clear();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }


        private void SetCurrentMode(string mode)
        {
            _currentMode = mode;
            UpdateStatusStrip();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_multiSelect.SelectedElements.Count == 1)
            {
                SvgVisualElement selectedElement = _multiSelect.SelectedElements[0] as SvgVisualElement;
                if (selectedElement != null)
                {
                    float scaleFactor = 1.1f; // Scale up by 10%
                    _transformation.ScaleElement(selectedElement, scaleFactor, scaleFactor);
                    UpdatePictureBox();
                }
            }
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_multiSelect.SelectedElements.Count == 1)
            {
                SvgVisualElement selectedElement = _multiSelect.SelectedElements[0] as SvgVisualElement;
                if (selectedElement != null)
                {
                    float rotationAngle = 15; // Rotate 15 degrees clockwise
                    _transformation.RotateElement(selectedElement, rotationAngle);
                    UpdatePictureBox();
                }
            }
        }



        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSvg != null)
            {
                PrintManager printManager = new PrintManager(_currentSvg);
                printManager.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSvg != null)
            {
                PrintManager printManager = new PrintManager(_currentSvg);
                printManager.PrintPreview();
            }
        }

        private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInBrowser();
        }

        private void OpenInBrowser()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SVG Files (*.svg)|*.svg|All Files (*.*)|*.*";
            openFileDialog.Title = "Select an SVG file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
                startInfo.UseShellExecute = true;
                startInfo.Verb = "open";
                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message);
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (_zoomEnabled)
            {
                SetZoomLevel(zoomTrackBar.Value / 100.0f);
            }
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _zoomEnabled = !_zoomEnabled;
            zoomToolStripMenuItem.Text = _zoomEnabled ? "Zoom Off" : "Zoom On";
            zoomTrackBar.Enabled = _zoomEnabled;

            if (!_zoomEnabled)
            {
                SetZoomLevel(1.0f);
            }
            else
            {
                SetZoomLevel(zoomTrackBar.Value / 100.0f);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpText;

            // Read the help_contents.txt file
            using (StreamReader reader = new StreamReader("help_contents.txt"))
            {
                helpText = reader.ReadToEnd();
            }

            HelpContent helpContent = new HelpContent();
            helpContent.textBox1.Text = helpText; // Set the text of the textBox1 control
            helpContent.ShowDialog();
        }
    }
}