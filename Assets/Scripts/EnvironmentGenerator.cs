using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _startZ = 95f;

    [Space]
    [SerializeField] private float _distance = 10f;
    [SerializeField] private Transform _parent = null;
    [SerializeField] private KillZone _killZone = null;
    [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();

    private float _lastZ = 0f;
    #endregion

    #region Properties
    public float LastZ
    {
        get { return _lastZ; }
    }
    #endregion

    #region Methods
    private void Start()
    {
        _lastZ = _startZ;

        _killZone.OnPlatformDestroyed.AddListener((GameObject gao) => SpawnElement());
    }

    private void SpawnElement()
    {
        // change to pool

        int id = Random.Range(0, _prefabs.Count - 1);

        GameObject selectedPrefab = _prefabs[id];
        if (selectedPrefab == null)
        {
            Debug.LogError("Selected Prefab is null!");
            return;
        }

        Platform platform = Instantiate(selectedPrefab, _parent).GetComponent<Platform>();
        if (platform == null)
        {
            Debug.LogError("Failed to instantiate platform.");
            return;
        }

        bool showObstacles = false;
        int proba = Random.Range(0, 2);

        // 2/3 chances of having obstacles
        if (proba > 0)
        {
            showObstacles = true;
        }

        platform.transform.position = Vector3.forward * _lastZ;
        if (showObstacles)
        {
            platform.ShowObstacles();
        }

        _lastZ += _distance;
    }
    #endregion
}
