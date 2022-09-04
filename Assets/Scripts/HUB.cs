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

    [Space]
    [SerializeField] private ScoreManager _scoreManager = null;
    #endregion

    #region Properties

    #endregion

    #region Events
    public UnityEvent<float> OnSliderValueChanged = new UnityEvent<float>();
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
        int score = _scoreManager.Score;

        _scoreText.text = score.ToString();
    }
    #endregion
}
