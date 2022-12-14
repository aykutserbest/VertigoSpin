using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace VertigoSpin
{
    public class WheelUIController : MonoBehaviour
    { 
        private Transform _wheelBaseTransform;
        private Transform _wheelTransform;
        private WheelController _controller;
        private List<CreatedWheelItem> _createdWheelItem;
        private GameObject _instantiateFirstWheelItemGameObject;
        
        [SerializeField] private GameObject spinButton;
        [SerializeField] private GameObject wheelItemBasePrefab;
        [SerializeField] private float duration = 2f;

        private WheelType _wheelType;
        private UIReferenceManager _uiReferenceManager;

        public void Initialize()
        {
            GetReference();
            DetectWheelType();

            spinButton.GetComponent<CanvasGroup>().alpha = 1;
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
        
        private void InstantiateWheel(string wheelAddressableName)
        {
            Instantiate(wheelAddressableName, transform).Completed += OnCompleted;
        }
        
        private List<AsyncOperationHandle> _loadedAddressableGameObjects = new();

        private AsyncOperationHandle<GameObject> Instantiate(string key, Transform parent)
        {
            var handle = Addressables.InstantiateAsync(key, parent);
            _loadedAddressableGameObjects.Add(handle);

            return handle;
        }
        
        private void OnCompleted(AsyncOperationHandle<GameObject> obj)
        {
            _wheelBaseTransform = obj.Result.transform;
            _wheelBaseTransform.SetAsFirstSibling();
            

            AddItemToWheel();
        }
        
        public void ClearLoadedGameObjects()
        {
            foreach (var handle in _loadedAddressableGameObjects)
            {
                if (handle.Result != null)
                {
                    Addressables.ReleaseInstance(handle);
                }
            }

            _loadedAddressableGameObjects.Clear();
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
                var WheelItemGameObject = Instantiate(wheelItemBasePrefab, slot);
                WheelItemGameObject.GetComponent<WheelItemUIController>().Initialize(_createdWheelItem[index].wheelItem.Sprite,
                    _createdWheelItem[index].amount);

                if (index==0)  _instantiateFirstWheelItemGameObject = WheelItemGameObject;
              
            }
        }

        private bool _isSpiningEnable;
        
        private void StartSpin()
        {
            if (_isSpiningEnable) return;
            
            _isSpiningEnable = true; 
            
            
            var targetRotation = _controller.RewardIndex * 45f;
            var finalRotation = new Vector3(0, 0, 360 * 5 + targetRotation);
            
            _wheelTransform.DORotate(finalRotation, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuart)
                .OnComplete(() =>
                {
                    if (_controller.Reward.wheelItem.name == "Bomb")
                    {
                        GameOver();
                    }
                    else
                    {
                        Complete();
                    }
                });
        }

        private void GameOver()
        {
            EventManager.GameOver();
            _isSpiningEnable = false;
            _controller.RewardedItemsLists();
        }

        private void Complete()
        {
            var itemAnimStartPos = _instantiateFirstWheelItemGameObject.transform.position;
            EventManager.StartRewardItemMoveAnim(_controller.Reward, itemAnimStartPos);
            
            EventManager.SpinWheelCompleted();
            NextLevel();
            _isSpiningEnable = false;
        }

        public void NextLevel()
        {
            //Destroy(_wheelBaseTransform.gameObject);
            ClearLoadedGameObjects();
            _wheelType = GameModManager.Instance.GetCurrentWheelType();
            DetectWheelType();
        }
    }
}
