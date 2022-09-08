using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorLerp : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] private Material _material = null;

    [ColorUsage(true, true)]
    [SerializeField] private List<Color> _colors = new List<Color>();

    private float _time = 0f;
    private bool _canLerp = true;
    private int _currentId = 0;
    private Color _currentColor = Color.white;
    private Color _targetColor = Color.white;
    #endregion

    #region Methods
    private void Start()
    {
        _time = 0f;

        _currentId = 0;

        int next = _currentId + 1;
        if (next >= _colors.Count)
        {
            next = 0;
        }

        _currentColor = _colors[_currentId];
        _targetColor = _colors[next];

        _material.color = _currentColor;

        _canLerp = true;
    }

    private void Update()
    {
        if (!_canLerp)
        {
            return;
        }

        _material.color = Color.Lerp(_currentColor, _targetColor, _time);
        if (_time < 1)
        {
            _time += Time.deltaTime / _duration;
        }
        else
        {
            MoveToNextColor();
        }
    }

    private void MoveToNextColor()
    {
        _canLerp = false;
        _time = 0f;

        ++_currentId;
        if (_currentId >= _colors.Count)
        {
            _currentId = 0;
        }

        int next = _currentId + 1;
        if (next >= _colors.Count)
        {
            next = 0;
        }

        _currentColor = _colors[_currentId];
        _targetColor = _colors[next];

        _canLerp = true;
    }
    #endregion
}
