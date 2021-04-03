using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial {
    public class HolderSlot : MonoBehaviour
    {
        public Transform parentOverride;
        public GameObject itemModel;

        protected void LoadItemModel(Item item)
        {
            GameObject model = Instantiate(item.modelPrefab);
            if (model != null)
            {
                if (parentOverride != null)
                {
                    model.transform.parent = parentOverride;
                }
                else
                {
                    model.transform.parent = transform;
                }

                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;
            }

            itemModel = model;
        }

        public void UnloadItemModel()
        {
            if (itemModel != null)
            {
                itemModel.SetActive(false);
            }
        }

        public void UnloadItemModelAndDestroy()
        {
            if (itemModel != null)
            {
                Destroy(itemModel);
            }
        }
    }
}
