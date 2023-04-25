using Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGDrawer
{
    public class FileManager
    {
        private SvgElement _clipboardElement;
        private SvgDocument _currentSvg;
        private Action UpdatePictureBox;
        public FileManager()
        {
        }

        public FileManager(SvgDocument currentSvg, Action updatePictureBox)
        {
            _currentSvg = currentSvg;
            UpdatePictureBox = updatePictureBox;
        }

        public SvgDocument OpenSvg(string filename)
        {
            return SvgDocument.Open(filename);
        }

        public void SaveSvg(string filename, SvgDocument currentSvg)
        {
            currentSvg.Write(filename);
        }

        public void CutSelectedElement(MultiSelect multiSelect)
        {
            if (multiSelect.SelectedElements.Count > 0)
            {
                _clipboardElement = multiSelect.SelectedElements[0].Clone() as SvgElement;
                _currentSvg.Children.Remove(multiSelect.SelectedElements[0]);
                multiSelect.Clear();
                UpdatePictureBox();
            }
        }

        public void CopySelectedElement(MultiSelect multiSelect)
        {
            if (multiSelect.SelectedElements.Count > 0)
            {
                _clipboardElement = multiSelect.SelectedElements[0].Clone() as SvgElement;
            }
        }
        public void PasteElement()
        {
            if (_clipboardElement != null)
            {
                SvgElement pastedElement = _clipboardElement.Clone() as SvgElement;
                pastedElement.ID = "pasted_" + Guid.NewGuid().ToString();
                _currentSvg.Children.Add(pastedElement);
                UpdatePictureBox();
            }
        }

        public void DeleteSelectedElements(MultiSelect multiSelect)
        {
            foreach (SvgElement element in multiSelect.SelectedElements)
            {
                _currentSvg.Children.Remove(element);
            }
            multiSelect.Clear();
            UpdatePictureBox();
        }
    }
}
