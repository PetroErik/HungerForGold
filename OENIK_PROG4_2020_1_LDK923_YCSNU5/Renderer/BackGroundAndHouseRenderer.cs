// <copyright file="BackGroundAndHouseRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using System.Windows;
    using System.Windows.Media;
    using HFG.Display;

    /// <summary>
    /// Renderer for background and houses.
    /// </summary>
    public class BackGroundAndHouseRenderer
    {
        /// <summary>
        /// Starting point of the drill.
        /// </summary>
        public double StartingPointToDrill;

        /// <summary>
        /// DrawExtension instance for the help of rendering.
        /// </summary>
        public DrawExtension DrawExntension;

        /// <summary>
        /// Drawing group for ground and house.
        /// </summary>
        public DrawingGroup GroundAndHouseGroup;

        private GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackGroundAndHouseRenderer"/> class.
        /// </summary>
        /// <param name="model">GameModel instance.</param>
        public BackGroundAndHouseRenderer(GameModel model)
        {
            this.model = model;
            this.DrawExntension = new DrawExtension(model.TileSize, model.TileSize);
            this.GroundAndHouseGroup = new DrawingGroup();
            this.StartingPointToDrill = (model.GameHeight / 2) - (model.TileSize * 4);
            this.GroundAndHouseGroup.Children.Add(this.GetBackground());
            this.GroundAndHouseGroup.Children.Add(this.GetGround());
            this.GroundAndHouseGroup.Children.Add(this.GetSilo());
            this.GroundAndHouseGroup.Children.Add(this.GetMachinist());
        }

        /// <summary>
        /// Cloning background.
        /// </summary>
        /// <returns>Returns the copy of the background.</returns>
        public DrawingGroup BackGroundClone()
        {
            DrawingGroup clone = new DrawingGroup();
            foreach (var draw in this.GroundAndHouseGroup.Children)
            {
                clone.Children.Add(draw);
            }

            return clone;
        }

        private Drawing GetGround()
        {
            DrawingGroup ground = new DrawingGroup();
            GeometryGroup groupGound = new GeometryGroup();
            GeometryGroup groupGoundLevel = new GeometryGroup();

            int numOfGroundLevel = (CONFIG.MapHeight / 3) + 1;
            for (int i = 0; i < CONFIG.MapWidth * 2; i++)
            {
                Geometry groundLevelBox = new RectangleGeometry(new Rect(i * this.model.TileSize, numOfGroundLevel * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                groupGoundLevel.Children.Add(groundLevelBox);

                for (int j = (CONFIG.MapHeight / 3) + 2; j < CONFIG.MapHeight; j++)
                {
                    Geometry box = new RectangleGeometry(new Rect(i * this.model.TileSize, j * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                    groupGound.Children.Add(box);
                }
            }

            Drawing oldGround = new GeometryDrawing(this.DrawExntension.GroundBrush, null, groupGound);
            Drawing oldGroundLevel = new GeometryDrawing(this.DrawExntension.GroundLevelBrush, null, groupGoundLevel);

            ground.Children.Add(oldGround);

            ground.Children.Add(oldGroundLevel);

            return ground;
        }

        private Drawing GetMachinist()
        {
            return this.DrawExntension.DrawBoxObject(this.model.MachinistHouse.Location[0], this.model.MachinistHouse.Location[1], this.model.TileSize * 3, this.model.TileSize * 5, this.DrawExntension.MachinistBrush);
        }

        private Drawing GetSilo()
        {
            return this.DrawExntension.DrawBoxObject(this.model.SiloHouse.Location[0], this.model.SiloHouse.Location[1], this.model.TileSize * 3, this.model.TileSize * 5, this.DrawExntension.SiloBrush);
        }

        private Drawing GetBackground()
        {
            return this.DrawExntension.DrawBoxObject(0, 0, this.model.GameWidth, this.model.GameHeight, this.DrawExntension.BackgroundBrush);
        }
    }
}
