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

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonClick()
        {
            EventManager.SpinWheel();
        }
    }
}
