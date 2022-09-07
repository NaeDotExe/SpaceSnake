using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CanvasStart : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Button _moveToNext = null;
    [SerializeField] private GameObject _title = null;
    [SerializeField] private GameObject _tuto = null;
    
    [Space]
    [SerializeField] private Button _options = null;
    [SerializeField] private SettingsSubPanel _settingsSubPanel = null;

    private CanvasGroup _canvasGroup = null;
    #endregion

    #region Events
    public UnityEvent OnMenuButtonClicked = new UnityEvent();
    public UnityEvent OnOptionsClicked = new UnityEvent();
    public UnityEvent OnTutoComplete = new UnityEvent();
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
        _options.onClick.AddListener(OnOptionsClicked.Invoke);
        _moveToNext.onClick.AddListener(OnMenuButtonClicked.Invoke);

        _settingsSubPanel.Init();
        _settingsSubPanel.Show(false);
    }

    public void Show(bool show)
    {
        _canvasGroup.alpha = show ? 1 : 0;
    }

    public void TutoComplete()
    {
        OnTutoComplete.Invoke();
    }
    #endregion
}
