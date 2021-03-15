using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class WeaponPickup : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(PlayerManager playerManager)
        {
            PickUpItem(playerManager);
        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerInventory playerInventory = playerManager.GetComponent<PlayerInventory>();
            PlayerLocomotion playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            PlayerAnimatorHandler animatorHandler = playerManager.GetComponentInChildren<PlayerAnimatorHandler>();

            playerLocomotion.rigidbody.velocity = Vector3.zero; //Stops the player from moving while picking up the item
            animatorHandler.PlayTargetAnimation("Pick Up", true);
            playerInventory.weaponsInInventory.Add(weapon);
            playerManager.itemInteractableGameObject.GetComponentInChildren<Text>().text = weapon.itemName;
            playerManager.itemInteractableGameObject.SetActive(true);
            GameObject.Find("ItemIcon").GetComponent<Image>().sprite = weapon.itemIcon;
            playerManager.confirmUIGameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
