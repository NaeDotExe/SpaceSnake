using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BloomToggler : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Volume _volume = null;
    #endregion

    #region Methods
    public void ToggleBloom(bool isOn)
    {
        _volume.enabled = isOn;
    }
    #endregion
}
