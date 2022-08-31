using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    #region Attributes
    private PlayerController _playerController = null;
    #endregion

    #region Properties

    #endregion

    #region Events
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();
    #endregion

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        if (_playerController == null)
        {
            Debug.LogError("No Component PlayerController found.");
            return;
        }
    }
    private void Kill()
    {
        OnDeath.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Obstacle")
        {
            return;
        }

        Kill();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            return;
        }

        Collectible collectible = other.gameObject.GetComponent<Collectible>();
        if (collectible == null)
        {
            Debug.LogError("No Component Collectible found!");
            return;
        }

        _playerController.IncrementSpeed();
    }
}
