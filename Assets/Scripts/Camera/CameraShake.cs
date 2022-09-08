using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _defaultDuration = 0.4f;
    [SerializeField] private float _defaultMagnitude = 0.4f;

    private Vector3 _startPos = Vector3.zero;
    #endregion

    #region Methods
    private void Start()
    {
        _startPos = transform.localPosition;
    }

    public void Shake()
    {
        Shake(_defaultDuration, _defaultMagnitude);
    }
    public void Shake(float magnitude)
    {
        Shake(_defaultDuration, magnitude);
    }
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(_startPos.x + x, _startPos.y + y, _startPos.z);

            elapsed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.localPosition = _startPos;
    }
    #endregion
}