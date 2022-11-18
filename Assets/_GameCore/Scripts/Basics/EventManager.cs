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
        
        public static event Action OnGameOver;

        public static void GameOver()
        {
            OnGameOver?.Invoke();
        }
        
        public static event Action OnRestart;

        public static void Restart()
        {
            OnRestart?.Invoke();
        }
        
        public static event Action<CreatedWheelItem, Vector3> OnStartRewardItemMoveAnim;
        public static void StartRewardItemMoveAnim(CreatedWheelItem reward, Vector3 startPos)
        {
            OnStartRewardItemMoveAnim?.Invoke(reward,startPos);
        }
        
    }
}