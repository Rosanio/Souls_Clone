﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class ItemPickup : Interactable
    {
        public Item item;

        public override void Interact(PlayerManager playerManager)
        {
            playerManager.PickUpItem(item);
            Destroy(gameObject);
        }
    }
}
