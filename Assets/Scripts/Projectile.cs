using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _lifeTime = 3.0f;

    private Rigidbody _rigidBody = null;
    #endregion

    #region Methods
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        if (_rigidBody == null)
        {
            Debug.LogError("No Component RigidBody found!");
            return;
        }

        StartCoroutine(LifeTimeCoroutine());
    }

    public void AddForce(Vector3 force, ForceMode mode)
    {
        _rigidBody.AddForce(force, mode);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Obstacle")
        {
            return;
        }

        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
        if (obstacle == null)
        {
            Debug.Log("No Component Obstacle found.");
            return;
        }

        obstacle.Kill();
    }

    private IEnumerator LifeTimeCoroutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }
    #endregion
}
