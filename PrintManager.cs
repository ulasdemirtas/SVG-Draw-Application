using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Svg;
using Svg.Transforms;

namespace SVGDrawer
{
    public class PrintManager
    {
        private PrintDocument _printDocument;
        private SvgDocument _svgDocument;

        public PrintManager(SvgDocument svgDocument)
        {
            _svgDocument = svgDocument;
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Display;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float scaleFactor = e.PageSettings.PrinterSettings.DefaultPageSettings.Landscape ?
                e.PageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Height / _svgDocument.Height :
                e.PageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Width / _svgDocument.Width;

            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            _svgDocument.Draw(e.Graphics);
        }

        public void Print()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = _printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.Print();
            }
        }

        public void PrintPreview()
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = _printDocument;
            printPreviewDialog.ShowDialog();
        }
    }
}
