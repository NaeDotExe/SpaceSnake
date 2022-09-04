using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class KillZone : MonoBehaviour
{
    #region Attributes
    private Collider _collider = null;
    #endregion

    #region Properties

    #endregion

    #region Events
    public UnityEvent<GameObject> OnPlatformDestroyed = new UnityEvent<GameObject>();
    #endregion

    #region Methods
    private void Start()
    {
        _collider = GetComponent<Collider>();
        if (_collider == null)
        {
            Debug.LogError("Collider is null.");
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject);

        if (other.tag == "Platform")
        {
            OnPlatformDestroyed.Invoke(other.gameObject);

            Destroy(other.gameObject);
        }
    }
    #endregion
}
