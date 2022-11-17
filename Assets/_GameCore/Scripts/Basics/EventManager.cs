using System;
using UnityEngine;

namespace VertigoSpin
{
    public class EventManager : MonoBehaviour
    {
        public static event Action OnSpinWheel;

        public static void SpinWheel()
        {
            OnSpinWheel?.Invoke();
        }
        
        public static event Action OnSpinWheelCompleted;

        public static void SpinWheelCompleted()
        {
            OnSpinWheelCompleted?.Invoke();
        }
    }
}