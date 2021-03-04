using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EquipmentWindowUI : MonoBehaviour
    {
        public bool rightHandSlot01Selected;
        public bool rightHandSlot02Selected;
        public bool rightHandSlot03Selected;
        public bool leftHandSlot01Selected;
        public bool leftHandSlot02Selected;
        public bool leftHandSlot03Selected;

        HandEquipmentSlotUI[] handEquipmentSlotUI;

        private void Start()
        {
            handEquipmentSlotUI = GetComponentsInChildren<HandEquipmentSlotUI>();
            PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
            LoadWeaponsOnEquipmentScreen(inventory);
        }

        public void LoadWeaponsOnEquipmentScreen(PlayerInventory playerInventory)
        {
            foreach(HandEquipmentSlotUI slot in handEquipmentSlotUI)
            {
                if (slot.rightHandSlot01)
                {
                    slot.AddItem(playerInventory.weaponsInRightHandSlots[0]);
                }
                else if (slot.rightHandSlot02)
                {
                    slot.AddItem(playerInventory.weaponsInRightHandSlots[1]);
                }
                else if (slot.rightHandSlot03)
                {
                    slot.AddItem(playerInventory.weaponsInRightHandSlots[2]);
                }
                else if (slot.leftHandSlot01)
                {
                    slot.AddItem(playerInventory.weaponsInLeftHandSlots[0]);
                }
                else if (slot.leftHandSlot02)
                {
                    slot.AddItem(playerInventory.weaponsInLeftHandSlots[1]);
                }
                else if (slot.leftHandSlot03)
                {
                    slot.AddItem(playerInventory.weaponsInLeftHandSlots[2]);
                }
            }
        }

        public void SelectRightHandSlot01()
        {
            rightHandSlot01Selected = true;
        }

        public void SelectRightHandSlot02()
        {
            rightHandSlot02Selected = true;
        }

        public void SelectRightHandSlot03()
        {
            rightHandSlot03Selected = true;
        }

        public void SelectLeftHandSlot01()
        {
            leftHandSlot01Selected = true;
        }

        public void SelectLeftHandSlot02()
        {
            leftHandSlot02Selected = true;
        }

        public void SelectLeftHandSlot03()
        {
            leftHandSlot03Selected = true;
        }
    }
}