using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    #region Attributes
    [SerializeField] private GameObject _tailElement = null;

    private ParticleSystem _particleSystem = null;
    private PlayerController _playerController = null;
    #endregion

    #region Properties

    #endregion

    #region Events
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();
    public UnityEvent OnCollectiblePicked = new UnityEvent();
    #endregion

    #region Methods
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        if (_playerController == null)
        {
            Debug.LogError("No Component PlayerController found.");
            return;
        }

        _particleSystem = GetComponent<ParticleSystem>();
        if (_particleSystem == null)
        {
            Debug.LogError("No Component ParticleSystem found.");
            return;
        }
    }

    private void Kill()
    {
        _playerController.Stop();
        OnDeath.Invoke();
    }
    private void AddTailElement()
    {

    }
    private void CollectiblePicked(Collectible collectible)
    {
        collectible.Kill();

        _playerController.IncrementSpeed();
        AddTailElement();

        _particleSystem.Play();

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
        if (other.tag == "Collectible")
        {
            Collectible collectible = other.gameObject.GetComponent<Collectible>();
            if (collectible == null)
            {
                Debug.LogError("No Component Collectible found!");
                return;
            }

            CollectiblePicked(collectible);
        }
    }
    #endregion
}
