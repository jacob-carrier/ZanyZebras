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
        private EntityManager entityManager;
        private GameInput input;
        private Zebra zebra1;
        private Random random;
        private bool renderTileOutline = false;
        public bool RenderTileOutline
        {
            set
            {
                renderTileOutline = value;
            }
        }

        private Level _levelInstance;
        public Level LevelInstance
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
            //Pause = false;
            //Block = false;
            random = new Random();
            int numZebras = random.Next(3, 10); 

            //zebra1 = new Zebra(Game1.Instance.gameContent.Load<Texture2D>("Sprites/zebra_leftright"), 100, 100);
            _levelInstance = new Level();
            //zebra1.addAnimation("right", new Animation(3, 64, 32, 0));
            //zebra1.addAnimation("left", new Animation(3, 64, 32, 1));
            //zebra1.CurrentAnimation = "right";
            input = new GameInput(this, _levelInstance);

            entityManager = new EntityManager(_levelInstance);

            for (int i = 0; i < numZebras; i++)
            {
                Zebra z = new Zebra(Game1.Instance.gameContent.Load<Texture2D>("Sprites/zebra_leftright"), 50, random.Next(0,500));
                z.addAnimation("right", new Animation(3, 64, 32, 0));
                z.addAnimation("left", new Animation(3, 64, 32, 1));
                z.CurrentAnimation = "right";
                entityManager.addEntity(z);
            }
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
            _levelInstance.Update(gameTime);
            Game1.Instance.GameAbilityBar.Update(gameTime);
            entityManager.Update(gameTime);

            for (int i = 0; i < entityManager.EntityList.Count; i++)
            {
                if (entityManager.EntityList[i].BoundingBox.X >= Game1.Instance.Window.ClientBounds.Width)
                {
                    entityManager.EntityList.RemoveAt(i);
                }
            }

            if (entityManager.EntityList.Count == 0)
            {
                Game1.Instance.ScreenManager.popScreen();
                Game1.Instance.ScreenManager.currentScreen().Pause = false;
            }
        }

        public override void Render()
        {
            _levelInstance.Render();
            entityManager.Render();
            Game1.Instance.GameAbilityBar.Render();
            if (renderTileOutline)
            {
                if (_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).Occupied && _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).Ability != null)
                {
                    Rectangle dest = new Rectangle(_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.X, _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.Y,
                        _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.Width ,
                        _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.Height);
                    Game1.Instance.SpriteBatch.Draw(Game1.Instance.gameContent.Load<Texture2D>("Sprites/outline"), dest, new Color(new Vector4(255, 0, 0, .2f)));
                    //Utils.Instance.drawTileOutline(_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40), new Vector4(255,0,0,.2f));
                }
                else
                {
                    if (input.SelectedAbility != null)
                    {
                        Rectangle dest = new Rectangle(_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.X, _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.Y,
                            _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.Width * input.SelectedAbility.XTiles,
                            _levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40).BoundingBox.Height * input.SelectedAbility.YTiles);
                        Game1.Instance.SpriteBatch.Draw(Game1.Instance.gameContent.Load<Texture2D>("Sprites/outline"), dest, new Color(new Vector4(0, 255, 0, .2f)));
                        //Utils.Instance.drawTileOutline(_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40), new Vector4(0, 255, 0, .2f));
                    }
                }
            }
        }
    }
}
