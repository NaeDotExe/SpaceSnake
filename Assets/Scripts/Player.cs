using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _distance = 0.5f;
   public float t = 0.5f;


    [Space]
    [SerializeField] private GameObject _tailElement = null;

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

        _body.Add(gameObject);
    }
    private void Update()
    {
        if (_allowBodyUpdate)
        {
            BodyUpdate();
        }

        if (Input.GetKeyDown(KeyCode.B))
            AddTailElement();
    }

    private void BodyUpdate()
    {

        for (int i = 1; i < _body.Count; ++i)
        {
            //Transform currentPart = _body[i].transform;
            //Transform prevPart = _body[i - 1].transform;

            //float dis = Vector3.Distance(prevPart.position, currentPart.position);

            //Vector3 pos = prevPart.position;

            //pos.y = _body[0].transform.position.y;

            //float t = Time.deltaTime * dis / _distance * 10f;
            //if (t > 0.5f)
            //{
            //    t = 0.5f;
            //}

            //currentPart.position = Vector3.Slerp(currentPart.position, pos, t);

            _body[i].transform.position = Vector3.Slerp(_body[i - 1].transform.position, _body[i].transform.position, t * Time.deltaTime);
        }
    }

    private void Kill()
    {
        _playerController.Stop();
        OnDeath.Invoke();
    }
    private void AddTailElement()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, _body[_body.Count - 1].transform.position.z - _distance);

        GameObject element = Instantiate(_tailElement, pos, Quaternion.identity);
        if (element == null)
        {
            Debug.LogError("Failed to instantiate element.");
            return;
        }

        element.transform.SetParent(transform);

        _body.Add(element);
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
