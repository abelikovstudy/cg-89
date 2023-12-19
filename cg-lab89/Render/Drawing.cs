using cg_lab89.MathUtils;
using cg_lab89.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace cg_lab89.Render
{

    public class Drawing
    {
        public static byte bytify(double color)
        {
            return (byte)Math.Round(255 * color);
        }

        public static float frac(double f)
        {
            return (float)(f - Math.Truncate(f));
        }

        public static void DrawLine(PointF _p0, PointF _p1, Color color, ref FastBitmap fb)
        {

            Point p0 = new Point((int)_p0.X, (int)_p0.Y);
            Point p1 = new Point((int)_p1.X, (int)_p1.Y);

            float x0 = p0.X, x1 = p1.X, y0 = p0.Y, y1 = p1.Y;
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                (x0, y0) = (y0, x0);
                (x1, y1) = (y1, x1);
            }
            if (x0 > x1)
            {
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }
            fb.SetPixel(p1, color);


            float dx = x1 - x0, dy = y1 - y0;
            float gradient = dy / dx;
            if (dx == 0)
            {
                gradient = 1;
            }

            float xend = (float)Math.Round(x0);
            float yend = y0 + gradient * (xend - x0);
            float xgap = (float)(1 - frac(x0 + 0.5));
            float xpxl1 = xend;
            float ypxl1 = (float)Math.Floor(yend);
            if (steep)
            {
                fb.SetPixel(new Point((int)ypxl1, (int)xpxl1), Color.FromArgb(bytify((1 - frac(yend)) * xgap), color.R, color.G, color.B));
                fb.SetPixel(new Point((int)ypxl1 + 1, (int)xpxl1), Color.FromArgb(bytify(frac(yend) * xgap), color.R, color.G, color.B));
            }
            else
            {
                fb.SetPixel(new Point((int)xpxl1, (int)ypxl1), Color.FromArgb(bytify((1 - frac(yend)) * xgap), color.R, color.G, color.B));
                fb.SetPixel(new Point((int)xpxl1, (int)ypxl1 + 1), Color.FromArgb(bytify((1 - frac(yend)) * xgap), color.R, color.G, color.B));
            }
            float intery = yend + gradient;

            xend = (float)Math.Round(x1);
            yend = y1 + gradient * (xend - x1);
            xgap = (float)frac(x1 + 0.5);
            float xpxl2 = xend;
            float ypxl2 = (float)Math.Floor(yend);
            if (steep)
            {
                fb.SetPixel(new Point((int)ypxl2, (int)xpxl2), Color.FromArgb(bytify((1 - frac(yend)) * xgap), color.R, color.G, color.B));
                fb.SetPixel(new Point((int)ypxl2 + 1, (int)xpxl2), Color.FromArgb(bytify(frac(yend) * xgap), color.R, color.G, color.B));
            }
            else
            {
                fb.SetPixel(new Point((int)xpxl2, (int)ypxl2), Color.FromArgb(bytify((1 - frac(yend)) * xgap), color.R, color.G, color.B));
                fb.SetPixel(new Point((int)xpxl2, (int)ypxl2 + 1), Color.FromArgb(bytify(frac(yend) * xgap), color.R, color.G, color.B));
            }

            if (steep)
            {
                for (var x = xpxl1 + 1; x < xpxl2; x++)
                {
                    fb.SetPixel(new Point((int)Math.Floor(intery), (int)x), Color.FromArgb(bytify(1 - frac(intery)), color.R, color.G, color.B));
                    fb.SetPixel(new Point((int)Math.Floor(intery) + 1, (int)x), Color.FromArgb(bytify(frac(intery)), color.R, color.G, color.B));
                    intery += gradient;
                }
            }
            else
            {
                for (var x = xpxl1 + 1; x < xpxl2; x++)
                {
                    fb.SetPixel(new Point((int)x, (int)Math.Floor(intery)), Color.FromArgb(bytify(1 - frac(intery)), color.R, color.G, color.B));
                    fb.SetPixel(new Point((int)x, (int)Math.Floor(intery) + 1), Color.FromArgb(bytify(frac(intery)), color.R, color.G, color.B));
                    intery += gradient;
                }
            }


        }

        public static void DrawFigure(ref Camera camera, Polyhedron polyhedron, Color color,  ref FastBitmap fb)
        {

            foreach (Polygon poly in polyhedron.polys)
            {
                foreach (Edge edge in poly.edges)
                {

                    PointF? p1 = camera.getProjection(edge.start);
                    PointF? p2 = camera.getProjection(edge.end);
                    if (p1.HasValue && p2.HasValue)
                    {
                        DrawLine(p1.Value, p2.Value, color, ref fb);
                    }

                }

            }
        }
        public static void DrawFigurePruned(ref Camera camera, Polyhedron polyhedron, Color color,  ref FastBitmap fb)
        {

            foreach (Polygon poly in InvisibleFacesRemoval.Remove(ref camera, polyhedron))
            {
                
                foreach (Edge edge in poly.edges)
                {
                    PointF? p1 = camera.getProjection(edge.start);
                    PointF? p2 = camera.getProjection(edge.end);
                    if (p1.HasValue && p2.HasValue)
                    {
                        DrawLine(p1.Value, p2.Value, color, ref fb);
                    }

                }
            }
        }

        public static void DrawScene(ref Camera camera, ref List<Polyhedron> polyhedrons, ref FastBitmap fb) 
        {
            foreach (Polyhedron poly in polyhedrons) 
            {
                DrawFigure(ref camera, poly,Color.Black,  ref fb);
            }
        }

        public static void DrawScenePruned(ref Camera camera, ref List<Polyhedron> polyhedrons, ref FastBitmap fb)
        {
            foreach (Polyhedron poly in polyhedrons)
            {
                DrawFigurePruned(ref camera, poly, Color.Black, ref fb);
            }
        }

        public static void DrawSceneZbuffer(int w, int h, ref List<Polyhedron> polyhedrons, ref Camera camera, ref FastBitmap fb)
        {
            Z_buffer.z_buf(w,h, polyhedrons, ref camera, ref fb);
        }
    }
}
