using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VertigoSpin
{
    public class LevelUIController : MonoBehaviour
    {
        [SerializeField] private GameObject uiLevelContainer;
        
        [SerializeField] private GameObject uiLevelStatePrefab;

        [SerializeField] private int _currentLevel = 1;

        public void Initialize()
        {
            AddLevel();
        }

        private void AddLevel()
        {
            for (int i = 0; i < 30; i++)
            {
                var state = Instantiate(uiLevelStatePrefab, uiLevelContainer.transform);
                var stateLevelText = state.GetComponentInChildren(typeof(TextMeshProUGUI), false) as TextMeshProUGUI;
                if (stateLevelText != null) stateLevelText.text = _currentLevel.ToString();
                
                SelectZoneType(state);

                _currentLevel++;
            }
        }

        private void SelectZoneType(GameObject stateZone)
        {
            var instanceUIElementReferences = UIReferenceManager.Instance;
            if (_currentLevel == 1 || _currentLevel % 5 == 0)
            {
                stateZone.GetComponent<Image>().sprite =
                    instanceUIElementReferences.SafeZoneBg;
            }
            if (_currentLevel % 30 == 0)
            {
                stateZone.GetComponent<Image>().sprite =
                    instanceUIElementReferences.SuperZoneBg;
            }
        }

        private int _levelContainerCurrentPos = -119;

        public void SlideLevelState()
        {
            uiLevelContainer.transform.DOLocalMoveX(_levelContainerCurrentPos,0.5f);
            _levelContainerCurrentPos -= 119;
        }
    }
}
