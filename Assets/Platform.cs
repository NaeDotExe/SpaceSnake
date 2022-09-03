using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _delayBeforeSpawningObstacles = 0.5f;

    [Space]
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();

    private bool _showObstacles = true;
    #endregion

    #region Properties
    public bool ShowObstacles
    {
        get { return _showObstacles; }
        set
        {
            if (_obstacles.Count == 0)
            {
                _showObstacles = false;
            }
            else
            {
                _showObstacles = value;
            }
        }
    }
    #endregion

    #region Methods
    private void Start()
    {
        if (_obstacles.Count == 0)
        {
            _showObstacles = true;
        }

        if (_showObstacles)
        {
            StartCoroutine(ShowObstaclesCoroutine());
        }
    }

    private IEnumerator ShowObstaclesCoroutine()
    {
        yield return new WaitForSeconds(_delayBeforeSpawningObstacles);

        foreach (Obstacle obstacle in _obstacles)
        {
            if (obstacle == null)
            {
                continue;
            }

            obstacle.gameObject.SetActive(true);
            obstacle.Spawn();
        }
    }
    #endregion
}
