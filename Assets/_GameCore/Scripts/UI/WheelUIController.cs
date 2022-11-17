using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace VertigoSpin
{
    public class WheelUIController : MonoBehaviour
    { 
        private Transform _wheelBaseTransform;
        private Transform _wheelTransform;
        private WheelController _controller;
        private List<CreatedWheelItem> _createdWheelItem;
        
        [SerializeField] private GameObject spinButton;
        [SerializeField] private GameObject wheelItemBasePrefab;

        private WheelType _wheelType;
        private UIReferenceManager _uiReferenceManager;

        public void Initialize()
        {
            GetReference();
            DetectWheelType();
            
            EventManager.OnSpinWheel += OnSpinWheel;
        }

        private void OnDisable()
        {
            EventManager.OnSpinWheel -= OnSpinWheel;
        }

        private void OnSpinWheel()
        {
            StartSpin();
        }

        private void GetReference()
        {
            _uiReferenceManager = UIReferenceManager.Instance;
            _wheelType = GameModManager.Instance.GetCurrentWheelType();
            _controller = GetComponent<WheelController>();
        }

        private void DetectWheelType()
        {
            switch (_wheelType)
            {
                case WheelType.Bronze:
                    GetWheelItem(WheelType.Bronze);
                    InstantiateWheel(_uiReferenceManager.BronzeWheel);
                    break;
                
                case WheelType.Silver:
                    GetWheelItem(WheelType.Silver);
                    InstantiateWheel(_uiReferenceManager.SilverWheel);
                    break;
                
                case WheelType.Gold:
                    GetWheelItem(WheelType.Gold);
                    InstantiateWheel(_uiReferenceManager.GoldWheel);
                    break;
            }
        }

        private void GetWheelItem(WheelType wheelType)
        { 
            _createdWheelItem = _controller.FillWheelItem(wheelType);
        }
        
        private void InstantiateWheel(GameObject wheel)
        {
            var wheelObj = Instantiate(wheel, transform);
            _wheelBaseTransform = wheelObj.transform;
            _wheelBaseTransform.SetAsFirstSibling();
            spinButton.SetActive(true);

            AddItemToWheel();
        }

        private WheelSlotController _wheelSlotController;

        private void AddItemToWheel()
        {
            _wheelSlotController = _wheelBaseTransform.GetComponentInChildren<WheelSlotController>();
            _wheelSlotController.Initialize();
            _wheelTransform = _wheelSlotController.WheelTransform;

            for (var index = 0; index < _wheelSlotController.Slots.Length; index++)
            {
                var slot = _wheelSlotController.Slots[index];
                var wheelItemGO = Instantiate(wheelItemBasePrefab, slot);
                wheelItemGO.GetComponent<WheelItemUIController>().Initialize(_createdWheelItem[index].wheelItem.Sprite,
                    _createdWheelItem[index].amount);
            }
        }

        private bool _isSpiningEnable;
        
        private void StartSpin()
        {
            if (_isSpiningEnable) return;
            
            _isSpiningEnable = true;
            
            var duration = 10f;
            var targetRotation = _controller.RewardIndex * 45f;
            var finalRotation = new Vector3(0, 0, 360 * 5 + targetRotation);
            
            _wheelTransform.DORotate(finalRotation, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuart)
                .OnComplete(() =>
                {
                    Complete();
                });
        }

        private void Complete()
        {
            EventManager.SpinWheelCompleted();
            Restart();
            _isSpiningEnable = false;
        }

        private void Restart()
        {
            Destroy(_wheelBaseTransform.gameObject);
            _wheelType = GameModManager.Instance.GetCurrentWheelType();
            DetectWheelType();
        }
    }
}
