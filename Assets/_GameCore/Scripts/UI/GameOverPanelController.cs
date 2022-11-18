using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoSpin
{
    public class GameOverPanelController : MonoBehaviour
    {
        public void Initialize()
        {
            HideGameOverPanel();
        }
        
        private void OnEnable()
        {
            EventManager.OnGameOver += ShowGameOverPanel;
        }

        private void OnDisable()
        {
            EventManager.OnGameOver -= ShowGameOverPanel;
        }
        
        private void ShowGameOverPanel()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }
        
        private void HideGameOverPanel()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }

        
    }
}
