using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VertigoSpin
{
    public class RewardUIPoolController : MonoBehaviour
    {
        [SerializeField] private GameObject Container;

        [SerializeField] private List<GameObject> ContainerItemList;

        private float _slotYTransform;

        public void AddSlot(GameObject slot, CreatedWheelItem reward)
        {
            var newSlot = Instantiate(slot, Container.transform);
            newSlot.GetComponentInChildren<Image>().sprite = reward.wheelItem.Sprite;
            newSlot.GetComponentInChildren<TextMeshProUGUI>().text = reward.amount.ToString();

            ContainerItemList.Add(newSlot);

            var position = newSlot.transform.position;
            position = new Vector3(position.x, position.y + _slotYTransform, position.z);
            newSlot.transform.position = position;
            _slotYTransform -= 70f;
        }

        public void ClearContainerList()
        {
            foreach (var slot in ContainerItemList)
            {
                Destroy(slot);
            }

            ContainerItemList.Clear();
        }
    }
}
