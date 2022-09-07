using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class PlatformTrigger : MonoBehaviour
{
    #region Attributes
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();

    private Collider _collider = null;
    #endregion

    #region Methods
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        if (_collider == null)
        {
            Debug.LogError("No Component Collider");
            return;
        }
    }

    private void Start()
    {
        foreach (Obstacle o in _obstacles)
        {
            o.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(Obstacle obstacle in _obstacles)
            {
                obstacle.gameObject.SetActive(true);
            }
        }
    }
    #endregion
}
