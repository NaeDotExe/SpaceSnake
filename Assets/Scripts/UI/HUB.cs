using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HUB : MonoBehaviour
{
    #region Attributes
    [SerializeField] private string _ammoFormat = "Munitions : {0}";
    [SerializeField] private string _highScoreFormat = "Record : {0}";

    [Space]
    [SerializeField] private TextMeshProUGUI _scoreText = null;
    [SerializeField] private TextMeshProUGUI _highScoreText = null;
    [SerializeField] private TextMeshProUGUI _ammoText = null;
    [SerializeField] private Slider _slider = null;

    [Space]
    [SerializeField] private ScoreManager _scoreManager = null;

    private CanvasGroup _canvasGroup = null;
    #endregion

    #region Events
    public UnityEvent<float> OnSliderValueChanged = new UnityEvent<float>();
    #endregion

    #region Methods
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
        {
            Debug.LogError("No Component CanvasGroup found.");
            return;
        }
    }
    private void Start()
    {
        if (_scoreText == null)
        {
            Debug.LogError("ScoreText is null!");
            return;
        }

        Init();
    }

    public void Init()
    {
        _slider.onValueChanged.AddListener(SliderUpdate);
    }
    public void Show(bool show)
    {
        _canvasGroup.alpha = show ? 1 : 0;
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
    public void UpdateAmmo(int ammo)
    {
        _ammoText.text = string.Format(_ammoFormat, ammo);
    }
    public void UpdateHighScore(int highScore)
    {
        _highScoreText.text = string.Format(_highScoreFormat, highScore);
    }
    #endregion
}
