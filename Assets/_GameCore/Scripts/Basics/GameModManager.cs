using System;
using UnityEngine;

namespace VertigoSpin
{
    public class GameModManager : MonoBehaviour
    {
        public static GameModManager Instance { get; private set; }
        
        private GameModReferenceManager _gameModReference;
        private UIReferenceManager _uiReferenceManager;
        private WheelGameUIManager _wheelGameUIManager;
        private WheelController _wheelController;

        private int _currentLevel = 1;
        
        private void Awake()
        {
            CreateInstance();
            GetReferences();

            Initialize();
            
            EventManager.OnSpinWheelCompleted += OnSpinWheelCompleted;
        }

        private void OnDisable()
        {
            EventManager.OnSpinWheelCompleted -= OnSpinWheelCompleted;
        }

        private void OnSpinWheelCompleted()
        {
            _currentLevel++;
            
            _gameModReference.UILevelController.SlideLevelState();
        }

        private void Initialize()
        {
            GetReferences();
            
            _uiReferenceManager.Initialize();
            _wheelGameUIManager.Initialize();
            _wheelController.Initialize();
            
            Run();
        }
        
        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);
        }
        
        private void Run()
        {
            _wheelGameUIManager.Run();
        }
        
        private void GetReferences()
        {
            _gameModReference = GetComponent<GameModReferenceManager>();
            _gameModReference.Initialize();
            
            _uiReferenceManager = GetComponent<UIReferenceManager>();
            
            _wheelGameUIManager = _gameModReference.GameUIManager;
            _wheelController = _gameModReference.WheelController;
        }

        public WheelType GetCurrentWheelType()
        {
            var returnType = WheelType.Bronze;
            if (_currentLevel == 1 || _currentLevel % 5 == 0)
            {
                returnType = WheelType.Silver;
            }
            if (_currentLevel % 30 == 0)
            {
                returnType = WheelType.Gold;
            }
            return returnType;
        }
    }
}
