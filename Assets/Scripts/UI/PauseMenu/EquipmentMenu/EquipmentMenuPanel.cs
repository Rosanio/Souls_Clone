using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EquipmentMenuPanel : Panel
    {

        protected override string selectedButtonColor
        {
            get { return "#5E5E5E"; }
        }

        protected override string unselectedButtonColor
        {
            get { return "#ffffff"; }
        }

        public EquipmentSlot GetSelectedSlot()
        {
            return (EquipmentSlot)currentlySelectedButton;
        }
    }
}
