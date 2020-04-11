using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    public interface IGameLogic
    {
        void MoveDrill();
        void CollectingMoney();
        void Upgrading();
        void AddGold();

        // These are just notes for myself to remember what methods should be created later on.
        bool reachGround();
        // methods for collision check

    }
}
