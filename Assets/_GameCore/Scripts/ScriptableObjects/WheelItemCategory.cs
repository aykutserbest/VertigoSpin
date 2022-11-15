using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    [CreateAssetMenu(menuName = "ScriptableObjects/WheelCategory", fileName = "WheelCategory")]
    public class WheelItemCategory : ScriptableObject
    {
        [SerializeField] private List<WheelItem> wheelItems;
        [SerializeField] private WheelItemCategoryEnum wheelItemCategoryEnum;

        public List<WheelItem> WheelItems => wheelItems;
        public WheelItemCategoryEnum ItemCategoryEnum => wheelItemCategoryEnum;
    }
    
    public enum WheelItemCategoryEnum{
        Bronze,
        Silver,
        Golden
    }
}
