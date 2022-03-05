/*
 * LTranQGame.cs
 * User designing a QGame puzzle from the control panel form, user saves the maze which can then be played 
 * 
 * Revision History:
 *      Lina Tran 2021.10.07: created
 *      Lina Tran 2021.10.26: added images, buttons, grid, started save dialog
 *      Lina Tran 2021.10.28: finished? don't know if saved text file is done properly(whether it can be used to load a game)
 *      Lina Tran 2021.11.03: fixed saved file code; finished
 *      Lina Tran 2021.11.06: start assignment 3, play form, load saved file, generate game onto play form
 *      Lina Tran 2021.11.14: created code to move boxes, if right door, removes picbox
 *      Lina Tran 2021.11.15 & 16: finished
 * 
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LTranQGame
{
    /// <summary>
    /// Play form to play a level designed in the Maze Designer Form
    /// </summary>
    public partial class PlayForm : Form
    {
        public const int initialx = 24; //initial x location of first picturebox
        public const int initialy = 26; //initial y location of first picturebox
        public const int width = 64;
        public const int height = 57;
        public int max_row;
        public int max_col;
        public int row = 0;
        public int col = 0;
        private Image WALL = LTranQGame.Properties.Resources.wall; // global variable to access wall image
        private Image GREEN_DOOR = LTranQGame.Properties.Resources.greenDoor; // global variable to access green door image
        private Image YELLOW_DOOR = LTranQGame.Properties.Resources.yellowDoor; // access yellow door
        private Image GREEN_XIAO = LTranQGame.Properties.Resources.xiaoGreen; //access green box
        private Image YELLOW_ZHONGLI = LTranQGame.Properties.Resources.zhongliYellow; // access yellow box
        public int countBoxes = 0;
        public int countMoves = 0;
        public bool isSelected = false;
        PictureBox pic;

        public const int wall = 1;
        public const int green_door = 2;
        public const int yellow_door = 3;
        public const int green_box = 4;
        public const int yellow_box = 5;


        /// <summary>
        /// Default constructor of play form
        /// </summary>
        public PlayForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load the file and create the game to be played, buttons enabled, image loaded based on tag
        /// </summary>
        /// <param name="fileName"></param>
        private void load(string fileName)
        {
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            panel.Controls.Clear();

            int row = 0;
            int col = 0;
            int tileType = 0;
            int numberOfLines = 3;
            countMoves = 0;
            countBoxes = 0;

            //size of picturebox, same as design form
            Size size = new Size(width, height);

            StreamReader reader = new StreamReader(fileName);
            max_row = Convert.ToInt32(reader.ReadLine());
            max_col = Convert.ToInt32(reader.ReadLine());

            //read lines to generate pictureboxes
            for (int i = 0; i < max_row * max_col * numberOfLines; i++)
            {
                row = Convert.ToInt32(reader.ReadLine());
                col = Convert.ToInt32(reader.ReadLine());
                tileType = Convert.ToInt32(reader.ReadLine());

                pic = new PictureBox
                {
                    Size = size,
                    Location = new Point(initialx + col * size.Width, initialy + row * size.Height),
                    BorderStyle = BorderStyle.None,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = true,
                    Tag = tileType
                };
                panel.Controls.Add(pic);
            }
            //load image of picturebox based on tags
            foreach (PictureBox picture in panel.Controls)
            {
                if (picture.Tag.ToString() == wall.ToString())
                {
                    picture.Image = WALL;
                }
                else if (picture.Tag.ToString() == green_door.ToString())
                {
                    picture.Image = GREEN_DOOR;
                }
                else if (picture.Tag.ToString() == yellow_door.ToString())
                {
                    picture.Image = YELLOW_DOOR;
                }
                else if (picture.Tag.ToString() == green_box.ToString())
                {
                    countBoxes++;
                    picture.Image = GREEN_XIAO;
                    picture.Click += moveBox_Click;
                }
                else if (picture.Tag.ToString() == yellow_box.ToString())
                {
                    countBoxes++;
                    picture.Image = YELLOW_ZHONGLI;
                    picture.Click += moveBox_Click;
                }
            }
            txtNumberOfBoxes.Text = countBoxes.ToString();
        }

        /// <summary>
        /// Click event to move the boxes only, shows which box was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveBox_Click(object sender, EventArgs e)
        {
            foreach (PictureBox p in panel.Controls)
            {
                if (p.Image == GREEN_XIAO || p.Image == YELLOW_ZHONGLI)
                {
                    p.BorderStyle = BorderStyle.None;
                }
            }
            pic = (PictureBox)sender;
            pic.BorderStyle = BorderStyle.FixedSingle;
            isSelected = true;
        }

        /// <summary>
        /// load the file from the menu tool strip and use openfile dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "All files|*.*";
            DialogResult r = dlgOpen.ShowDialog();
            switch (r)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    try
                    {
                        string fileName = dlgOpen.FileName;
                        load(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in file load");
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

        /// <summary>
        /// closes the play form, bringing user back to control form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Click event to move box up until hit obstacle or door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (isSelected != true)
            {
                MessageBox.Show("Please select a box to move");
            }
            else
            {
                countMoves++;
                txtMoves.Text = countMoves.ToString();

                bool stop = true;
                while (stop)
                {
                    foreach (PictureBox picture in panel.Controls)
                    {
                        if (pic.Top == picture.Bottom && pic.Left == picture.Left && picture.Image == WALL)
                        {
                            stop = false;
                        }
                        else if (pic.Top == picture.Bottom && pic.Left == picture.Left && picture.Image == GREEN_DOOR)
                        {
                            if (pic.Image == GREEN_XIAO)
                            {
                                pic.Dispose();
                                isSelected = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                                stop = false;
                            }
                            else if (pic.Image == YELLOW_ZHONGLI)
                            {
                                stop = false;
                            }
                        }
                        else if (pic.Top == picture.Bottom && pic.Left == picture.Left && picture.Image == YELLOW_DOOR)
                        {
                            if (pic.Image == YELLOW_ZHONGLI)
                            {
                                pic.Dispose();
                                isSelected = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                                stop = false;
                            }
                            else if (pic.Image == GREEN_XIAO)
                            {
                                stop = false;
                            }
                        }
                        else if (pic.Top == picture.Bottom && pic.Left == picture.Left && ((pic.Image == GREEN_XIAO || pic.Image == YELLOW_ZHONGLI) && (picture.Image == GREEN_XIAO || picture.Image == YELLOW_ZHONGLI)))
                        {
                            stop = false;
                        }
                    }
                    if (stop)
                    {
                        pic.BringToFront();
                        pic.Top -= height; 
                    }
                }
            }
        }

        /// <summary>
        /// Click event to move box down until obstacle or door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (isSelected != true)
            {
                MessageBox.Show("Please select a box to move");
            }
            else
            {
                countMoves++;
                txtMoves.Text = countMoves.ToString();
                bool stop = true;
                while (stop)
                {
                    foreach (PictureBox picture in panel.Controls)
                    {
                        if (picture.Top == pic.Bottom && pic.Left == picture.Left && picture.Image == WALL)
                        {
                            stop = false;
                        }
                        else if (picture.Top == pic.Bottom && pic.Left == picture.Left && picture.Image == GREEN_DOOR)
                        {
                            if (pic.Image == GREEN_XIAO)
                            {
                                pic.Dispose();
                                isSelected = false;
                                stop = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                            }
                            else if (pic.Image == YELLOW_ZHONGLI)
                            {
                                stop = false;
                            }
                        }
                        else if (picture.Top == pic.Bottom && pic.Left == picture.Left && picture.Image == YELLOW_DOOR)
                        {
                            if (pic.Image == YELLOW_ZHONGLI)
                            {
                                pic.Dispose();
                                isSelected = false;
                                stop = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                            }
                            else if (pic.Image == GREEN_XIAO)
                            {
                                stop = false;
                            }
                        }
                        else if (picture.Top == pic.Bottom && pic.Right == picture.Right && ((pic.Image == GREEN_XIAO || pic.Image == YELLOW_ZHONGLI) && (picture.Image == GREEN_XIAO || picture.Image == YELLOW_ZHONGLI)))
                        {
                            stop = false;
                        }
                    }
                    if (stop)
                    {
                        pic.BringToFront();
                        pic.Top += height;
                    }
                }
            }
        }

        /// <summary>
        /// Click event to move box left until obstacle or door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (isSelected != true)
            {
                MessageBox.Show("Please select a box to move");
            }
            else
            {
                countMoves++;
                txtMoves.Text = countMoves.ToString();
                bool stop = true;
                while (stop)
                {
                    foreach (PictureBox picture in panel.Controls)
                    {
                        if (pic.Left == picture.Right && pic.Top == picture.Top && picture.Image == WALL)
                        {
                            stop = false;
                        }
                        else if (pic.Left == picture.Right && pic.Top == picture.Top && picture.Image == GREEN_DOOR)
                        {
                            if (pic.Image == GREEN_XIAO)
                            {
                                pic.Dispose();
                                isSelected = false;
                                stop = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                            }
                            else if (pic.Image == YELLOW_ZHONGLI)
                            {
                                stop = false;
                            }
                        }
                        else if (pic.Left == picture.Right && pic.Top == picture.Top && picture.Image == YELLOW_DOOR)
                        {
                            if (pic.Image == YELLOW_ZHONGLI)
                            {
                                pic.Dispose();
                                isSelected = false;
                                stop = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                            }
                            else if (pic.Image == GREEN_XIAO)
                            {
                                stop = false;
                            }
                        }
                        else if (pic.Left == picture.Right && pic.Top == picture.Top && ((pic.Image == GREEN_XIAO || pic.Image == YELLOW_ZHONGLI) && (picture.Image == GREEN_XIAO || picture.Image == YELLOW_ZHONGLI)))
                        {
                            stop = false;
                        }
                    }
                    if (stop)
                    {
                        pic.BringToFront();
                        pic.Left -= width;
                    }
                }
            }
        }

        /// <summary>
        /// Click event to move box right until obstacle or door
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (isSelected != true)
            {
                MessageBox.Show("Please select a box to move");
            }
            else
            {
                countMoves++;
                txtMoves.Text = countMoves.ToString();
                bool stop = true;
                while (stop)
                {
                    foreach (PictureBox picture in panel.Controls)
                    {
                        if (picture.Left == pic.Right && pic.Top == picture.Top && picture.Image == WALL)
                        {
                            stop = false;
                        }
                        else if (picture.Left == pic.Right && pic.Top == picture.Top && picture.Image == GREEN_DOOR)
                        {
                            if (pic.Image == GREEN_XIAO)
                            {
                                pic.Dispose();
                                isSelected = false;
                                stop = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                            }
                            else if (pic.Image == YELLOW_ZHONGLI)
                            {
                                stop = false;
                            }
                        }
                        else if (picture.Left == pic.Right && pic.Top == picture.Top && picture.Image == YELLOW_DOOR)
                        {
                            if (pic.Image == YELLOW_ZHONGLI)
                            {
                                pic.Dispose();
                                isSelected = false;
                                stop = false;
                                countBoxes--;
                                numberOfBoxes(countBoxes);
                            }
                            else if (pic.Image == GREEN_XIAO)
                            {
                                stop = false;
                            }
                        }
                        else if (picture.Left == pic.Right && pic.Top == picture.Top && ((pic.Image == GREEN_XIAO || pic.Image == YELLOW_ZHONGLI) && (picture.Image == GREEN_XIAO || picture.Image == YELLOW_ZHONGLI)))
                        {
                            stop = false;
                        }
                    }
                    if (stop)
                    {
                        pic.BringToFront();
                        pic.Left += width;
                    }
                }
            }
        }

        /// <summary>
        /// Counts the number of boxes, when zero, player wins and panel cleared, can load another design
        /// </summary>
        /// <param name="count"></param>
        private void numberOfBoxes(int count)
        {
            if (count == 0)
            {
                txtNumberOfBoxes.Text = count.ToString();
                MessageBox.Show("There are no more boxes. You win!");
                panel.Controls.Clear();
                countMoves = 0;
                txtMoves.Text = countMoves.ToString();
            }
            else
            {
                txtNumberOfBoxes.Text = count.ToString();
            }
        }
    }
}
