using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    public class GameModReferenceManager : MonoBehaviour
    {
        public static GameModReferenceManager Instance { get; private set; }
        
        private WheelGameUIManager _wheelGameUIManager;
        
        [SerializeField] private LevelUIController uiLevelController;
        [SerializeField] private WheelUIController uiWheelController;
        [SerializeField] private UIElementReferences uiElementReferences;
        [SerializeField] private WheelController wheelController;
        
        [SerializeField] private List<WheelItemContainer> wheelContainers;
        
        public WheelUIController UIWheelController => uiWheelController;
        public LevelUIController UILevelController => uiLevelController;
        public WheelGameUIManager GameUIManager => _wheelGameUIManager;
        public UIElementReferences UIElementReferences => uiElementReferences;

        public WheelController WheelController => wheelController;

        public List<WheelItemContainer> WheelContainers => wheelContainers;


        public void Initialize()
        {
            CreateInstance();
            GetReferences();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);
        }

        private void GetReferences()
        {
            _wheelGameUIManager = GetComponent<WheelGameUIManager>();
        }
    }
}
