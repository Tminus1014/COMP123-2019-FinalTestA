using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * Student Name: Trent B Minia
 * Student ID: 301041132
 * 
 * Description: Hero Generator Form
 * 
 */

namespace COMP123_S2019_FinalTestA.Views {
    public partial class HeroGenerator : COMP123_S2019_FinalTestA.Views.MasterForm {
        public HeroGenerator() {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the BackButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e) {
            if (MainTabControl.SelectedIndex != 0) {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// Event handler for the NextButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e) {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1) {
                MainTabControl.SelectedIndex++;
            }
        }

        private void GenerateNameButton_Click(object sender, EventArgs e) {
            // How will this read from the list of names and randomly generate a name?
        }
    }
}
