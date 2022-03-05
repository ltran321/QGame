/*
 * LTranQGame.cs
 * User designing a QGame puzzle from the control panel form, user saves the maze which can then be played 
 * 
 * Revision History:
 *      Lina Tran 2021.10.07: created
 *      Lina Tran 2021.10.26: added images, buttons, grid, started save dialog
 *      Lina Tran 2021.10.28: finished? don't know if saved text file is done properly(whether it can be used to load a game)
 *      Lina Tran 2021.11.03: fixed saved file code; finished
 *      Lina Tran 2021.11.06: start assignment 3, play form
 *      
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LTranQGame
{
    /// <summary>
    /// Maze designer form, saves a level after finished designing
    /// </summary>
    public partial class MazeDesignerForm : Form
    {
        private Image imageWall = LTranQGame.Properties.Resources.wall; // global variable to access wall image
        private Image imageDoor1 = LTranQGame.Properties.Resources.greenDoor; // global variable to access green door image
        private Image imageDoor2 = LTranQGame.Properties.Resources.yellowDoor; // access yellow door
        private Image imageBox1 = LTranQGame.Properties.Resources.xiaoGreen; //access green box
        private Image imageBox2 = LTranQGame.Properties.Resources.zhongliYellow; // access yellow box
        private Image imageNone = LTranQGame.Properties.Resources.none; //access none image
        private Image gridImage;
        private int content = 0;
        public const int WIDTH = 84;
        public const int HEIGHT = 78;
        public const int WALL = 1;
        public const int Green_Door = 2;
        public const int Yellow_Door = 3;
        public const int Green_Box = 4;
        public const int Yellow_Box = 5;



        /// <summary>
        /// default contructor of maze design form
        /// </summary>
        public MazeDesignerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button to generate the picture boxes grid to create maze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //take user input to generate grid of row# and column#
                int rowsNumber = int.Parse(txtRowNumber.Text);
                int columnsNumber = int.Parse(txtColumnNumber.Text);

                //first picBox location
                int x = 256;
                int y = 108;

                //size of pictureboxes
                Size size = new Size(WIDTH, HEIGHT);
                int totalBoxes = rowsNumber * columnsNumber;
                //create grid
                for (int rows = 0; rows < rowsNumber; rows++)
                {
                    int currentY = y + rows * size.Height;
                    for (int cols = 0; cols < columnsNumber; cols++)
                    {
                        int currentX = x + cols * size.Width;
                        PictureBox picture = new PictureBox
                        {
                            Name = rows.ToString() + " " + cols.ToString(),
                            Size = size,
                            Location = new Point(currentX, currentY),
                            BorderStyle = BorderStyle.FixedSingle,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Visible = true,
                            Tag = 0
                        };
                        picture.Click += imageChange_Click;
                        this.Controls.Add(picture);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rows and Columns must be an integer");
            }
        }

        /// <summary>
        /// click event handler for all picture boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageChange_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Image = gridImage;
            p.Tag = content;
        }
        /// <summary>
        /// button to make picture box image null/nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNone_Click(object sender, EventArgs e)
        {
            gridImage = null;
            content = 0;
        }

        /// <summary>
        /// button to change image of picture box to a wall
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWall_Click(object sender, EventArgs e)
        {
            gridImage = imageWall;
            content = WALL;
        }

        /// <summary>
        /// button to change image of picture box to a green door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoor1_Click(object sender, EventArgs e)
        {
            gridImage = imageDoor1;
            content = Green_Door;
        }

        /// <summary>
        /// button to change image of picture box to a yellow door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoor2_Click(object sender, EventArgs e)
        {
            gridImage = imageDoor2;
            content = Yellow_Door;
        }

        /// <summary>
        /// button to change image to green box aka xiao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBox1_Click(object sender, EventArgs e)
        {
            gridImage = imageBox1;
            content = Green_Box;
        }

        /// <summary>
        /// button to change image to yellow box aka zhongli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBox2_Click(object sender, EventArgs e)
        {
            gridImage = imageBox2;
            content = Yellow_Box;
        }

        /// <summary>
        /// close the design form from the menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// create the save file, showing row and column of grid of pictureboxes
        /// </summary>
        /// <param name="fileName"></param>
        private void save(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(Convert.ToInt32(txtRowNumber.Text));
            writer.WriteLine(Convert.ToInt32(txtColumnNumber.Text));
            foreach (Control c in this.Controls)
            {
                PictureBox pic = c as PictureBox;
                if (pic != null)
                {
                    writer.WriteLine((pic.Location.Y/HEIGHT - 1) + "\n" + (pic.Location.X/WIDTH - 3) + "\n" + pic.Tag);
                }
            }
            writer.Close();
        }

        /// <summary>
        /// save the designed level from the menu strip and count the # of walls, doors and boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countWall = 0;
            int countDoor1 = 0;
            int countDoor2 = 0;
            int countBox1 = 0;
            int countBox2 = 0;

            foreach (Control c in this.Controls)
            {
                PictureBox pic = c as PictureBox;
                if (pic != null)
                {
                    if (pic.Tag.ToString() == WALL.ToString())
                    {
                        countWall++;
                    }
                    if (pic.Tag.ToString() == Green_Door.ToString())
                    {
                        countDoor1++;
                    }
                    if (pic.Tag.ToString() == Yellow_Door.ToString())
                    {
                        countDoor2++;
                    }
                    if (pic.Tag.ToString() == Green_Box.ToString())
                    {
                        countBox1++;
                    }
                    if (pic.Tag.ToString() == Yellow_Box.ToString())
                    {
                        countBox2++;
                    }
                }
            }


            dlgSave.Filter = "Text file|*.txt|All files|*.*";
            DialogResult r = dlgSave.ShowDialog();
            switch (r)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = dlgSave.FileName;
                        save(fileName);
                        MessageBox.Show("File saved successfully\n" + "Total number of walls: " + countWall + "\n" +
                            "Total number of doors: " + (countDoor1 + countDoor2) + "\n" +
                            "Total number of boxes: " + (countBox1 + countBox2));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in file save");
                    }
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
