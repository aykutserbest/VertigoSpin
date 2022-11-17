using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VertigoSpin
{
    public class WheelItemUIController : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;
        
        public void Initialize(Sprite sprite, int amount)
        {
            image.sprite = sprite;
            text.text = amount.ToString();
        }
    }
}
