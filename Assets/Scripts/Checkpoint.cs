using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class Checkpoint : Interactable
    {
        public Transform respawnPosition;

        public override void Interact(PlayerManager playerManager)
        {
            playerManager.Rest(respawnPosition);
        }
    }
}

