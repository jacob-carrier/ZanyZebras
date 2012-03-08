using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class GamePlayScreen : GameScreen
    {
        private GameInput input;
        private Zebra zebra1;
        private bool renderTileOutline = false;
        public bool RenderTileOutline
        {
            set
            {
                renderTileOutline = value;
            }
        }

        private bool showMouseText = false;
        public bool ShowMouseText
        {
            set
            {
                showMouseText = value;
            }
        }

        private static Level _levelInstance;
        public static Level LevelInstance
        {
            get
            {
                if (_levelInstance == null)
                {
                    throw new Exception("Level Instance is Null");
                }
                else
                {
                    return _levelInstance;
                }
            }
        }

        public GamePlayScreen()
        {
            Pause = false;
            Block = false;

            zebra1 = new Zebra(Game1.Instance.gameContent.Load<Texture2D>("Sprites/zebra_leftright"), 100, 100);
            _levelInstance = new Level();
            zebra1.addAnimation("right", new Animation(3, 64, 32, 0));
            zebra1.CurrentAnimation = "right";

            input = new GameInput(this, _levelInstance);
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
            zebra1.Update(gameTime);
            
        }

        public override void Render()
        {
            _levelInstance.Render();
            zebra1.Render();
            if (showMouseText)
            {
                FontManager.Instance.Render("Mouse Position X: " + input.MousePosition.X + " Mouse Position Y: " + input.MousePosition.Y, new Vector2(0, 16));
            }

            if (renderTileOutline)
            {
                Utils.Instance.drawTileOutline(_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40));
            }
        }
    }
}
