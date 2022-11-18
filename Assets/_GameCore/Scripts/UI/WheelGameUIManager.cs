using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    public class WheelGameUIManager : MonoBehaviour
    {
        private WheelUIController _wheelUIController;
        private LevelUIController _levelUIController;
        private GameOverPanelController _gameOverPanelController;
        
        public void Initialize()
        {
            GetReferences();
            
            _levelUIController.Initialize();
            _wheelUIController.Initialize();
            _gameOverPanelController.Initialize();
        }

        public void Run()
        {
          
        }
        
        public void Restart()
        {
            _gameOverPanelController.Initialize();
            _wheelUIController.NextLevel();
        }
        
        private void GetReferences()
        {
            _levelUIController = GameModReferenceManager.Instance.UILevelController;
            _wheelUIController = GameModReferenceManager.Instance.UIWheelController;
            _gameOverPanelController = GameModReferenceManager.Instance.UIGameOverPanelController;
        }
    }
}
