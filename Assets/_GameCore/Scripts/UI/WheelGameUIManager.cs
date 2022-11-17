using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    public class WheelGameUIManager : MonoBehaviour
    {
        private WheelUIController _wheelUIController;
        private LevelUIController _levelUIController;
        
        public void Initialize()
        {
            GetReferences();
            
            _levelUIController.Initialize();
            _wheelUIController.Initialize();
        }

        public void Run()
        {
          
        }
        
        private void GetReferences()
        {
            _levelUIController = GameModReferenceManager.Instance.UILevelController;
            _wheelUIController = GameModReferenceManager.Instance.UIWheelController;
        }
    }
}
