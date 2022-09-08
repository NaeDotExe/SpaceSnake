using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    #region Attributes
    //[SerializeField] private float _delayBeforeSpawningObstacles = 0.5f;
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();
    #endregion

    #region Methods
    private void Start()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.gameObject.SetActive(false);
        }
    }
    public void ShowObstacles()
    {
        if (_obstacles.Count == 0)
        {
            return;
        }

        StartCoroutine(ShowObstaclesCoroutine());
    }

    private IEnumerator ShowObstaclesCoroutine()
    {
        //yield return new WaitForSeconds(_delayBeforeSpawningObstacles);
        yield return new WaitForEndOfFrame();

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
