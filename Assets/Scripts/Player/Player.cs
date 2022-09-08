using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _shootForce = 20.0f;
    [SerializeField] private Projectile _projectile = null;

    [Space, Header("SFX")]
    [SerializeField] private AudioSource _source = null;
    [SerializeField] private AudioClip _audioDeath = null;
    [SerializeField] private AudioClip _collectiblePicked = null;
    [SerializeField] private AudioClip _bonusObstacle = null;
    [SerializeField] private AudioClip _shootAudio = null;

    private int _ammoCount = 0;
    private bool _allowBodyUpdate = false;
    private ParticleSystem _particleSystem = null;
    private PlayerController _playerController = null;
    #endregion

    #region Properties
    public bool AllowBodyUpdate
    {
        get { return _allowBodyUpdate; }
        set { _allowBodyUpdate = value; }
    }
    #endregion

    #region Events
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent<int> OnUpdateAmmo = new UnityEvent<int>();
    public UnityEvent OnDeath = new UnityEvent();
    public UnityEvent OnCollectiblePicked = new UnityEvent();
    public UnityEvent OnShoot = new UnityEvent();
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
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
        #endif
    }

    public void Kill()
    {
        GetComponent<Collider>().enabled = false;

        _source.PlayOneShot(_audioDeath);
        _playerController.Stop();
        OnDeath.Invoke();
    }

    private void CollectiblePicked()
    {
        ++_ammoCount;

        OnUpdateAmmo.Invoke(_ammoCount);

        _playerController.IncrementSpeed();

        _particleSystem.Play();
        _source.PlayOneShot(_collectiblePicked);

        OnCollectiblePicked.Invoke();
    }
    public void BonusObstacleDestroyed(float divider)
    {
        _source.PlayOneShot(_bonusObstacle);
        _playerController.DecreaseSpeed(divider);
    }

    public void ShootProjectile()
    {
        --_ammoCount;
        if (_ammoCount < 0)
        {
            Debug.LogWarning("No More Ammo !");
            _ammoCount = 0;

            OnUpdateAmmo.Invoke(_ammoCount);

            return;
        }

        OnUpdateAmmo.Invoke(_ammoCount);

        Projectile projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        if (projectile == null)
        {
            Debug.LogError("Failed to Instantiate Projectile.");
            return;
        }

        OnShoot.Invoke();

        _source.PlayOneShot(_shootAudio);
        projectile.AddForce(transform.forward * _shootForce, ForceMode.Impulse);
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
            Debug.Log("collectible!");

            Destroy(other.gameObject);
            CollectiblePicked();
        }
    }
    #endregion
}
