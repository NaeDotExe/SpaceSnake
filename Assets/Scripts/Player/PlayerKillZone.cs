using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKillZone : MonoBehaviour
{
    #region Events
    public UnityEvent OnTriggered = new UnityEvent();
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnTriggered.Invoke();
        }
    }
    #endregion
}
