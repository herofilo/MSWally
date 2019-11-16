using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWally.UI;

namespace MSWally
{
    public partial class WallAlterForm : Form
    {
        private WallSetting _wallSetting = WallSetting.None;

        public decimal IncrementValue { get; private set; } = 0.0M;

        // ------------------------------------------------

        public WallAlterForm(WallSetting pWallSetting)
        {
            _wallSetting = pWallSetting;
            InitializeComponent();
        }

        private void WallAlterForm_Load(object sender, EventArgs e)
        {
            tbWarning.Visible = false;
            switch (_wallSetting)
            {
                case WallSetting.Height: 
                    this.Text = "Increase/Decrease Wall Height";
                    lblText.Text = "Modify Wall Height by:";
                    nudIncrement.DecimalPlaces = 0;
                    nudIncrement.Minimum = -3.0M;
                    nudIncrement.Increment = 1.0M;
                    nudIncrement.Maximum = 3.0M;
                    tbWarning.Visible = true;
                    break;
                case WallSetting.Thickness:
                    this.Text = "Increase/Decrease Wall Thickness";
                    lblText.Text = "Modify Wall Thickness by:";
                    nudIncrement.DecimalPlaces = 1;
                    nudIncrement.Minimum = -0.3M;
                    nudIncrement.Increment = 0.1M;
                    nudIncrement.Maximum = 0.3M;
                    break;
                case WallSetting.StartZOffset:
                case WallSetting.EndZOffset:
                    string formText = "Increase/Decrease Wall Start Z-Offset";
                    string labelText = "Modify Wall Start Z-Offset by:";
                    if (_wallSetting == WallSetting.EndZOffset)
                    {
                        formText = "Increase/Decrease Wall End Z-Offset";
                        labelText = "Modify Wall End Z-Offset by:";
                    }
                    this.Text = formText;
                    lblText.Text = labelText;
                    nudIncrement.DecimalPlaces = 1;
                    nudIncrement.Minimum = -3.0M;
                    nudIncrement.Increment = 1.0M;
                    nudIncrement.Maximum = 3.0M;
                    break;
                default:
                    lblText.Text = "(Invalid setting to modify)";
                    pbUpdate.Enabled = false;
                    break;
            }
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void pbUpdate_Click(object sender, EventArgs e)
        {
            decimal value = nudIncrement.Value;
            if ((value < nudIncrement.Minimum) || (value > nudIncrement.Maximum))
                return;

            IncrementValue = value;
            DialogResult = DialogResult.OK;
        }
    }
}
