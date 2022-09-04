using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DefeatPanel : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Image _restartImage = null;
    [SerializeField] private TextMeshProUGUI _highScoreText = null;

    [Space]
    [SerializeField] private float _allowedTime = 5f;

    private bool _allowTimeUpdate = false;
    private float _elapsed = 0f;
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
    private void Start()
    {
        _restartImage.fillAmount = 1;
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

    public void ShowHighScore()
    {
        _highScoreText.gameObject.SetActive(true);
    }
    #endregion
}