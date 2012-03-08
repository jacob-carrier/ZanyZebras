using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Zany_Zebras
{
    class StoreInput : Input
    {
        public StoreInput()
        {

        }

        public override void Update()
        {
            newState = Mouse.GetState();


            oldState = newState;
        }
    }
}
