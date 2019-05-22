using System;
using System.Windows.Forms;

namespace RumCoctails
{
    /// <summary>
    /// Provides methods for handling events
    /// </summary>
    class Presenter
    {
        readonly Form1 form1;
        readonly Model model;

        public Presenter(Form1 form1)
        {
            model = new Model();
            this.form1 = form1;
            this.form1.FindCoctailEvent += Form1_FindCoctailEvent;
            this.form1.RumSelectionEvent += Form1_RumSelectionEvent;
            this.form1.ShowInfoEvent += Form1_ShowInfoEvent;
        }

        #region Event Handler Methods
        /// <summary>
        /// Checks for the presence of a cocktail in the database according to a given parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FindCoctailEvent(object sender, EventArgs e)
        {
            string coctailName = form1.textBoxCoctailName.Text;
        
            if ((model.CoctailNameValidation(coctailName) != null) &&
                (model.FindCoctailComposition(coctailName) != null))
            {
                form1.textBoxShowIngredients.Text =
                model.FindCoctailComposition(coctailName);
            }
            else
            {
                MessageBox.Show("Коктейль с таким названием не найден", "Error");
                form1.textBoxCoctailName.Text = "";
                form1.textBoxShowIngredients.Text = "";
            }
        }

        /// <summary>
        /// Shows information about a specific type of rum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_RumSelectionEvent(object sender, EventArgs e)
        {
            string rumType = form1.comboBoxRumSelection.Text;

            if (form1.radioButtonShowHistory.Checked)
            {
                form1.textBoxAllText.Text = model.ShowRumHistory(rumType);
            }
            if (form1.radioButtonShowCoctails.Checked)
            {
                form1.textBoxAllText.Text = model.ShowRumCoctails(rumType);
            }
        }

        /// <summary>
        /// Show information about the developer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_ShowInfoEvent(object sender, EventArgs e)
        {
            model.ShowInformation();
        }
        #endregion
    }
}
