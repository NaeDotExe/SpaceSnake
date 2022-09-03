using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Attributes
    [SerializeField] private Player _player = null;
    #endregion

    #region Events
    public UnityEvent OnGameStart = new UnityEvent();
    public UnityEvent OnGamePause = new UnityEvent();
    public UnityEvent OnGameResume = new UnityEvent();
    public UnityEvent OnGameRestart = new UnityEvent();
    public UnityEvent OnGameEnd = new UnityEvent();
    #endregion

    #region Methods
    private void Start()
    {
        if (_player == null)
        {
            Debug.LogError("Player is null!");
            return;
        }

        _player.OnDeath.AddListener(GameEnd);
    }

    public void GameStart()
    {
        OnGameStart.Invoke();
    }
    public void GamePause()
    {
        Time.timeScale = 0;

        OnGamePause.Invoke();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;

        OnGameResume.Invoke();
    }
    public void GameRestart()
    {
        OnGameRestart.Invoke();
    }
    public void GameEnd()
    {
        OnGameEnd.Invoke();
    }
    #endregion
}
