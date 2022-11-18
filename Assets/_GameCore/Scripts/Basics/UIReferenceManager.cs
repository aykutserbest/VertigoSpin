using UnityEngine;

namespace VertigoSpin
{
    public class UIReferenceManager : MonoBehaviour
    {
        public static UIReferenceManager Instance { get; private set; }

        [SerializeField] private Sprite safeZoneBG;
        [SerializeField] private Sprite superZoneBG;
        
        [SerializeField] private GameObject rewardPoolSlotBase;
        [SerializeField] private GameObject rewardPoolItemBase;
        
        [SerializeField] private string bronzeWheel;
        [SerializeField] private string silverWheel;
        [SerializeField] private string goldWheel;

        public Sprite SafeZoneBg => safeZoneBG;

        public Sprite SuperZoneBg => superZoneBG;

        public string BronzeWheel => bronzeWheel;

        public string SilverWheel => silverWheel;

        public string GoldWheel => goldWheel;

        public GameObject RewardPoolSlotBase => rewardPoolSlotBase;

        public GameObject RewardPoolItemBase => rewardPoolItemBase;

        public void Initialize()
        {
            CreateInstance();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);
        }
    }
}
