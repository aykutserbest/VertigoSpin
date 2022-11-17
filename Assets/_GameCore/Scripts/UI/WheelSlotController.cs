using UnityEngine;

namespace VertigoSpin
{
    public class WheelSlotController : MonoBehaviour
    {
        [SerializeField] private Transform[] slots;
        [SerializeField] private Transform wheelTransform;

        public Transform[] Slots => slots;

        public Transform WheelTransform => wheelTransform;

        public void Initialize()
        {
                
        }
    }
}