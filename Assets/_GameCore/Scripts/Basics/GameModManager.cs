using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    public class GameModManager : MonoBehaviour
    {
        public static GameModManager Instance { get; private set; }
        
        private GameModReferenceManager _gameModReference;
        private WheelGameUIManager _wheelGameUIManager;
        private WheelController _wheelController;
        
        private int _currentLevel=2;
        
        private void Awake()
        {
            GetReferences();

            Initialize();
        }
        
        public void Initialize()
        {
            CreateInstance();
            
            GetReferences();

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
