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
        
        public int CurrentLevel => _currentLevel;
        
        private void Awake()
        {
            CreateInstance();
            GetReferences();

            Initialize();
            
            EventManager.OnSpinWheelCompleted += OnSpinWheelCompleted;
            EventManager.OnRestart += OnRestart;
        }

       

        private void OnDisable()
        {
            EventManager.OnSpinWheelCompleted -= OnSpinWheelCompleted;
            EventManager.OnRestart -= OnRestart;
        }

        private void OnSpinWheelCompleted()
        {
            _currentLevel = CurrentLevel + 1;
            
            _gameModReference.UILevelController.SlideLevelState();
        }
        
        private void OnRestart()
        {
            _currentLevel = 1;
            _gameModReference.UILevelController.ResetLevelState();
            _wheelGameUIManager.Restart();
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
            if (CurrentLevel == 1 || CurrentLevel % 5 == 0)
            {
                returnType = WheelType.Silver;
            }
            if (CurrentLevel % 30 == 0)
            {
                returnType = WheelType.Gold;
            }
            return returnType;
        }
    }
}
