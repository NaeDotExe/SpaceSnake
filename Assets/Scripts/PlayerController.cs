using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _multiplier = 1.1f;

    [Space]
    [SerializeField] private HUB _hub = null;

    private bool _isMovementAllowed = true;
    private float _currentSpeed = 0f;
    private float _xPosition = 0f;
    #endregion

    #region Properties
    public bool IsMovementAllowed
    {
        get { return _isMovementAllowed; }
        set { _isMovementAllowed = value; }
    }
    public float CurrentSpeed
    {
        get { return _currentSpeed; }
    }
    #endregion

    #region Methods
    private void Start()
    {
        _hub.OnSliderValueChanged.AddListener((float value) => _xPosition = value);

        _currentSpeed = _startSpeed;
    }
    private void Update()
    {
        if (_isMovementAllowed)
        {
            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        Vector3 pos = new Vector3(_xPosition, transform.position.y, transform.position.z + _currentSpeed * Time.deltaTime);

        transform.position  = pos;
    }

    public void IncrementSpeed()
    {
        _currentSpeed += _multiplier;
    }
    public void Stop()
    {
        _currentSpeed = 0;
        _isMovementAllowed = false;
    }
    #endregion
}
