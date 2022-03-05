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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTranQGame
{
    /// <summary>
    /// Contorl panel form, user clicks to design maze level or play a saved level
    /// </summary>
    public partial class ControlPanelForm : Form
    {
        /// <summary>
        /// default contructor
        /// </summary>
        public ControlPanelForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button click event to go to the maze design form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            MazeDesignerForm design = new MazeDesignerForm();
            design.Show();
        }

        /// <summary>
        /// Button click event to go to play form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayForm play = new PlayForm();
            play.Show();
        }
    }
}
