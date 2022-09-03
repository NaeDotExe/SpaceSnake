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
        Debug.Log("Spawn");

        int id = Random.Range(0, _prefabs.Count - 1);

        GameObject obj = Instantiate(_prefabs[id], _parent/*Vector3.forward * _lastZ, Quaternion.identit*/);

        obj.transform.position = Vector3.forward * _lastZ;

        _lastZ += _distance;
    }
    #endregion
}
