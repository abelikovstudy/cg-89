using cg_lab89.Figures;
using cg_lab89.MathUtils;
using cg_lab89.Primitives;
using cg_lab89.Render;
using System.Diagnostics;
using static cg_lab89.Constants;
/* TODO
 * 3) Освещение
 * 4) Выбор объекта через луч
 * 5) Текстуры и горизонт
 */

namespace cg_lab89
{
    public partial class Form1 : Form
    {
        public Camera camera;
        List<Polyhedron> polyhedrons;
        Polyhedron selected;
        public Form1()
        {
            InitializeComponent();
            WORLD_X = pictureBox1.Width / 2;
            WORLD_Y = pictureBox1.Height / 2;
            camera = new Camera(70.0f);
            polyhedrons = new List<Polyhedron>();
            panelObject.Hide();
            radioRotateX.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuCreate.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void contextMenuCreate_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void graphicPanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap pictureBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            FastBitmap fb = new FastBitmap(pictureBitmap);
            if (radioRenderDefault.Checked)
            {
                Drawing.DrawScene(ref camera, ref polyhedrons, ref fb);
                if (polyhedrons.Count != 0) Drawing.DrawFigure(ref camera, selected, Color.Red, ref fb);
            }
            else if (radioRenderPruning.Checked)
            {
                Drawing.DrawScenePruned(ref camera, ref polyhedrons, ref fb);
                if (polyhedrons.Count != 0) Drawing.DrawFigurePruned(ref camera, selected, Color.Red, ref fb);
            }
            else if(radioRenderZbuffer.Checked)
            {
                Drawing.DrawSceneZbuffer(pictureBox1.Width + 500, pictureBox1.Height + 500, ref polyhedrons, ref camera, ref fb);
            }
            pictureBox1.Image = pictureBitmap;
            fb.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    camera.move(new VectorUtils(0, 10, 0));
                    break;
                case Keys.A:
                    camera.move(new VectorUtils(10, 0, 0));
                    break;
                case Keys.S:
                    camera.move(new VectorUtils(0, -10, 0));
                    break;
                case Keys.D:
                    camera.move(new VectorUtils(-10, 0, 0));
                    break;
                case Keys.Q:
                    camera.move(new VectorUtils(0, 0, 10));
                    break;
                case Keys.E:
                    camera.move(new VectorUtils(0, 0, -10));
                    break;
                case Keys.I:
                    camera.rotate(new VectorUtils(0, 0.3, 0));
                    break;
                case Keys.L:
                    camera.rotate(new VectorUtils(0.05, 0, 0));
                    break;
                case Keys.K:
                    camera.rotate(new VectorUtils(0, -0.3, 0));
                    break;
                case Keys.J:
                    camera.rotate(new VectorUtils(-0.05, 0, 0));
                    break;
            }

            pictureBox1.Update();
        }

        private void contextMenuCreateFigure(object sender, EventArgs e)
        {

            Debug.Write(sender.ToString());
            switch (sender.ToString())
            {
                case "Тетраэдр":
                    Tetrahedron t = new Tetrahedron();
                    polyhedrons.Add(t.shape);
                    polyhedrons.Last().dots = AffineTransformations.shift(t.shape.dots, camera.position.x, camera.position.y, 0);
                    polyhedrons.Last().type = FigureType.Tetrahedron;
                    break;
                case "Гексаэдр":
                    Hexahedron h = new Hexahedron();
                    polyhedrons.Add(h.shape);
                    polyhedrons.Last().dots = AffineTransformations.shift(h.shape.dots, camera.position.x, camera.position.y, 0);
                    foreach (Dot dot in polyhedrons.Last().dots) dot.type = FigureType.Hexahedron;
                    polyhedrons.Last().type = FigureType.Hexahedron;
                    break;
                case "Додекаэдр":
                    Dodecahedron d = new Dodecahedron();
                    polyhedrons.Add(d.shape);
                    polyhedrons.Last().dots = AffineTransformations.shift(d.shape.dots, camera.position.x, camera.position.y, 0);
                    foreach (Dot dot in polyhedrons.Last().dots) dot.type = FigureType.Dodecahedron;
                    polyhedrons.Last().type = FigureType.Dodecahedron;
                    break;
            }

            polyhedrons.Last().transform();
            selected = polyhedrons.Last();
            toolStripComboBox1.Items.Add(selected);
            toolStripComboBox1.SelectedIndex = polyhedrons.Count - 1;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = polyhedrons[toolStripComboBox1.SelectedIndex];
            pictureBox1.Invalidate();
            panelObject.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            camera.updateCamera(trackBar1.Value, trackBar2.Value);
            pictureBox1.Invalidate();
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            Axis a;
            if (radioRotateX.Checked) a = Axis.X;
            else if (radioRotateY.Checked) a = Axis.Y;
            else a = Axis.Z;
            selected.dots = AffineTransformations.rotate_around_center(selected.dots, selected.getCenter(), a, int.Parse(textR.Text));
            selected.transform();
            pictureBox1.Invalidate();
        }


        private void buttonShift_Click(object sender, EventArgs e)
        {
            selected.dots = AffineTransformations.shift(selected.dots, double.Parse(textSX.Text), double.Parse(textSY.Text), double.Parse(textSZ.Text));
            selected.transform();
            pictureBox1.Invalidate();
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            selected.dots = AffineTransformations.scale(selected.dots, double.Parse(textMX.Text), double.Parse(textMY.Text), double.Parse(textMZ.Text));
            selected.transform();
            pictureBox1.Invalidate();
        }
    }
}