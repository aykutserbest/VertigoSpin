using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace VertigoSpin
{
    public class WheelUIController : MonoBehaviour
    { 
        private Transform _wheelTransform;
        private WheelController _controller;
        private List<CreatedWheelItem> _createdWheelItem;
        
        [SerializeField] private Transform wheelAreaContainer;
        [SerializeField] private GameObject spinButton;

        private WheelType _wheelType;
        private UIElementReferences _uiElementReferences;

        public void Initialize()
        {
            GetReference();
            DetectWheelType();
        }

        private void GetReference()
        {
            _uiElementReferences = GameModReferenceManager.Instance.UIElementReferences;
            _wheelType = GameModManager.Instance.GetCurrentWheelType();
            _controller = GetComponent<WheelController>();
        }

        private void DetectWheelType()
        {
            switch (_wheelType)
            {
                case WheelType.Bronze:
                    InstantiateWheel(_uiElementReferences.BronzeWheel);
                    GetWheelItem(WheelType.Bronze);
                    break;
                case WheelType.Silver:
                    InstantiateWheel(_uiElementReferences.SilverWheel);
                    GetWheelItem(WheelType.Silver);
                    break;
                case WheelType.Gold:
                    InstantiateWheel(_uiElementReferences.GoldWheel);
                    GetWheelItem(WheelType.Gold);
                    break;
            }
        }

        private void GetWheelItem(WheelType wheelType)
        { 
            _createdWheelItem = _controller.FillWheelItem(wheelType);
        }
        
        private void InstantiateWheel(GameObject wheel)
        {
            var wheelObj = Instantiate(wheel, wheelAreaContainer);
            _wheelTransform = wheelObj.transform;
            spinButton.SetActive(true);

            AddItemToWheel();
        }

        private void AddItemToWheel()
        {
            foreach (var item in _createdWheelItem)
            {
                
            }
        }

        void StartSpin()
        {
            var duration = 10f;
            var targetRotation = 45f;
            var finalRotation = new Vector3(0, 0, 360 * 5 + targetRotation);
            var wheelInitialRotation = _wheelTransform.eulerAngles.z;
            
            _wheelTransform.DORotate(finalRotation, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuart)
                .OnUpdate(() => {
                    
                })
                .OnComplete(() => {
                 //bitti eventi patlat
                });
        }
        
    }
}
