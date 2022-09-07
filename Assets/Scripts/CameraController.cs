using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Transform _target = null;
    [SerializeField] private Vector3 _offset = Vector3.zero;

    private bool _canFollowTarget = true;
    #endregion

    #region Properties
    public bool CanFollowTarget
    {
        get { return _canFollowTarget; }
        set { _canFollowTarget = value; }
    }
    #endregion

    #region Methods
    private void Start()
    {
        if (_target == null)
        {
            Debug.LogError("Target is null!");
            return;
        }

        Vector3 pos = new Vector3(transform.position.x + _offset.x, transform.position.y, _target.position.z + _offset.z);

        transform.position = pos;
    }
    private void Update()
    {
        if (_canFollowTarget)
        {
            if (_target == null)
            {
                Debug.LogError("Target is null!");
                return;
            }

            Vector3 pos = new Vector3(transform.position.x, transform.position.y, _target.position.z + _offset.z);

            transform.position = pos;
        }
    }
    #endregion
}
