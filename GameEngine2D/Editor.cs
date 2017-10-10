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
        private Point cursorPos;
        private Point cursorLastPos;

        public Editor()
        {
            InitializeComponent();

            Brush = new EditorBrush(BrushType.Select);
            engine = new Engine(EditorPanel, true);

            InitControls();

            UpdateStatusStrip();
            UpdateTreeView();
            UpdateMenu();
            UpdateToolStrip();
        }

        private void InitControls()
        {
            statusMouse.Text = "Mouse X:0, Y:0";
            statusCamera.Text = "Camera X:0 Y:0";

            statusBrush.Text = "Brush Type: " + Brush.BrushType.ToString();
        }

        private void UpdateStatusStrip()
        {
            statusMouse.Text = "Mouse X:" + cursorPos.X.ToString() + ", Y:" + cursorPos.Y.ToString();

            if (Engine.Camera != null)
            {
                statusCamera.Text = "Camera X: " + Engine.Camera.Position.X.ToString() + " Y: " + Engine.Camera.Position.Y.ToString();
            }            

            statusBrush.Text = "Brush Type: " + Brush.BrushType.ToString();
        }

        private void UpdateTreeView()
        {
            TreeNode roomNode = treeGlobal.Nodes["treeGlobalRooms"];
            while (roomNode.Nodes.Count > 0)
                roomNode.Nodes[0].Remove();

            if (engine.IsGameOpen())
            {
                foreach (Room r in Engine.game.Rooms)
                {
                    TreeNode node = treeGlobal.Nodes["treeGlobalRooms"].Nodes.Add(r.Name);
                    node.ContextMenuStrip = contextMenuRoom;
                }

                roomNode.Expand();
            }
        }

        private void UpdateMenu()
        {
            if (engine.IsGameOpen())
            {
                menuSave.Enabled = true;
                menuSaveAs.Enabled = true;
                menuClose.Enabled = true;
                menuAddRoom.Enabled = true;
                menuTextures.Enabled = true;

                menuUndo.Enabled = true;
                menuRedo.Enabled = true;
                menuCopy.Enabled = true;
                menuCut.Enabled = true;
                menuPaste.Enabled = true;
                menuSelectAll.Enabled = true;

                contextMenuRoomsAdd.Enabled = true;

                if (Engine.game.Rooms.Count > 0)
                {
                    menuRemoveRoom.Enabled = true;
                    contextMenuRoomRemove.Enabled = true;
                } 
                else
                {
                    menuRemoveRoom.Enabled = false;
                    contextMenuRoomRemove.Enabled = false;
                }
            }
            else
            {
                menuSave.Enabled = false;
                menuSaveAs.Enabled = false;
                menuClose.Enabled = false;
                menuAddRoom.Enabled = false;
                menuTextures.Enabled = false;

                menuUndo.Enabled = false;
                menuRedo.Enabled = false;
                menuCopy.Enabled = false;
                menuCut.Enabled = false;
                menuPaste.Enabled = false;
                menuSelectAll.Enabled = false;

                contextMenuRoomsAdd.Enabled = false;

                menuRemoveRoom.Enabled = false;
                contextMenuRoomRemove.Enabled = false;
            }
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
            {
                cursorLastPos.X = e.X;
                cursorLastPos.Y = e.Y;
            }

            UpdateStatusStrip();
        }

        private void EditorPanel_MouseMove(object sender, MouseEventArgs e)
        {
            cursorPos.X = e.X;
            cursorPos.Y = e.Y;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                DoBrush(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (engine.IsGameOpen() && Engine.game.GetCurrentRoom() != null)
                {
                    Engine.Camera.Move(cursorLastPos.X - e.X, cursorLastPos.Y - e.Y);
                    Draw();
                }
            }

            cursorLastPos.X = e.X;
            cursorLastPos.Y = e.Y;

            UpdateStatusStrip();
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

            UpdateTreeView();
            UpdateStatusStrip();
            UpdateMenu();
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
                this.Text = "Editor - " + Path.GetFileNameWithoutExtension(path);

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

            UpdateTreeView();
            UpdateStatusStrip();
            UpdateMenu();
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
            bool success = engine.SaveGame(Engine.DataManager.Path);

            if (!success)
                MessageBox.Show("There was an error saving the game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save the current Game?", "Save", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                engine.SaveGame(Engine.DataManager.Path);
                engine.CloseGame();
            }

            if (result == DialogResult.No)
            {
                engine.CloseGame();
            }

            Draw();
            UpdateMenu();
            UpdateTreeView();
        }

        private void menuTextures_Click(object sender, EventArgs e)
        {
            TextureForm form = new TextureForm(this, Brush);
            form.ShowDialog(this);

            UpdateToolStrip();
        }

        private void DoBrush(MouseEventArgs e)
        {
            if (engine.IsGameOpen() && Engine.game.GetCurrentRoom() != null)
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

        private void menuAddRoom_Click(object sender, EventArgs e)
        {
            if (Engine.game != null)
            {
                NewRoom form = new NewRoom();
                this.AddOwnedForm(form);
                form.ShowDialog();
            }
        }

        public void AddRoom(string name, int x, int y)
        {
            Engine.Camera.LookAt(0, 0);

            Room room = new Room(name, x, y);
            Engine.game.AddRoom(room);
            Engine.game.SetCurrentRoom(Engine.game.Rooms.IndexOf(room));

            UpdateTreeView();
            UpdateMenu();

            Draw();
        }

        private void Draw()
        {
            if (engine.IsGameOpen() && Engine.game.GetCurrentRoom() != null)
            {
                engine.Draw();
            }
            else
            {
                EditorPanel.Invalidate();
            }
        }

        private void treeGlobal_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            TreeNode parent = node.Parent;

            treeGlobal.SelectedNode = node;

            // When a room is clicked on
            if (parent != null && parent.Name.Equals("treeGlobalRooms"))
            {
                int index = e.Node.Index;

                if (Engine.game.GetCurrentRoom() != Engine.game.Rooms[index])
                {
                    Engine.game.SetCurrentRoom(index);
                    Engine.Camera.LookAt(0, 0);

                    Draw();
                }
            }
        }

        private void contextMenuRoomRemove_Click(object sender, EventArgs e)
        {
            int index = treeGlobal.SelectedNode.Index;
            RemoveRoom(index);
        }

        private void RemoveRoom(int index)
        {
            if (Engine.game.Rooms.Count > 0)
            {
                Engine.game.DeleteRoom(Engine.game.Rooms[index]);

                Draw();
                UpdateMenu();
                UpdateTreeView();
                UpdateStatusStrip();
            }
        }

        private void menuRemoveRoom_Click(object sender, EventArgs e)
        {
            Room r = Engine.game.GetCurrentRoom();
            if(r != null)
                RemoveRoom(Engine.game.Rooms.IndexOf(r));
        }

        private void contextMenuRoomsAdd_Click(object sender, EventArgs e)
        {
            if (Engine.game != null)
            {
                NewRoom form = new NewRoom();
                this.AddOwnedForm(form);
                form.ShowDialog();
            }
        }

        private void toolSelect_Click(object sender, EventArgs e)
        {
            Brush.BrushType = BrushType.Select;
            UpdateStatusStrip();
            UpdateToolStrip();
        }

        private void toolMove_Click(object sender, EventArgs e)
        {
            Brush.BrushType = BrushType.Move;
            UpdateStatusStrip();
            UpdateToolStrip();
        }

        private void toolTexture_Click(object sender, EventArgs e)
        {
            Brush.BrushType = BrushType.Texture;
            UpdateStatusStrip();
            UpdateToolStrip();
        }

        private void toolObject_Click(object sender, EventArgs e)
        {
            Brush.BrushType = BrushType.Object;
            UpdateStatusStrip();
            UpdateToolStrip();
        }

        private void toolErase_Click(object sender, EventArgs e)
        {
            Brush.BrushType = BrushType.Erase;
            UpdateStatusStrip();
            UpdateToolStrip();
        }

        private void UpdateToolStrip()
        {
            toolSelect.Checked = false;
            toolMove.Checked = false;
            toolTexture.Checked = false;
            toolObject.Checked = false;
            toolErase.Checked = false;

            switch (Brush.BrushType)
            {
                case BrushType.Select:
                    toolSelect.Checked = true;
                    break;
                case BrushType.Move:
                    toolMove.Checked = true;
                    break;
                case BrushType.Texture:
                    toolTexture.Checked = true;
                    break;
                case BrushType.Object:
                    toolObject.Checked = true;
                    break;
                case BrushType.Erase:
                    toolErase.Checked = true;
                    break;
                default:
                    toolSelect.Checked = true;
                    break;
            }
        }
    }
}
