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
    public UnityEvent OnGameRestart = new UnityEvent();
    public UnityEvent OnGameEnd = new UnityEvent();

    public UnityEvent OnObstacleDestroyed = new UnityEvent();
    #endregion

    #region Methods
    private void Start()
    {
        //Application.targetFrameRate = 60;

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
    public void GameRestart()
    {
        OnGameRestart.Invoke();
    }
    public void GameEnd()
    {
        OnGameEnd.Invoke();
    }
 
    public void ObstacleDestroyed()
    {
        // to clean
        //OnObstacleDestroyed.Invoke();
    }
    #endregion
}
