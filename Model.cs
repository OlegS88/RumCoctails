using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RumCoctails
{
    /// <summary>
    /// Provides methods for finding inforvation about rum and coctails
    /// </summary>
    class Model
    {        
        static readonly HistoryOfRumEntities context = new HistoryOfRumEntities();
        readonly List<Coctails> coctails = context.Coctails.ToList();
        readonly List<Rums> rums = context.Rums.ToList();

        /// <summary>
        /// Returns the composition of the coctail in accordance with the name of the coctail
        /// </summary>
        /// <param name="coctailName">The name of the coctail for which you need to get the composition</param>
        /// <returns>Coctail composition</returns>
        internal string FindCoctailComposition(string coctailName)
        {
            foreach (var coctail in coctails)
            {
                    if (coctail.Name.ToLower() == coctailName.ToLower())
                    {
                    string coctailComposition = coctail.Ingredients;
                    return coctailComposition;
                    }
            }
            return null;
        }

        /// <summary>
        /// Checks the matching of the passed parameter to the template
        /// </summary>
        /// <param name="coctailName">The name of the coctail for which you need to get the composition</param>
        /// <returns>Coctail name</returns>
        internal string CoctailNameValidation(string coctailName)
        {
            string patternCoctailsName = @"^[А-Я а-я]+$";

            if (Regex.IsMatch(coctailName, patternCoctailsName))
            {
                return coctailName;
            }
            else
            {
                return null;
            }
        }
       
        /// <summary>
        /// Returns the histiry of rum in accordance with the given parameter
        /// </summary>
        /// <param name="rumType">Type of rum to wich you want to display history</param>
        /// <returns>Information aboun rum</returns>
        internal string ShowRumHistory(string rumType)
        {
            string rumHistory = null;

            foreach (var rum in rums)
            {
                if (rum.Type == rumType)
                    rumHistory = rum.History;

            }
            return rumHistory;
        }

        /// <summary>
        /// Returns all coctails based on this rum in accordance with the given parameter
        /// </summary>
        /// <param name="rumType">Type of rum to wich you want to display coctails</param>
        /// <returns>Coctail list</returns>
        internal string ShowRumCoctails(string rumType)
        {
            string listOfCoctails = null;
            int coctailNumber = 0;

            foreach (var rum in rums)
            {
                if (rum.Type == rumType)
                {
                    foreach (var coctail in coctails)
                    {
                        if (rum.Id == coctail.RumType)
                        {
                            coctailNumber++;
                            listOfCoctails += coctailNumber + ". " + coctail.Name + Environment.NewLine;
                        }
                    }
                }
            }
            return listOfCoctails;
        }

        /// <summary>
        /// Show information about the developer
        /// </summary>
        internal void ShowInformation()
        {
            MessageBox.Show("This program is written by Oleg Sergienko\n" +
                "tel: +38-093-552-87-29\n" +
                "email: sergienko_oleg_@ukr.net", "Version 1.0");
        }
    }
}
