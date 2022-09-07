using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneVibration : MonoBehaviour
{
    public void Vibrate()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        Handheld.Vibrate();
#endif
    }
}
