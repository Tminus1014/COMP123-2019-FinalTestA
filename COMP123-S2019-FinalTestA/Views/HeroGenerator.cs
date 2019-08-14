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
        List<string> PowersList = new List<string>();

        // Random Number Generator
        Random rng = new Random();

        public HeroGenerator() {
            InitializeComponent();
        }

        /* ------------ */
        /* -= Events =- */
        /* ------------ */

        /// <summary>
        /// Event handler for HeroGenerator on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroGenerator_Load(object sender, EventArgs e) {
            loadNames();
            loadPowers();
        }

        /// <summary>
        /// Event handler for MainTabControl. If Character Sheet is selected, display hero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainTabControl.SelectedIndex == 3) {
                displayHero();
            }
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
            int rangeMin = 10;
            int rangeMax = 51;

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

        /// <summary>
        /// Assigns hero name once given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroNameTextBox_TextChanged(object sender, EventArgs e) {
            Program.hero.HeroName = HeroNameTextBox.Text;
        }

        /// <summary>
        /// Generates a name when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e) {
            generateName();
        }

        /// <summary>
        /// Generates a power when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeneratePowers_Click(object sender, EventArgs e) {
            generateRandomPowers();
        }
        

        /// <summary>
        /// Event handler for saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            saveHero();
        }

        /// <summary>
        /// Event handler for opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            loadHero();
        }


        /// <summary>
        /// Event handler for about button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Program.aboutForm.Show();
        }

        /* ------------- */
        /* -= Methods =- */
        /* ------------- */


        /// <summary>
        /// Loads the list of first and last names
        /// </summary>
        private void loadNames() {
            FirstNameList = File.ReadLines("../../Data/firstNames.txt").ToList();
            LastNameList = File.ReadLines("../../Data/lastNames.txt").ToList();
        }

        /// <summary>
        /// Loads the list of powers
        /// </summary>
        private void loadPowers() {
            PowersList = File.ReadLines("../../Data/powers.txt").ToList();
        }

        /// <summary>
        /// Generates the name
        /// </summary>
        private void generateName() {
            int firstNamesListSize = FirstNameList.Count + 1;
            int lastNamesListSize = LastNameList.Count + 1;
            
            int firstNameIndex = rng.Next(1, firstNamesListSize);
            int lastNameIndex = rng.Next(1, lastNamesListSize);

            Program.hero.FirstName = FirstNameList[firstNameIndex];
            Program.hero.LastName = LastNameList[lastNameIndex];
            displayName();
        }

        /// <summary>
        /// Displays the name
        /// </summary>
        private void displayName() {
            FirstNameDataLabel.Text = Program.hero.FirstName;
            LastNameDataLabel.Text = Program.hero.LastName;
        }

        /// <summary>
        /// Displays the abilities
        /// </summary>
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

        /// <summary>
        /// Generates powers
        /// </summary>
        private void generateRandomPowers() {
            int powersListSize = PowersList.Count + 1;

            // Method variables
            int firstPowerIndex = 0;
            int secondPowerIndex = 0;
            int thirdPowerIndex = 0;
            int fourthPowerIndex = 0;
            
            // Generate each power index numbers individually
            // First Power
            firstPowerIndex = rng.Next(1, powersListSize);

            // Second Power
            while (true) {
                secondPowerIndex = rng.Next(1, powersListSize);
                if (secondPowerIndex != firstPowerIndex) {
                    break;
                }
            }

            // Third Power
            while (true) {
                thirdPowerIndex = rng.Next(1, powersListSize);
                if (thirdPowerIndex != secondPowerIndex || thirdPowerIndex == firstPowerIndex) {
                    break;
                }
            }

            // Fourth Power
            while (true) {
                fourthPowerIndex = rng.Next(1, powersListSize);
                if (fourthPowerIndex != thirdPowerIndex || fourthPowerIndex != secondPowerIndex || fourthPowerIndex != firstPowerIndex) {
                    break;
                }
            }

            // Identify the powers via their index numbers
            string firstPower = PowersList[firstPowerIndex];
            string secondPower = PowersList[secondPowerIndex];
            string thirdPower = PowersList[thirdPowerIndex];
            string fourthPower = PowersList[fourthPowerIndex];

            // Add powers to powers list
            Program.hero.Powers.Add(new Power(firstPower));
            Program.hero.Powers.Add(new Power(secondPower));
            Program.hero.Powers.Add(new Power(thirdPower));
            Program.hero.Powers.Add(new Power(fourthPower));

            // Display Powers
            displayPowers();
        }

        /// <summary>
        /// Displays powers
        /// </summary>
        public void displayPowers() {
            FirstPowerDataLabel.Text = Program.hero.Powers[0].ToString();
            SecondPowerDataLabel.Text = Program.hero.Powers[1].ToString();
            ThirdPowerDataLabel.Text = Program.hero.Powers[2].ToString();
            FourthPowerDataLabel.Text = Program.hero.Powers[3].ToString();
        }

        /// <summary>
        /// Displays hero details
        /// </summary>
        public void displayHero() {
            // Name
            HeroNameSheetDataLabel.Text = Program.hero.HeroName;
            FirstNameSheetDataLabel.Text = Program.hero.FirstName;
            LastNameSheetDataLabel.Text = Program.hero.LastName;

            // Abilities
            FightingSheetDataLabel.Text = Program.hero.Fighting;
            StrengthSheetDataLabel.Text = Program.hero.Strength;
            AgilitySheetDataLabel.Text = Program.hero.Agility;
            EnduranceSheetDataLabel.Text = Program.hero.Endurance;

            ReasonSheetDataLabel.Text = Program.hero.Reason;
            IntuitionSheetDataLabel.Text = Program.hero.Intuition;
            PsycheSheetDataLabel.Text = Program.hero.Psyche;
            PopularitySheetDataLabel.Text = Program.hero.Popularity;

            // Powers
            try {
                FirstPowerSheetDataLabel.Text = Program.hero.Powers[0].ToString();
                SecondPowerSheetDataLabel.Text = Program.hero.Powers[1].ToString();
                ThirdPowerSheetDataLabel.Text = Program.hero.Powers[2].ToString();
                FourthPowerSheetDataLabel.Text = Program.hero.Powers[3].ToString();
            } catch {
                FirstPowerSheetDataLabel.Text = "";
                SecondPowerSheetDataLabel.Text = "";
                ThirdPowerSheetDataLabel.Text = "";
                FourthPowerSheetDataLabel.Text = "";
            }
        }

        /// <summary>
        /// Saves hero to txt
        /// </summary>
        public void saveHero() {
            SaveHeroDialog.InitialDirectory = Directory.GetCurrentDirectory();
            SaveHeroDialog.FileName = "Hero.txt";
            SaveHeroDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (SaveHeroDialog.ShowDialog() != DialogResult.Cancel) {
                using (StreamWriter outputString = new StreamWriter(File.Open(SaveHeroDialog.FileName, FileMode.Create))) {
                    outputString.WriteLine(Program.hero.HeroName);
                    outputString.WriteLine(Program.hero.FirstName);
                    outputString.WriteLine(Program.hero.LastName);
                    outputString.WriteLine(Program.hero.Fighting);
                    outputString.WriteLine(Program.hero.Strength);
                    outputString.WriteLine(Program.hero.Agility);
                    outputString.WriteLine(Program.hero.Endurance);
                    outputString.WriteLine(Program.hero.Reason);
                    outputString.WriteLine(Program.hero.Intuition);
                    outputString.WriteLine(Program.hero.Psyche);
                    outputString.WriteLine(Program.hero.Popularity);
                    outputString.WriteLine(Program.hero.Powers[0].ToString());
                    outputString.WriteLine(Program.hero.Powers[1].ToString());
                    outputString.WriteLine(Program.hero.Powers[2].ToString());
                    outputString.WriteLine(Program.hero.Powers[3].ToString());
                }
                MessageBox.Show("File Saved Successfully!", "File Saved");
            }
        }

        /// <summary>
        /// Loads hero to txt
        /// </summary>
        public void loadHero() {
            LoadHeroDialog.InitialDirectory = Directory.GetCurrentDirectory();
            LoadHeroDialog.FileName = "Hero.txt";
            LoadHeroDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            string firstPower = "";
            string secondPower = "";
            string thirdPower = "";
            string fourthPower = "";

            try {
                if (LoadHeroDialog.ShowDialog() != DialogResult.Cancel) {
                    using (StreamReader inputStream = new StreamReader(File.Open(LoadHeroDialog.FileName, FileMode.Open))) {
                        Program.hero.HeroName = inputStream.ReadLine();
                        Program.hero.FirstName = inputStream.ReadLine();
                        Program.hero.LastName = inputStream.ReadLine();

                        Program.hero.Fighting = inputStream.ReadLine();
                        Program.hero.Strength = inputStream.ReadLine();
                        Program.hero.Agility = inputStream.ReadLine();
                        Program.hero.Endurance = inputStream.ReadLine();
                        Program.hero.Reason = inputStream.ReadLine();
                        Program.hero.Intuition = inputStream.ReadLine();
                        Program.hero.Psyche = inputStream.ReadLine();
                        Program.hero.Popularity = inputStream.ReadLine();

                        firstPower = inputStream.ReadLine();
                        secondPower = inputStream.ReadLine();
                        thirdPower = inputStream.ReadLine();
                        fourthPower = inputStream.ReadLine();
                    }
                }

                Program.hero.Powers.Clear();

                Program.hero.Powers.Add(new Power(firstPower));
                Program.hero.Powers.Add(new Power(secondPower));
                Program.hero.Powers.Add(new Power(thirdPower));
                Program.hero.Powers.Add(new Power(fourthPower));

                displayHero();
            }
            catch {
                MessageBox.Show("Invalid Products file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
