using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    [CreateAssetMenu(menuName = "ScriptableObjects/WheelContainer", fileName = "WheelContainer")]
    public class WheelItemContainer : ScriptableObject
    {
        [SerializeField] private List<WheelItemDropRatePairs> wheelItems;
        [SerializeField] private WheelType wheelType;

        public List<WheelItemDropRatePairs> WheelItems => wheelItems;

        public WheelType WheelType => wheelType;
    }
    
    public enum WheelType{
        Bronze,
        Silver,
        Gold
    }

    [Serializable]
    public struct WheelItemDropRatePairs
    {
        public WheelItem wheelItem;
        [Range(0, 100)] 
        public int dropRate;
    }
}
