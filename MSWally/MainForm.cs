// #define TESTING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWally.Configuration;
using MSWally.Domain;
using MSWally.UI;
using MSWally.Utils;

namespace MSWally
{
    public partial class MainForm : Form
    {
        private ApplicationConfiguration _configuration;

        private string _moviesPath;

        private MovieDescriptor _movieDescriptor = null;

        private WorldGraph _worldGraph;

        private string _lastDirectory;

        private ToolTip _formToolTip;

        // --------------------------------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = $@"Wally - The Moviestorm's Wall Hacking Tool     (version {Utils.Utils.GetExecutableVersion()})";

            InitializationChores();
        }

        private void InitializationChores()
        {
            SetToolTips();

            LoadConfiguration();

#if TESTING
            _moviesPath = @"C:\Users\Jesus\Moviestorm\!Modelling\! Devel\MSWally\TestData";
#else
            _moviesPath = Utils.Utils.GetMoviestormMoviesFolder();
#endif
            opdMoviescopeLoad.InitialDirectory = _lastDirectory = _moviesPath;
        }

        private void SetToolTips()
        {
            _formToolTip = new ToolTip();
            _formToolTip.SetDefaults();

            // Sets up the ToolTip text for the Button and Checkbox.

            // formToolTip.SetToolTip(this, "Press F1 for help");

            _formToolTip.SetToolTip(pnlWorld, "Click for selecting a wall");
            _formToolTip.SetToolTip(dgvWalls, "Right-click for menu");
            _formToolTip.SetToolTip(cbCreateBackup, "Automatically create a backup of the original file");
            _formToolTip.SetToolTip(pbSetup, "Adjust settings of the application");
            _formToolTip.SetToolTip(pbRestore, "Restore original file from backup and reload");
            _formToolTip.SetToolTip(pbDeleteBackup, "Delete any backup file");
        }


        // -----------------------------------------------------------------------------------------------------------------------


        private void LoadConfiguration()
        {
            
            if (!File.Exists(ApplicationConfiguration.ConfigurationFilePath))
            {
                CreateAndSaveNewConfiguration();
                return;
            }

            string errorText;
            _configuration = ApplicationConfiguration.Load(out errorText);
            if (_configuration == null)
            {
                CreateAndSaveNewConfiguration();
                return;
            }

            ApplyConfiguration();
        }




        private void CreateAndSaveNewConfiguration()
        {
            string errorText;
            _configuration = new ApplicationConfiguration();
            _configuration.Save(ApplicationConfiguration.ConfigurationFilePath, out errorText);
        }


        private void ApplyConfiguration()
        {
            WorldGraph.Tolerance = _configuration.Tolerance;
            WorldGraph.WallPenWidth = _configuration.WallPenWidth;

            Wall.HeightMinimum = _configuration.HeightMinimum;
            Wall.HeightMaximum = _configuration.HeightMaximum;
            Wall.ThicknessMinimum = _configuration.ThicknessMinimum;
            Wall.ThicknessMaximum = _configuration.ThicknessMaximum;
            Wall.ZOffsetMaximum = _configuration.ZOffsetMaximum;

            RedrawWorld();
        }


        // ----------------------------------------------------------------------------------------------------------------------

        private void pbLoadMovie_Click(object sender, EventArgs e)
        {
            opdMoviescopeLoad.InitialDirectory = _lastDirectory;
            opdMoviescopeLoad.FileName = "";
            if (opdMoviescopeLoad.ShowDialog(this) != DialogResult.OK)
                return;

            string fileName = opdMoviescopeLoad.FileName;

            LoadMovieDescriptor(fileName);
        }


        private bool LoadMovieDescriptor(string pPath)
        {
            if (string.IsNullOrEmpty(pPath = pPath.Trim()))
            {
                MessageBox.Show("Invalid path specification", "Error", MessageBoxButtons.OK);
                return false;
            }

            _lastDirectory = Path.GetDirectoryName(pPath);

            string errorText;
            MovieDescriptor movieDescriptor = MovieDescriptor.Load(pPath, out errorText);
            if (movieDescriptor == null)
            {
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK);
                return false;
            }

            if ((movieDescriptor.Scenes?.Count ?? 0) == 0)
            {
                MessageBox.Show("No scenes defined in movie!", "Error", MessageBoxButtons.OK);
                return false;
            }

            lblMovie.ForeColor = Color.Black;
            tbMovieName.Text = movieDescriptor.MovieName;
            _formToolTip.SetToolTip(tbMovieName, movieDescriptor.FilePath);

            cbSceneSelector.Items.Clear();

            foreach (Scene scene in movieDescriptor.Scenes)
            {
                cbSceneSelector.Items.Add(scene.SceneTitle);
            }

            cbSceneSelector.SelectedIndex = 0;

            _movieDescriptor = movieDescriptor;

            RefreshSceneUIData();

            string backupFilename = _movieDescriptor.GetBackupFilename();
            pbRestore.Enabled = pbDeleteBackup.Enabled = File.Exists(backupFilename);

            tbLog.Clear();
            tbLog.AppendText($"Movie description file loaded: {_movieDescriptor.FilePath}\n");
            tbLog.AppendText($"    Scenes found: {_movieDescriptor.Scenes.Count}\n");
            if(pbRestore.Enabled)
                tbLog.AppendText("    Backup file found\n");
            return true;
        }



        private void RefreshWallTable()
        {
            dgvWalls.AutoGenerateColumns = false;

            if ((_movieDescriptor == null) || (cbSceneSelector.SelectedIndex < 0) || (_movieDescriptor.Scenes == null) || (cbSceneSelector.SelectedIndex > _movieDescriptor.Scenes.Count - 1))
            {
                dgvWalls.DataSource = null;
                return;
            }

            Scene scene = _movieDescriptor.Scenes[cbSceneSelector.SelectedIndex];


            BindingSource source = null;
            if ((scene.SetWalls?.Count ?? 0) > 0)
            {
                var bindingList = new SortableBindingList<Wall>(scene.SetWalls);
                source = new BindingSource(bindingList, null);
            }

            dgvWalls.DataSource = source;


        }

        private void dgvWalls_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvWalls.RowCount == 0)
                return;

            Scene scene = _movieDescriptor.Scenes[cbSceneSelector.SelectedIndex];
            for (int index = 0; index < scene.SetWalls.Count; ++index)
            {
                if (!scene.SetWalls[index].Dirty)
                    continue;
                if (scene.SetWalls[index].HeightModified)
                    dgvWalls.Rows[index].Cells["colHeight"].Style.ForeColor = Color.Red;

                if (scene.SetWalls[index].ThicknessModified)
                    dgvWalls.Rows[index].Cells["colThickness"].Style.ForeColor = Color.Red;

                if (scene.SetWalls[index].StartZOffsetModified)
                    dgvWalls.Rows[index].Cells["colStartZOffs"].Style.ForeColor = Color.Red;

                if (scene.SetWalls[index].EndZOffsetModified)
                    dgvWalls.Rows[index].Cells["colEndZOffs"].Style.ForeColor = Color.Red;


            }

        }

        private void dgvWalls_SelectionChanged(object sender, EventArgs e)
        {
            RedrawWorld();
        }


        private void RedrawWorld()
        {
            if (_worldGraph == null)
                return;
            List<int> selectedIndexes = new List<int>();
            for (int index = 0; index < dgvWalls.RowCount; ++index)
            {
                if (dgvWalls.Rows[index].Selected)
                    selectedIndexes.Add(index);
            }

            _worldGraph.RedrawWorld(selectedIndexes);
        }



        // -----------------------------------------------------------------------------------------------------------------

        private void cmWallTableMenu_Opening(object sender, CancelEventArgs e)
        {
            if ((_movieDescriptor == null) || (dgvWalls.RowCount <= 0))
                e.Cancel = true;

            if (dgvWalls.SelectedRows.Count == 0)
                e.Cancel = true;
        }


        private void cmiWallModHeight_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            WallSetting wallSetting = WallSetting.None;
            if (item == cmiWallModHeight)
                wallSetting = WallSetting.Height;
            else if (item == cmiWallModThickness)
                wallSetting = WallSetting.Thickness;
            else if (item == cmiWallModStartZ)
                wallSetting = WallSetting.StartZOffset;
            else if (item == cmiWallModEndZ)
                wallSetting = WallSetting.EndZOffset;
            else
                return;

            WallAlterForm form = new WallAlterForm(wallSetting);
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            decimal incrementValue = form.IncrementValue;
            if (incrementValue == 0.0M)
                return;

            Scene scene = _movieDescriptor.Scenes[cbSceneSelector.SelectedIndex];

            for (int index = 0; index < dgvWalls.RowCount; ++index)
            {
                if (dgvWalls.Rows[index].Selected)
                {
                    scene.SetWalls[index].ModifySetting(wallSetting, incrementValue);
                }
            }

            if (scene.Dirty)
                lblMovie.ForeColor = Color.Red;

            RefreshWallTable();
        }


        private void cmiWallSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvWalls.Rows)
                row.Selected = true;
        }


        // -------------------------------------------------------------------------------------------------------------------

        private void cbSceneSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSceneUIData();
        }


        private void RefreshSceneUIData()
        {
            if ((_movieDescriptor == null) || ((_movieDescriptor.Scenes?.Count ?? 0) == 0))
                return;

            Scene scene = _movieDescriptor.Scenes[cbSceneSelector.SelectedIndex];

            string estimated = scene.SetDimEstimated ? " (estimated)" : "";
            lblSetSize.Text = $"{scene.SetWidth}x{scene.SetDepth}{estimated}";

            int sceneCount = _movieDescriptor.Scenes.Count;
            if (sceneCount == 1)
                lblSceneCount.Visible = false;
            else
            {
                lblSceneCount.Text = $"({sceneCount} scenes)";
                lblSceneCount.Visible = true;
            }
            
            RefreshWallTable();

            _worldGraph = new WorldGraph(pnlWorld, scene);
            _worldGraph.RedrawWorld(new List<int>() { 0 });
            if(!_worldGraph.CanDraw)
                tbLog.AppendText($"NOTE: Scene set can't be represented: {_worldGraph.CantDrawReason}\n");
        }



        private void pnlWorld_MouseClick(object sender, MouseEventArgs e)
        {
            if (_worldGraph == null)
                return;

            int x = e.X;
            int y = e.Y;

            int index = _worldGraph.SelectWall(x, y);
            if ((index < 0) || (index > dgvWalls.RowCount))
                return;

            dgvWalls.Rows[index].Selected = true;
        }

        // --------------------------------------------------------------------------------------------------------

        private void pbSaveMovie_Click(object sender, EventArgs e)
        {
            if (_movieDescriptor == null)
                return;

            string errorText;
            if (!cbCreateBackup.Checked)
            {
                if (MessageBox.Show("Overwrite file. Please confirm...", "Saving file", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes)
                    return;
            }
            else
            {
                string backupFilename;
                if (!_movieDescriptor.BackupOriginal(out backupFilename, out errorText))
                {
                    MessageBox.Show($"Error creating backup file ({backupFilename}) : {errorText}", "Error", MessageBoxButtons.OK);
                    return;
                } else if (backupFilename != null)
                {
                    tbLog.AppendText($"Backup file created at {backupFilename}");
                }

                pbRestore.Enabled = pbDeleteBackup.Enabled = true;
            }

            if (!_movieDescriptor.Save(_movieDescriptor.FilePath, out errorText))
            {
                MessageBox.Show(errorText, "Save Error", MessageBoxButtons.OK);
                tbLog.AppendText($"Saving Error: {errorText}\n");
            }

            lblMovie.ForeColor = Color.Black;
            _movieDescriptor.SetClean();

            RefreshWallTable();
        }

        private void pbSaveAs_Click(object sender, EventArgs e)
        {
            if (_movieDescriptor == null)
                return;

            sfdMoviescopeSave.InitialDirectory = _lastDirectory;
            sfdMoviescopeSave.FileName = Path.GetFileName(_movieDescriptor.FilePath);
            if (sfdMoviescopeSave.ShowDialog(this) != DialogResult.OK)
                return;

            string errorText;
            if (!_movieDescriptor.Save(sfdMoviescopeSave.FileName, out errorText))
            {
                MessageBox.Show(errorText, "Save Error", MessageBoxButtons.OK);
                tbLog.AppendText($"Saving Error: {errorText}\n");
            }

            LoadMovieDescriptor(sfdMoviescopeSave.FileName);

            // lblMovie.ForeColor = Color.Black;
            // _movieDescriptor.SetClean();

            // RefreshWallTable();
        }


        private void pbRestore_Click(object sender, EventArgs e)
        {
            if (_movieDescriptor == null)
                return;

            string backupFilename = _movieDescriptor.GetBackupFilename();
            
            if (!File.Exists(backupFilename))
            {
                MessageBox.Show("Backup file not found", "Error", MessageBoxButtons.OK);
                tbLog.AppendText("Error while restoring: Backup file not found\n");
                return;
            }

            if (MessageBox.Show("Restore original file. Please confirm...", "Confirmation", MessageBoxButtons.YesNo) !=
                DialogResult.Yes)
                return;

            try
            {
                File.Copy(backupFilename, _movieDescriptor.FilePath, true);
            }
            catch (Exception exception)
            {
                string errorText = $"Error while restoring: {exception.Message}";
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK);
                tbLog.AppendText($"{errorText}\n");
                return;
            }

            if(LoadMovieDescriptor(_movieDescriptor.FilePath))
                tbLog.AppendText("Movie description file restored and reloaded.\n");
        }

        private void pbDeleteBackup_Click(object sender, EventArgs e)
        {
            if (_movieDescriptor == null)
                return;

            string backupFilename = _movieDescriptor.GetBackupFilename();
            if (!File.Exists(backupFilename))
            {
                MessageBox.Show("Backup file not found", "Error", MessageBoxButtons.OK);
                return;
            }

            try
            {
                File.Delete(backupFilename);
                pbRestore.Enabled = pbDeleteBackup.Enabled = false;
            }
            catch (Exception exception)
            {
                string errorText = $"Error while deleting backup file: {exception.Message}";
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK);
                tbLog.AppendText($"{errorText}\n");
            }
        }


        // ------------------------------------------------------------------------------------------------------

        private void pbSetup_Click(object sender, EventArgs e)
        {
            SetupForm form = new SetupForm(_configuration);
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            _configuration = form.NewConfiguration;

            string errorText;
            _configuration.Save(ApplicationConfiguration.ConfigurationFilePath, out errorText);

            ApplyConfiguration();
        }


    }
}
