using Svg.Transforms;
using Svg;

public class Transformation
{
    public void RotateElement(SvgElement element, float angle)
    {
        if (element is SvgVisualElement visualElement)
        {
            if (visualElement.Transforms == null)
            {
                visualElement.Transforms = new SvgTransformCollection();
            }

            float centerX = visualElement.Bounds.X + visualElement.Bounds.Width / 2;
            float centerY = visualElement.Bounds.Y + visualElement.Bounds.Height / 2;
            visualElement.Transforms.Add(new SvgRotate(angle, centerX, centerY));
        }
    }

    public void ScaleElement(SvgElement element, float scaleX, float scaleY)
    {
        if (element is SvgVisualElement visualElement)
        {
            if (visualElement.Transforms == null)
            {
                visualElement.Transforms = new SvgTransformCollection();
            }

            float centerX = visualElement.Bounds.X + visualElement.Bounds.Width / 2;
            float centerY = visualElement.Bounds.Y + visualElement.Bounds.Height / 2;

            // Apply a translation to center the element on the origin
            visualElement.Transforms.Add(new SvgTranslate(-centerX, -centerY));

            // Scale the element
            visualElement.Transforms.Add(new SvgScale(scaleX, scaleY));

            // Apply a translation to move the element back to its original position
            visualElement.Transforms.Add(new SvgTranslate(centerX, centerY));
        }
    }


    public void TranslateElement(SvgElement element, float dx, float dy)
    {
        if (element is SvgVisualElement visualElement)
        {
            if (visualElement.Transforms == null)
            {
                visualElement.Transforms = new SvgTransformCollection();
            }

            visualElement.Transforms.Add(new SvgTranslate(dx, dy));
        }
    }
    public void ResizeElement(SvgVisualElement element, float newWidth, float newHeight)
    {
        if (element is SvgRectangle rect)
        {
            rect.Width = newWidth;
            rect.Height = newHeight;
        }
        else if (element is SvgEllipse ellipse)
        {
            ellipse.RadiusX = newWidth / 2;
            ellipse.RadiusY = newHeight / 2;
        }
        
    }
}
