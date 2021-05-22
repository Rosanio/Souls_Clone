using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CheckpointPanel : Panel
    {
        protected override string selectedButtonColor
        {
            get { return "#191919"; }
        }

        protected override string unselectedButtonColor
        {
            get { return "#5A5A5A"; }
        }
    }
}
