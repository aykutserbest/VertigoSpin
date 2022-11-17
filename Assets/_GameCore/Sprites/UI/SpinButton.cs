using UnityEngine;
using UnityEngine.UI;

namespace VertigoSpin
{
    public class SpinButton : MonoBehaviour
    {
        private Button _button;

        private void OnValidate()
        {
            _button = GetComponent<Button>();
        }

        public void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        
        private void OnButtonClick()
        {
            _button.onClick.RemoveAllListeners();
            
            EventManager.SpinWheel();
        }
    }
}
