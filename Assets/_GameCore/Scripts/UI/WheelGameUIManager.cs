using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            EventManager.OnStartRewardItemMoveAnim += StartItemMove;
        }

        private void OnDisable()
        {
            EventManager.OnStartRewardItemMoveAnim -= StartItemMove;
        }

        private void StartItemMove(CreatedWheelItem reward, Vector3 startPos)
        {
            GameModReferenceManager.Instance.UIPoolController.AddSlot(UIReferenceManager.Instance.RewardPoolSlotBase,reward);
        }

        public void Run()
        {
          
        }
        
        public void Restart()
        {
            GameModReferenceManager.Instance.UIPoolController.ClearContainerList();
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
