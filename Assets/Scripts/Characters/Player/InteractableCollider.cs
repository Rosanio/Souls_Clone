using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class InteractableCollider : MonoBehaviour
    {
        private PlayerManager playerManager;

        private void Awake()
        {
            playerManager = transform.parent.parent.GetComponent<PlayerManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.INTERACTABLE_TAG))
            {
                playerManager.AddInteractable(other.GetComponent<Interactable>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Constants.INTERACTABLE_TAG))
            {
                playerManager.RemoveInteractable(other.GetComponent<Interactable>());
            }
        }
    }
}
