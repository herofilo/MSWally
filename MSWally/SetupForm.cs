using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWally.Configuration;
using MSWally.Domain;

namespace MSWally
{
    public partial class SetupForm : Form
    {
        private ApplicationConfiguration _configuration;

        public ApplicationConfiguration NewConfiguration { get; private set; } = null;

        public SetupForm(ApplicationConfiguration pApplicationConfiguration)
        {
            _configuration = pApplicationConfiguration;
            InitializeComponent();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            if (_configuration == null)
            {
                pbSave.Enabled = false;
                return;
            }


            PresetValues();
            nudGraphTolerance.Value = _configuration.Tolerance;
            nudGraphWallThickness.Value = _configuration.WallPenWidth;
            nudWallHeightMin.Value = _configuration.HeightMinimum;
            nudWallHeightMax.Value = _configuration.HeightMaximum;
            nudWallThicknessMin.Value = _configuration.ThicknessMinimum;
            nudWallThicknessMax.Value = _configuration.ThicknessMaximum;
            nudWallZOffsetMax.Value = _configuration.ZOffsetMaximum;
        }



        private void PresetValues()
        {
            nudGraphTolerance.Minimum = 0.0M;
            nudGraphTolerance.Maximum = 3.0M;
            nudGraphTolerance.Increment = 1.0M;
            nudGraphTolerance.DecimalPlaces = 0;

            nudGraphWallThickness.Minimum = 1.0M;
            nudGraphWallThickness.Maximum = 4.0M;
            nudGraphWallThickness.Increment = 1.0M;
            nudGraphWallThickness.DecimalPlaces = 0;

            nudWallHeightMin.Minimum = Wall.HeightMinimumDefault - 1;
            nudWallHeightMin.Maximum = Wall.HeightMinimumDefault;
            nudWallHeightMin.Increment = 1.0M;
            nudWallHeightMin.DecimalPlaces = 0;

            nudWallHeightMax.Minimum = Wall.HeightMinimumDefault + 1;
            nudWallHeightMax.Maximum = Wall.HeightMaximumDefault * 3;
            nudWallHeightMax.Increment = 1.0M;
            nudWallHeightMax.DecimalPlaces = 0;

            nudWallThicknessMin.Minimum = Wall.ThicknessMinimumDefault;
            nudWallThicknessMin.Maximum = Wall.ThicknessMinimumDefault;
            nudWallThicknessMin.Increment = 0.1M;
            nudWallThicknessMin.DecimalPlaces = 1;
            nudWallThicknessMin.Enabled = false;

            nudWallThicknessMax.Minimum = Wall.ThicknessMinimumDefault + 0.1M;
            nudWallThicknessMax.Maximum = Wall.ThicknessMaximumDefault + 0.2M;
            nudWallThicknessMax.Increment = 0.1M;
            nudWallThicknessMax.DecimalPlaces = 1;

            nudWallZOffsetMax.Minimum = 0.0M;
            nudWallZOffsetMax.Maximum = Wall.ZOffsetMaximumDefault + 10;
            nudWallZOffsetMax.Increment = 1.0M;
            nudWallZOffsetMax.DecimalPlaces = 0;
        }


        private void pbSave_Click(object sender, EventArgs e)
        {
            if (!CheckOkValue(nudGraphTolerance))
                return;

            if (!CheckOkValue(nudGraphWallThickness))
                return;

            if (!CheckOkValues(nudWallHeightMin, nudWallHeightMax))
                return;

            if (!CheckOkValues(nudWallThicknessMin, nudWallThicknessMax))
                return;

            if (!CheckOkValue(nudWallZOffsetMax))
                return;

            NewConfiguration = new ApplicationConfiguration()
            {
                Tolerance = (int) nudGraphTolerance.Value,
                WallPenWidth = (int) nudGraphWallThickness.Value,
                HeightMinimum = nudWallHeightMin.Value,
                HeightMaximum = nudWallHeightMax.Value,
                ThicknessMinimum = nudWallThicknessMin.Value,
                ThicknessMaximum = nudWallThicknessMax.Value,
                ZOffsetMaximum = nudWallZOffsetMax.Value
            };
            
            DialogResult = DialogResult.OK;
        }

        private bool CheckOkValue(NumericUpDown pControl)
        {
            if ((pControl.Value < pControl.Minimum) || (pControl.Value > pControl.Maximum))
            {
                pControl.Focus();
                return false;
            }

            return true;
        }

        private bool CheckOkValues(NumericUpDown pControl0, NumericUpDown pControl1)
        {
            if (!CheckOkValue(pControl0) || !CheckOkValue(pControl1))
                return false;
            if (pControl0.Value >= pControl1.Value)
            {
                pControl0.Focus();
                return false;
            }

            return true;
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
