using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : Obstacle
{
    #region Attributes
    [SerializeField] private bool _startMoveRight = false;
    [SerializeField] private float _moveSpeed = 5.0f;

    [Space]
    [SerializeField] private float _minX = -2f;
    [SerializeField] private float _maxX = 2f;

    private bool _allowMovement = /*false*/true;
    private bool _moveRight = true;
    #endregion

    #region Methods
    private void Start()
    {
        _allowMovement = true;
        _moveRight = _startMoveRight;
    }
    private void Update()
    {
        if (_allowMovement)
        {
            if (_moveRight)
            {
                Vector3 pos = transform.position;
                if (pos.x < _maxX)
                {
                    pos.x += Time.deltaTime * _moveSpeed;
                    transform.position = pos;
                    if (transform.position.x >= _maxX)
                    {
                        _moveRight = false;
                    }
                }
            }
            else
            {
                Vector3 pos = transform.position;
                if (pos.x > _minX)
                {
                    pos.x -= Time.deltaTime * _moveSpeed;
                    transform.position = pos;
                    if (transform.position.x <= _minX)
                    {
                        _moveRight = true;
                    }
                }
            }
        }
    }
    public override void Kill()
    {
        base.Kill();
    }

    private void OnDrawGizmos()
    {
        Vector3 min = new Vector3(_minX, transform.position.y, transform.position.z);
        Vector3 max = new Vector3(_maxX, transform.position.y, transform.position.z);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(min, 0.2f);
        Gizmos.DrawSphere(max, 0.2f);
        Gizmos.DrawLine(min, max);
    }
    #endregion
}
