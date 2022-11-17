using UnityEngine;

namespace VertigoSpin
{
    public class UIReferenceManager : MonoBehaviour
    {
        public static UIReferenceManager Instance { get; private set; }

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
