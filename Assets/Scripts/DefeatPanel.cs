using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DefeatPanel : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Button _button = null;
    [SerializeField] private TextMeshProUGUI _highScoreText = null;

    [Space]
    [SerializeField] private string _highScoreFormat = "Nouveau Record :\n {0}";

    [Space]
    [SerializeField] private float _allowedTime = 5f;

    [Space]
    [SerializeField] private ScoreManager _scoreManager = null;

    private bool _allowTimeUpdate = false;
    private float _elapsed = 0f;
    private Image _restartImage = null;
    private CanvasGroup _canvasGroup = null;
    #endregion

    #region Properties
    public bool AllowTimeUpdate
    {
        get { return _allowTimeUpdate; }
        set { _allowTimeUpdate = value; }
    }
    #endregion

    #region Events
    public UnityEvent OnTimerEnded = new UnityEvent();
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
        _restartImage = _button.image;

        _restartImage.fillAmount = 1;

        _button.onClick.AddListener(OnTimerEnded.Invoke);
    }
    private void Update()
    {
        if (_allowTimeUpdate)
        {
            _elapsed += Time.deltaTime;
            if (_elapsed >= _allowedTime)
            {
                _allowTimeUpdate = false;
                _elapsed = 0f;
                _restartImage.fillAmount = 0;

                OnTimerEnded.Invoke();
            }
            else
            {
                _restartImage.fillAmount = _elapsed / _allowedTime;
            }
        }
    }

    public void CheckHighScore()
    {
        if (_scoreManager.HasNewHighScore)
        {
            _highScoreText.gameObject.SetActive(true);

            _highScoreText.text = string.Format(_highScoreFormat, _scoreManager.HighScore);
        }
        else
        {
            _highScoreText.gameObject.SetActive(false);
        }
    }

    public void Show(bool show)
    {
        _canvasGroup.alpha = show ? 1 : 0;
    }
    #endregion
}