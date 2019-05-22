using System;
using System.Windows.Forms;

namespace RumCoctails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Presenter(this);
        }

        #region Events
        EventHandler findCoctailEvent = null;
        EventHandler rumSelectionEvent = null;
        EventHandler showInfoEvent = null;

        /// <summary>
        /// Occurs when looking for a coctail
        /// </summary>
        public event EventHandler FindCoctailEvent
        {
            add { findCoctailEvent += value; }
            remove { findCoctailEvent -= value; }
        }

        /// <summary>
        /// Occurs when choosing a certain type of rum
        /// </summary>
        public event EventHandler RumSelectionEvent
        {
            add { rumSelectionEvent += value; }
            remove { rumSelectionEvent -= value; }
        }

        /// <summary>
        /// Occurs when showing the composition of the coctail
        /// </summary>
        public event EventHandler ShowInfoEvent
        {
            add { showInfoEvent += value; }
            remove { showInfoEvent -= value; }
        }
        #endregion

        #region Calling event-based methods
        private void ButtonFindCoctail_Click(object sender, EventArgs e)
        {
            findCoctailEvent.Invoke(sender, e);
        }

        private void ComboBoxRumSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            rumSelectionEvent.Invoke(sender, e);
        }

        private void RadioButtonShowHistory_CheckedChanged(object sender, EventArgs e)
        {
            rumSelectionEvent.Invoke(sender, e);
        }

        private void RadioButtonShowCoctails_CheckedChanged(object sender, EventArgs e)
        {
            rumSelectionEvent.Invoke(sender, e);
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInfoEvent(sender, e);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
