using COMP123_S2019_FinalTestA.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        // Lists
        List<string> FirstNameList = new List<string>();
        List<string> LastNameList = new List<string>();

        // Random Number Generator
        Random rng = new Random();

        public HeroGenerator() {
            InitializeComponent();
        }

        /* ------------ */
        /* -= Events =- */
        /* ------------ */

        private void HeroGenerator_Load(object sender, EventArgs e) {
            loadNames();
            loadPowers();
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
        /// <summary>
        /// Generates abilities via rng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbilitiesButton_Click(object sender, EventArgs e) {
            int rangeMin = 1;
            int rangeMax = 11;

            // Physical
            Program.hero.Fighting = rng.Next(rangeMin, rangeMax).ToString();
            Program.hero.Agility = rng.Next(rangeMin, rangeMax).ToString();
            Program.hero.Strength = rng.Next(rangeMin, rangeMax).ToString();
            Program.hero.Endurance = rng.Next(rangeMin, rangeMax).ToString();
            
            // Mental
            Program.hero.Reason = rng.Next(rangeMin, rangeMax).ToString();
            Program.hero.Intuition = rng.Next(rangeMin, rangeMax).ToString();
            Program.hero.Psyche = rng.Next(rangeMin, rangeMax).ToString();
            Program.hero.Popularity = rng.Next(rangeMin, rangeMax).ToString();

            // Display on Form
            displayAbilities();
        }

        private void GenerateNameButton_Click(object sender, EventArgs e) {
            generateName();
        }

        private void GeneratePowers_Click(object sender, EventArgs e) {
            generateRandomPowers();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Program.aboutForm.Show();
        }

        /* ------------- */
        /* -= Methods =- */
        /* ------------- */

        private void loadNames() {
            FirstNameList = File.ReadLines("../../Data/firstNames.txt").ToList();
            LastNameList = File.ReadLines("../../Data/lastNames.txt").ToList();
        }

        private void loadPowers() {
            //Program.hero.Powers = File.ReadLines("../../Data/powers.txt").ToList();
        }

        private void generateName() {
            int firstNamesListSize = FirstNameList.Count + 1;
            int lastNamesListSize = LastNameList.Count + 1;
            
            int firstNameIndex = rng.Next(1, firstNamesListSize);
            int lastNameIndex = rng.Next(1, lastNamesListSize);

            Program.hero.FirstName = FirstNameList[firstNameIndex];
            Program.hero.LastName = LastNameList[lastNameIndex];
            displayName();
        }

        private void displayName() {
            FirstNameDataLabel.Text = Program.hero.FirstName;
            LastNameDataLabel.Text = Program.hero.LastName;
        }

        private void displayAbilities() {
            // Physical
            FightingDataLabel.Text = Program.hero.Fighting;
            AgilityDataLabel.Text = Program.hero.Agility;
            StrengthDataLabel.Text = Program.hero.Strength;
            EnduranceDataLabel.Text = Program.hero.Endurance;

            // Mental
            ReasonDataLabel.Text = Program.hero.Reason;
            IntuitionDataLabel.Text = Program.hero.Intuition;
            PsycheDataLabel.Text = Program.hero.Psyche;
            PopularityDataLabel.Text = Program.hero.Popularity;
        }

        private void generateRandomPowers() {

        }
    }
}
