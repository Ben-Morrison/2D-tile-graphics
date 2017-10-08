using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.IO;

namespace GameEngine2D
{
    public partial class Editor : Form
    {
        Engine engine;
        private bool saved = false;

        public static EditorBrush Brush;
        private Point lastClickedPos;

        public Editor()
        {
            InitializeComponent();

            Brush = new EditorBrush(BrushType.Select);
            engine = new Engine(EditorPanel, true);

            InitControls();
        }

        // Event handlers
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.Uninitialize();
        }

        private void EditorPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                DoBrush(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                lastClickedPos = new Point(e.X, e.Y);

            UpdateControls(e);
        }

        private void EditorPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                DoBrush(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (Engine.StateManager.EngineState == EngineState.GameRunning && Engine.game.GetCurrentRoom() != null)
                {
                    Engine.Camera.Move(lastClickedPos.X - e.X, lastClickedPos.Y - e.Y);
                    lastClickedPos = new Point(e.X, e.Y);
                    Draw();
                }
            }

            UpdateControls(e);
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            if (Engine.game == null)
            {
                CreateNewGameDialog();
            }
            else if (Engine.game != null && !saved)
            {
                DialogResult result = MessageBox.Show("Do you want to save the current Game?", "Save", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    engine.SaveGame(Engine.DataManager.Path);
                    engine.CloseGame();
                    CreateNewGameDialog();
                }

                if (result == DialogResult.No)
                {
                    engine.CloseGame();
                    CreateNewGameDialog();
                }
            }
            else if(Engine.game != null && saved)
            {
                engine.CloseGame();
                CreateNewGameDialog();
            }

            Draw();
        }

        private void CreateNewGameDialog()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "New Game";
            dialog.Filter = "Game Files (*.gm)|*.gm";
            dialog.InitialDirectory = Application.StartupPath;
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;

                if (File.Exists(path))
                {
                    bool overwrite = dialog.OverwritePrompt;

                    if (overwrite)
                    {
                        engine.CloseGame();
                        engine.NewGame(path, true);
                    }
                }
                else
                {
                    engine.NewGame(path, true);
                }
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (Engine.game == null)
            {
                CreateOpenGameDialog();
            }
            else if (Engine.game != null && !saved)
            {
                DialogResult result = MessageBox.Show("Do you want to save the current Game?", "Save", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    engine.SaveGame(Engine.DataManager.Path);
                    engine.CloseGame();
                    CreateOpenGameDialog();
                }

                if (result == DialogResult.No)
                {
                    engine.CloseGame();
                    CreateOpenGameDialog();
                }
            }
            else if (Engine.game != null && saved)
            {
                engine.CloseGame();
                CreateOpenGameDialog();
            }

            Draw();
        }

        private void CreateOpenGameDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Game";
            dialog.Filter = "Game Files (*.gm)|*.gm";
            dialog.InitialDirectory = Application.StartupPath;
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;

                if (File.Exists(path))
                {
                    engine.CloseGame();
                    engine.OpenGame(path, true);
                }
                else
                {
                    engine.OpenGame(path, true);
                }
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            string path = "";
            engine.SaveGame(path);
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            engine.CloseGame();
        }

        private void menuTextures_Click(object sender, EventArgs e)
        {
            TextureForm form = new TextureForm(this, Brush);
            form.Show(this);
        }

        private void DoBrush(MouseEventArgs e)
        {
            if (Engine.StateManager.EngineState == EngineState.GameRunning)
            {
                if (Engine.game.GetCurrentRoom() != null)
                {
                    switch (Brush.BrushType)
                    {
                        case BrushType.Select:
                            break;
                        case BrushType.Move:
                            break;
                        case BrushType.Texture:
                            BrushHelper.DoTexture(Brush, e);
                            break;
                        case BrushType.Object:
                            break;
                        default:
                            break;
                    }

                    this.saved = false;
                    Draw();
                }
            }
        }

        private void InitControls()
        {
            statusMouse.Text = "Mouse X:0, Y:0";
            statusCamera.Text = "Camera X:0 Y:0";

            statusBrush.Text = "Brush Type: " + Brush.BrushType.ToString();
        }

        private void UpdateControls(MouseEventArgs e)
        {
            statusMouse.Text = "Mouse X:" + e.X.ToString() + ", Y:" + e.Y.ToString();

            if (Engine.Camera != null)
            {
                statusCamera.Text = "Camera X: " + Engine.Camera.Position.X.ToString() + " Y: " + Engine.Camera.Position.Y.ToString();
            }

            statusBrush.Text = "Brush Type: " + Brush.BrushType.ToString();
        }

        private void menuAddRoom_Click(object sender, EventArgs e)
        {
            if (Engine.game != null)
            {
                Engine.Camera.LookAt(0, 0);

                Room room = new Room(Default.DEFAULT_ROOM_SIZE_X, Default.DEFAULT_ROOM_SIZE_Y);
                Engine.game.AddRoom(room);
                Engine.game.SetCurrentRoom(0);

                Draw();
            }
        }

        private void Draw()
        {
            if (Engine.game != null && Engine.StateManager.EngineState == EngineState.GameRunning && Engine.game.GetCurrentRoom() != null)
            {
                engine.Draw();
            }
            else
            {
                EditorPanel.Invalidate();
            }
        }
    }
}
