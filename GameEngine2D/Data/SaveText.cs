using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Drawing.Imaging;

namespace GameEngine2D
{
    public class SaveText : ISave
    {
        public SaveClass LoadGame(FileStream file)
        {
            StreamReader reader = new StreamReader(file);

            try
            {
                Game g = new Game();
                Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

                // Number of textures
                int num = int.Parse(reader.ReadLine());

                // For each texture
                for (int i = 0; i < num; i++)
                {
                    string key = reader.ReadLine();
                    Texture value = StringToTexture(reader.ReadLine());

                    textures.Add(key, value);
                }

                // Number of rooms
                num = int.Parse(reader.ReadLine());

                // For each room
                for (int q = 0; q < num; q++)
                {
                    string name = reader.ReadLine();

                    int tile_x = int.Parse(reader.ReadLine());
                    int tile_y = int.Parse(reader.ReadLine());

                    Room r = new Room(name, tile_x, tile_y);

                    // For each tile
                    for (int j = 0; j < tile_y; j++)
                    {
                        for (int i = 0; i < tile_x; i++)
                        {
                            // For each layer
                            for (int f = 0; f < 2; f++)
                            {
                                string sourceTexture = reader.ReadLine();
                                string textureTypeS = reader.ReadLine();
                                TextureType textureType;

                                switch (textureTypeS)
                                {
                                    case "None":
                                        textureType = TextureType.None;
                                        break;
                                    case "Base":
                                        textureType = TextureType.Base;
                                        break;
                                    case "AutoTile":
                                        textureType = TextureType.AutoTile;
                                        break;
                                    case "Wall":
                                        textureType = TextureType.Wall;
                                        break;
                                    default:
                                        textureType = TextureType.None;
                                        break;
                                }

                                string animationTypeS = reader.ReadLine();
                                AnimationType animationType;

                                switch (animationTypeS)
                                {
                                    case "None":
                                        animationType = AnimationType.None;
                                        break;
                                    case "AutoTile":
                                        animationType = AnimationType.AutoTile;
                                        break;
                                    case "Waterfall":
                                        animationType = AnimationType.Waterfall;
                                        break;
                                    default:
                                        animationType = AnimationType.None;
                                        break;
                                }

                                int startX = int.Parse(reader.ReadLine());
                                int startY = int.Parse(reader.ReadLine());
                                int sizeX = int.Parse(reader.ReadLine());
                                int sizeY = int.Parse(reader.ReadLine());

                                Rectangle[] rects = new Rectangle[4];
                                for (int h = 0; h < 4; h++)
                                {
                                    int rect_x = int.Parse(reader.ReadLine());
                                    int rect_y = int.Parse(reader.ReadLine());
                                    int rect_size_x = int.Parse(reader.ReadLine());
                                    int rect_size_y = int.Parse(reader.ReadLine());

                                    rects[h] = new Rectangle(rect_x, rect_y, rect_size_x, rect_size_y);
                                }

                                GameTexture gameTexture = new GameTexture(sourceTexture, textureType, startX, startY, sizeX, sizeY, rects);
                                r.Tiles[i, j].SetLayer(f, (GameTexture)(gameTexture.Clone()));
                            }
                        }
                    }

                    g.AddRoom(r);
                }

                reader.Close();
                reader.Dispose();

                SaveClass save = new SaveClass(g, textures);
                return save;
            }
            catch (Exception e)
            {
                reader.Close();
                reader.Dispose();

                return null;
            }
        }

        public void SaveGame(FileStream file, SaveClass game)
        {
            StreamWriter writer = new StreamWriter(file);

            try
            {
                // Write textures
                writer.WriteLine(Engine.ContentManager.Textures.Count);

                foreach (KeyValuePair<string, Texture> t in Engine.ContentManager.Textures)
                {
                    writer.WriteLine(t.Key);
                    writer.WriteLine(TextureToString(t.Value));
                }

                // Save Game
                writer.WriteLine(Engine.game.Rooms.Count);

                // Room
                foreach (Room r in Engine.game.Rooms)
                {
                    writer.WriteLine(r.Name);

                    int x = r.Tiles.GetLength(0);
                    int y = r.Tiles.GetLength(1);

                    writer.WriteLine(x);
                    writer.WriteLine(y);

                    for (int j = 0; j < y; j++)
                    {
                        for (int i = 0; i < x; i++)
                        {
                            // Tile
                            Tile tile = r.Tiles[i, j];

                            //writer.WriteLine(tile.Position.X);
                            //writer.WriteLine(tile.Position.Y);

                            // Tile Layers
                            TileLayer layer1 = tile.Layers[0];
                            TileLayer layer2 = tile.Layers[1];

                            // GameTexture
                            writer.WriteLine(layer1.GameTexture.SourceTexture);
                            writer.WriteLine(layer1.GameTexture.TextureType.ToString());
                            writer.WriteLine(layer1.GameTexture.AnimationType.ToString());
                            writer.WriteLine(layer1.GameTexture.StartX);
                            writer.WriteLine(layer1.GameTexture.StartY);
                            writer.WriteLine(layer1.GameTexture.SizeX);
                            writer.WriteLine(layer1.GameTexture.SizeY);

                            for (int q = 0; q < 4; q++)
                            {
                                writer.WriteLine(layer1.GameTexture.Rects[q].X);
                                writer.WriteLine(layer1.GameTexture.Rects[q].Y);
                                writer.WriteLine(layer1.GameTexture.Rects[q].Width);
                                writer.WriteLine(layer1.GameTexture.Rects[q].Height);
                            }

                            // GameTexture
                            writer.WriteLine(layer2.GameTexture.SourceTexture);
                            writer.WriteLine(layer2.GameTexture.TextureType.ToString());
                            writer.WriteLine(layer2.GameTexture.AnimationType.ToString());
                            writer.WriteLine(layer2.GameTexture.StartX);
                            writer.WriteLine(layer2.GameTexture.StartY);
                            writer.WriteLine(layer2.GameTexture.SizeX);
                            writer.WriteLine(layer2.GameTexture.SizeY);

                            for (int q = 0; q < 4; q++)
                            {
                                writer.WriteLine(layer2.GameTexture.Rects[q].X);
                                writer.WriteLine(layer2.GameTexture.Rects[q].Y);
                                writer.WriteLine(layer2.GameTexture.Rects[q].Width);
                                writer.WriteLine(layer2.GameTexture.Rects[q].Height);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }

            writer.Close();
            writer.Dispose();
        }

        private string TextureToString(Texture t)
        {
            Bitmap b = ContentManager.TextureToBitmap(t);
            MemoryStream stream = new MemoryStream();
            b.Save(stream, ImageFormat.Png); 
            byte[] bytes = stream.GetBuffer();
            string s = Convert.ToBase64String(bytes, Base64FormattingOptions.None);

            return s;
        }

        private Texture StringToTexture(string s)
        {
            byte[] bytes = Convert.FromBase64String(s);
            MemoryStream stream = new MemoryStream(bytes);
            Image image = Image.FromStream(stream);
            Texture t = Texture.FromBitmap(Engine.DeviceManager.Device, new Bitmap(image), Usage.None, Pool.Managed);

            return t;
        }
    }
}
