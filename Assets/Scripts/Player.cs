using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private float _bodyDelay = 0.5f;
    [SerializeField] private Transform _bodyTr = null;
    [SerializeField] private GameObject _head = null;
    [SerializeField] private GameObject _tailElement = null;

    [Space]
    [SerializeField] private float _shootForce = 20.0f;
    [SerializeField] private Projectile _projectile = null;

    private int _ammoCount = 0;
    private bool _isDead = false;
    private bool _allowBodyUpdate = false;
    private float _moveSpeed = 10f;
    private ParticleSystem _particleSystem = null;
    private PlayerController _playerController = null;
    private List<GameObject> _body = new List<GameObject>();
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

        _body.Add(_head);
    }
    private void Update()
    {
        return;

        if (_allowBodyUpdate)
        {
            BodyUpdate();
        }

        // to remove later
        if (Input.GetKeyDown(KeyCode.B))
            AddTailElement();
    }

    private void BodyUpdate()
    {
        for (int i = 1; i < _body.Count; ++i)
        {
            // test 2
            _body[i].transform.position = Vector3.Slerp(_body[i - 1].transform.position, _body[i].transform.position, _bodyDelay * Time.deltaTime);
        }
    }

    private void Kill()
    {
        _playerController.Stop();
        OnDeath.Invoke();
    }
    private void AddTailElement()
    {
        return;

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, _body[_body.Count - 1].transform.position.z - _distance);

        GameObject element = Instantiate(_tailElement, pos, Quaternion.identity);
        if (element == null)
        {
            Debug.LogError("Failed to instantiate element.");
            return;
        }

        element.transform.SetParent(_bodyTr);

        _body.Add(element);
    }

    private void CollectiblePicked(Collectible collectible)
    {
        collectible.Kill();

        ++_ammoCount;

        OnUpdateAmmo.Invoke(_ammoCount);

        _playerController.IncrementSpeed();
        AddTailElement();

        _particleSystem.Play();

        OnCollectiblePicked.Invoke();
    }
    public void BonusObstacleDestroyed()
    {
        _playerController.DecreaseSpeed(2f);
    }

    public void ShootProjectile()
    {
        --_ammoCount;
        if (_ammoCount <= 0)
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

        projectile.AddForce(Vector3.forward * _shootForce, ForceMode.Impulse);
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
