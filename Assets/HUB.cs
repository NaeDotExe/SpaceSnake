using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HUB : MonoBehaviour
{
    #region Attributes
    [SerializeField] private TextMeshProUGUI _scoreText = null;
    [SerializeField] private Slider _slider = null;

    public UnityEvent<float> OnSliderValueChanged = new UnityEvent<float>();


    // to move
    int _score = 0;
    #endregion

    #region Methods
    private void Start()
    {
        if (_scoreText == null)
        {
            Debug.LogError("ScoreText is null!");
            return;
        }

        _slider.onValueChanged.AddListener(SliderUpdate);
    }

    private void SliderUpdate(float value)
    {
        OnSliderValueChanged.Invoke(value);
    }

    public void UpdateScore()
    {
        ++_score;
        _scoreText.text = _score.ToString();
    }
    #endregion
}
