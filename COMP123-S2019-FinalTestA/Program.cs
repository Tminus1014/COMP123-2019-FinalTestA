using COMP123_S2019_FinalTestA.Objects;
using COMP123_S2019_FinalTestA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_FinalTestA {
    static class Program {
        public static HeroGenerator heroGenerator;
        public static AboutForm aboutForm;
        public static Hero hero;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Forms
            heroGenerator = new HeroGenerator();
            aboutForm = new AboutForm();

            // Objects
            hero = new Hero();

            Application.Run(heroGenerator);
        }
    }
}
