using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Attributes
    [SerializeField] private ParticleSystem _system = null;
    #endregion

    #region Methods
    public void Spawn()
    {
        // play anim
    }
    public virtual void Kill()
    {
        StartCoroutine(KillCoroutine());
    }
    private IEnumerator KillCoroutine()
    {
        _system.Play();

        // to clean
        //FindObjectOfType<GameManager>().ObstacleDestroyed();

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
    #endregion
}
