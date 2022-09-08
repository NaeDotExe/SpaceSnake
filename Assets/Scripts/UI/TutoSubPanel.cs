using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoSubPanel : MonoBehaviour
{
    #region Attributes
    [SerializeField] private CanvasStart _canvasStart = null;
    #endregion

    #region Methods
    public void TutoComplete()
    {
        // to clean
        _canvasStart.TutoComplete();
    }
    #endregion
}
