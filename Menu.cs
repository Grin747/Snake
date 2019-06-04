using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace snake
{
    class Menu : Form
    {
        public Menu()
        {
            Size = new Size(1024, 512);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.Manual;
            BackgroundImage = Image.FromFile(@"../../res/tex/Menu.png");
            BackgroundImageLayout = ImageLayout.Center;

            Button start = new Button()
            {
                Size = new Size(128, 64),
                Location = new Point(100, 128),
                Image = Image.FromFile(@"../../res/tex/Start.png"),
            };
            start.Click += Start;
            Controls.Add(start);

            Button career = new Button()
            {
                Size = new Size(128, 64),
                Location = new Point(332, 128),
                Image = Image.FromFile(@"../../res/tex/Career.png"),
            };
            Controls.Add(career);

            Button custom = new Button()
            {
                Size = new Size(128, 64),
                Location = new Point(556, 128),
                Image = Image.FromFile(@"../../res/tex/Custom.png"),
            };
            custom.Click += Custom;
            Controls.Add(custom);

            Button exit = new Button()
            {
                Size = new Size(128, 64),
                Location = new Point(796, 128),
                Image = Image.FromFile(@"../../res/tex/Exit.png"),
            };
            exit.Click += Exit;
            Controls.Add(exit);
        }

        void Start(object sender, EventArgs e)
        {
            var game = new Game(this);
            game.Show();
            Hide();
        }

        void Custom(object sender, EventArgs e)
        {
            var game = new Game(this, File.ReadAllLines(@"../../res/lvl/1.txt"));
            game.Show();
            Hide();
        }

        void Exit(object sender, EventArgs e)
        {
            Close();
        }

    }
}
