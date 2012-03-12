using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class EntityManager
    {
        private List<Zebra> entities;
        private Level levelInstance;

        private EntityManager _instance;
        public EntityManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public EntityManager(Level level){
            _instance = this;
            entities = new List<Zebra>();
            levelInstance = level;
        }

        public void addEntity(Zebra z)
        {
            entities.Add(z);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Zebra z in entities)
            {
                z.Update(gameTime);
                Console.WriteLine("Center X: " + z.Center.X + " Center Y: " + z.Center.Y);
                if (levelInstance.Grid.getCell(z.Center.X / 40, z.Center.Y / 40).Occupied)
                {
                    if (z.BoundingBox.Intersects(levelInstance.Grid.getCell(z.Center.X / 40, z.Center.Y / 40).BoundingBox))
                    {
                        // Do stuff with the ability AbillityEvent function that takes a zebra
                        levelInstance.Grid.getAbility(z.Center.X / 40, z.Center.Y / 40).gameEvent(z);
                        Console.WriteLine("Zebra intersected");
                    }
                }
            }
        }

        public void Render()
        {
            foreach (Zebra z in entities)
            {
                z.Render();
            }
        }
    }
}
