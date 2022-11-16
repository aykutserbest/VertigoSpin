using UnityEngine;

namespace VertigoSpin
{ 
    [CreateAssetMenu(menuName = "ScriptableObjects/WheelItem", fileName = "WheelItem")]
    public class WheelItem : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite sprite;
        [SerializeField] private int minAmount;
        [SerializeField] private int maxAmount;
        [SerializeField] private Rarity rarity;
        
        public string ItemName => itemName;
        public Sprite Sprite => sprite;
        public int MinAmount => minAmount;
        public int MaxAmount => maxAmount;
        public Rarity Rarity => rarity;
    }

    public enum Rarity
    {
        Common = 0,
        Rare = 1,
        Legendary = 2,
        Epic = 3,
        Special = 4,
        SubscriberOnly = 5
    }
}

