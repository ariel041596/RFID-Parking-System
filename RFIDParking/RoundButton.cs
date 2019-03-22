using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDParking
{
    class RoundButton : System.Windows.Forms.Button
    {
        public int Bordersize = 5;
        public Color BorderColor = Color.FromArgb(255, 255, 255);


        public RoundButton()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.White;
            FlatAppearance.BorderColor = BorderColor;
            FlatAppearance.BorderSize = Bordersize;


        }
        int top;
        int left;
        int right;
        int bottom;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            int CornerRadius = 18;

            Pen DrawPen = new Pen(BorderColor);

            GraphicsPath g = new GraphicsPath();

            top = 0;
            left = 0;
            right = Width;
            bottom = Height;
            g.AddArc(left, top, CornerRadius, CornerRadius, 180, 90);
            g.AddArc(right - CornerRadius, top, CornerRadius, CornerRadius, 270, 90);
            g.AddArc(right - CornerRadius, bottom - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            g.AddArc(left, bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90);

            g.CloseAllFigures();

            pevent.Graphics.DrawPath(DrawPen, g);

            int inside = 1;

            Pen newPen = new Pen(BorderColor, Bordersize);
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(left + inside + 1, top + inside, CornerRadius, CornerRadius, 180, 100);

            gp.AddArc(right - CornerRadius - inside - 2, top + inside, CornerRadius, CornerRadius, 270, 90);
            gp.AddArc(right - CornerRadius - inside - 2, bottom - CornerRadius - inside - 1, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(left + right + 1, bottom - CornerRadius - inside - 1, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(left + inside + 1, bottom - CornerRadius - inside, CornerRadius, CornerRadius, 95, 95);
            pevent.Graphics.DrawPath(newPen, gp);

            this.Region = new System.Drawing.Region(g);

        }
    }
}
