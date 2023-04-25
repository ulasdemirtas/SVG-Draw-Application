using System.Drawing;

public class GridRuler
{
    
    public int GridSize { get; set; }

    public GridRuler(int gridSize)
    {
        GridSize = gridSize;
    }

    public void DrawGrid(Graphics g, int width, int height)
    {
        // Draw the horizontal grid lines
        for (int y = GridSize; y < height; y += GridSize)
        {
            g.DrawLine(Pens.LightGray, 0, y, width, y);
        }

        // Draw the vertical grid lines
        for (int x = GridSize; x < width; x += GridSize)
        {
            g.DrawLine(Pens.LightGray, x, 0, x, height);
        }
    }

    public float AlignToGrid(float value)
    {
        return GridSize * (float)Math.Round(value / GridSize);
    }
}
