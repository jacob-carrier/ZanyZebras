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

        private AbilityBar abilityBar;
        public AbilityBar AbilityBar
        {
            get
            {
                return abilityBar;
            }
        }

        public GamePlayScreen()
        {
            Pause = false;
            Block = false;

            zebra1 = new Zebra(Game1.Instance.gameContent.Load<Texture2D>("Sprites/zebra_leftright"), 100, 100);
            _levelInstance = new Level();
            zebra1.addAnimation("right", new Animation(3, 64, 32, 0));
            zebra1.addAnimation("left", new Animation(3, 64, 32, 1));
            zebra1.CurrentAnimation = "right";

            input = new GameInput(this, _levelInstance);


            abilityBar = new AbilityBar(200, 400);
            abilityBar.setAbility(1, new Pit(new Vector2(200, 400)));

            entityManager = new EntityManager(_levelInstance);
            entityManager.addEntity(zebra1);
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
            entityManager.Update(gameTime);
            abilityBar.Update(gameTime);
        }

        public override void Render()
        {
            _levelInstance.Render();
            entityManager.Render();
            abilityBar.Render();
            if (showMouseText)
            {
                FontManager.Instance.Render("Mouse Position X: " + input.MousePosition.Y + " Mouse Position Y: " + input.MousePosition.Y, new Vector2(0, 16));
            }

            if (renderTileOutline)
            {
                Utils.Instance.drawTileOutline(_levelInstance.Grid.getCell((int)input.MousePosition.X / 40, (int)input.MousePosition.Y / 40));
            }
        }
    }
}
