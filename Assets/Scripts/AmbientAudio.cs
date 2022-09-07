using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float _lerpDuration = 0.5f;

    private AudioSource _source = null;
    #endregion

    #region Methods
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        if (_source == null)
        {
            Debug.LogError("No Component AudioSource found.");
            return;
        }
    }

    public void ToggleVolume(bool isOn)
    {
        _source.volume = isOn ? 1 : 0;
    }

    public void SetPitch(float pitch)
    {
        _source.pitch = pitch;
    }
    public void LerpToPitch(float pitch)
    {
        StartCoroutine(LerpPitchCoroutine(pitch));
    }
    private IEnumerator LerpPitchCoroutine(float pitch)
    {
        float startValue = _source.pitch;
        float counter = 0f;
        float endValue = pitch;

        while (counter < _lerpDuration)
        {
            counter += Time.deltaTime;
            _source.pitch = Mathf.Lerp(startValue, endValue, counter / _lerpDuration);
            yield return null;
        }

        _source.pitch = endValue;
    }
    #endregion
}
