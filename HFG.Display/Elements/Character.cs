using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HFG.Display
{
    /// <summary>
    /// Base class for every character type.
    /// </summary>
    public abstract class Character
    {
        /// <summary>
        /// Location of the character.
        /// </summary>
        public double[] Location { get; set; }
    }
}
