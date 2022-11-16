using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace VertigoSpin
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private Transform wheelTransform;
        void Start()
        {
            var duration = 10f;
            var targetRotation = 45f;
            var finalRotation = new Vector3(0, 0, 360 * 5 + targetRotation);
            var wheelInitialRotation = wheelTransform.eulerAngles.z;
            
            wheelTransform.DORotate(finalRotation, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuart)
                .OnUpdate(() => {
                    Debug.Log(wheelTransform.eulerAngles);
                })
                .OnComplete(() => {
                  Debug.Log("bitti");
                });
        }
        
    }
}
