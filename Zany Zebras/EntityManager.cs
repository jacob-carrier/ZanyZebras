using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class EntityManager
    {

        private float elapsedTime;
        private List<Zebra> entities;
        public List<Zebra> EntityList
        {
            get
            {
                return entities;
            }
        }
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
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(gameTime);
                Console.WriteLine("Center X: " + entities[i].Center.X + " Center Y: " + entities[i].Center.Y);
                if (levelInstance.Grid.getCell(entities[i].Center.X / 40, entities[i].Center.Y / 40).Occupied)
                {
                    if (entities[i].BoundingBox.Intersects(levelInstance.Grid.getCell(entities[i].Center.X / 40, entities[i].Center.Y / 40).BoundingBox) && levelInstance.Grid.getCell(entities[i].Center.X / 40, entities[i].Center.Y / 40).Ability != null)
                    {
                        // Do stuff with the ability AbillityEvent function that takes a zebra
                        levelInstance.Grid.getAbility(entities[i].Center.X / 40, entities[i].Center.Y / 40).gameEvent(entities[i]);
                        Console.WriteLine("Zebra intersected");
                    }

                    if (levelInstance.Grid.getCell(entities[i].Center.X / 40, entities[i].Center.Y / 40).Type == "Object")
                    {
                        Random random = new Random();
                       entities[i].Direction = new Vector2(0, random.Next(-2, 2));
                    }
                }

                if (entities[i].Health <= 0)
                {
                    entities.Remove(entities[i]);
                    Game1.Instance.StorePoints += 20;
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
