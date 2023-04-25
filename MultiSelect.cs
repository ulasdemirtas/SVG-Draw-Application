using Svg;

namespace SVGDrawer
{
    public class MultiSelect
    {
        public List<SvgElement> SelectedElements { get; private set; }

        public MultiSelect()
        {
            SelectedElements = new List<SvgElement>();
        }

        public void Add(SvgElement element)
        {
            SelectedElements.Add(element);
        }

        public void Remove(SvgElement element)
        {
            SelectedElements.Remove(element);
        }

        public void Clear()
        {
            SelectedElements.Clear();
        }

        public bool Contains(SvgElement element)
        {
            return SelectedElements.Contains(element);
        }
    }
}
