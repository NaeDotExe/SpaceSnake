using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    #region Attributes
    [SerializeField] private GameObject _tailElement = null;

    private PlayerController _playerController = null;
    #endregion

    #region Properties

    #endregion

    #region Events
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();
    public UnityEvent OnCollectiblePicked = new UnityEvent();
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

    private void AddTailElement()
    {

    }
    private void Kill()
    {
        OnDeath.Invoke();
    }
    private void CollectiblePicked(Collectible collectible)
    {
        collectible.Kill();

        _playerController.IncrementSpeed();
        AddTailElement();

        OnCollectiblePicked.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
        Kill();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("REEEEEEEE");

        if (other.tag == "Collectible")
        {
            return;
        }

        Debug.Log("Collectible");

        Collectible collectible = other.gameObject.GetComponent<Collectible>();
        if (collectible == null)
        {
            Debug.LogError("No Component Collectible found!");
            return;
        }

        CollectiblePicked(collectible);
    }
}
