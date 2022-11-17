using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    [CreateAssetMenu(menuName = "ScriptableObjects/UIElementRefences", fileName = "UIElementRefences")]
    public class UIElementReferences : ScriptableObject
    {
        [SerializeField] private Sprite safeZoneBG;
        [SerializeField] private Sprite superZoneBG;
        
        [SerializeField] private GameObject bronzeWheel;
        [SerializeField] private GameObject silverWheel;
        [SerializeField] private GameObject goldWheel;

        public Sprite SafeZoneBg => safeZoneBG;

        public Sprite SuperZoneBg => superZoneBG;

        public GameObject BronzeWheel => bronzeWheel;

        public GameObject SilverWheel => silverWheel;

        public GameObject GoldWheel => goldWheel;
    }
}
