using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VertigoSpin
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private List<CreatedWheelItem> selectedItems;
        [SerializeField] private List<CreatedWheelItem> rewardedItems;

        private int _rewardIndex;
        private CreatedWheelItem _reward;

        public int RewardIndex => _rewardIndex;

        public CreatedWheelItem Reward => _reward;

        public List<CreatedWheelItem> RewardedItems => rewardedItems;

        public void Initialize()
        {
           
        }

        public List<CreatedWheelItem> FillWheelItem(WheelType wheelType)
        {
            ClearItemLists(selectedItems);
            var containerList = GameModReferenceManager.Instance.WheelContainers;

            foreach (var container in containerList)
            {
                if (container.WheelType == wheelType)
                {
                    SelectItems(container, wheelType);
                    SelectReward();
                }
            }

            return selectedItems;
        }

        private void ClearItemLists(List<CreatedWheelItem> createdWheelItemList)
        {
            createdWheelItemList.Clear();  
        }
        

        private void SelectItems(WheelItemContainer container, WheelType selectedWheelType)
        {
            var slotAmount = 8;
            
            if (selectedWheelType == WheelType.Bronze)
            {
                SelectBombItem(container);
                
                if (selectedItems.Count > 0) 
                    slotAmount--;
            }
            
            var bombExcludedItems = container.WheelItems.Where(x=>x.wheelItem is not BombWheelItem).ToList();
            
            for (int i = 0; i < slotAmount; i++)
            {
                var selectedItemIndex = Random.Range (1, bombExcludedItems.Count);
                var selectedItem = bombExcludedItems[selectedItemIndex];
                var selectedItemAmount =
                    Random.Range(selectedItem.wheelItem.MinAmount, selectedItem.wheelItem.MaxAmount);
                selectedItems.Add(new CreatedWheelItem(selectedItem.wheelItem,selectedItem.dropRate,selectedItemAmount));
            }
            Shuffle(selectedItems);
            
        }
        
        private void SelectBombItem(WheelItemContainer container)
        {
            var bomb = container.WheelItems.First(x=>x.wheelItem is BombWheelItem);
            if (bomb.wheelItem!=null)
            {
                selectedItems.Add(new CreatedWheelItem(bomb.wheelItem,bomb.dropRate,1));
            }
        }
        
        private void SelectReward()
        {
            ArrayList dropList = new ArrayList();
            float drawn = Random.Range(0f, 100f);

            foreach (var item in selectedItems)
            {
                if (drawn <= item.dropRate)
                {
                    dropList.Add(item);
                }
            }

            var index = Random.Range(0, dropList.Count);
            _reward = selectedItems[index];
            rewardedItems.Add(_reward);
            _rewardIndex = selectedItems.IndexOf(_reward);
            
            Debug.Log($"reward:{_reward.wheelItem.name} {_rewardIndex}");
        }
        
        private void Shuffle<T>(IList<T> ts) {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i) {
                var r = Random.Range(i, count);
                (ts[i], ts[r]) = (ts[r], ts[i]);
            }
        }

        public void RewardedItemsLists()
        {
            ClearItemLists(rewardedItems);
        }
    }
    
    [Serializable]
    public class CreatedWheelItem
    {
        public CreatedWheelItem(WheelItem wheelItem, int dropRate, int amount)
        {
            this.wheelItem = wheelItem;
            this.dropRate = dropRate;
            this.amount = amount;
        }
        
        public WheelItem wheelItem;
        public int dropRate;
        public int amount;
    }
}
