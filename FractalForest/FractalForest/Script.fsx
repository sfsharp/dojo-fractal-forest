open System
open System.Drawing
open System.Windows.Forms

// Create a form to display the graphics         
let form = new Form(Width = 500, Height = 500)
let box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let image = new Bitmap(500, 500)
let graphics = Graphics.FromImage(image)
let brush = new SolidBrush(Color.FromArgb(0, 0, 0))

box.Image <- image
form.Controls.Add(box) 

let endpoint x y angle length =
    x + length * cos angle,
    y + length * sin angle

// Utility function: draw a line of given width, 
// starting from x, y
// going at a certain angle, for a certain length.
let drawLine (target : Graphics) (brush : Brush) x y angle length width =
    let x_end, y_end = endpoint x y angle length
    let origin = new PointF(x, y)
    let destination = new PointF(x_end, y_end)
    let pen = new Pen(brush, width)
    target.DrawLine(pen, origin, destination)

let draw x y angle length width = 
    drawLine graphics brush x y angle length width

let pi = Math.PI |> (single)

// Now... your turn to draw
// The trunk
draw 250.f 400.f (pi*(1.5f)) 100.0f 4.f
let x, y = endpoint 250.f 400.f (pi*(1.5f)) 100.0f
// first and second branches
draw x y (pi*(1.5f + 0.3f)) 50.f 2.f
draw x y (pi*(1.5f - 0.3f)) 50.f 2.f

form.ShowDialog()