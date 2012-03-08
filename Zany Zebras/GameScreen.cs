using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    public class GameScreen
    {
        private Boolean block;
        public Boolean Block
        {
            get
            {
                return block;
            }
            set
            {
                block = value;
            }
        }

        private Boolean pause;
        public Boolean Pause
        {
            get
            {
                return pause;
            }
            set
            {
                pause = value;
            }
        }

        public virtual void Render()
        {
        }
        public virtual void Update()
        {
        }
    }
}
