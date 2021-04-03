using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class Item : ScriptableObject
    {
        public GameObject modelPrefab;

        [Header("ItemInformation")]
        public Sprite icon;
        public string itemName;
    }
}
