using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SettingsSubPanel : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Button _close = null;
    [SerializeField] private Toggle _volumeToggle = null;
    [SerializeField] private Toggle _bloomToggle = null;

    [SerializeField] private GameObject _panel = null;

    private CanvasGroup _canvasGroup = null;
    #endregion

    #region Events
    public UnityEvent<bool> OnVolumeToggled = new UnityEvent<bool>();
    public UnityEvent<bool> OnBloomToggled = new UnityEvent<bool>();
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
        //Init();
    }
    public void Init()
    {
        _close.onClick.AddListener(() => Show(false));

        _volumeToggle.onValueChanged.AddListener(OnVolumeToggled.Invoke);
        _bloomToggle.onValueChanged.AddListener(OnBloomToggled.Invoke);
    }
 
    public void Show(bool show)
    {
        _panel.gameObject.SetActive(show);

        //_canvasGroup.alpha = show ? 1 : 0;
    }
    #endregion
}

