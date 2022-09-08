using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Attributes
    [SerializeField] private HUB _hub = null;

    private bool _newHighScore = false;
    private int _score = 0;
    private int _highScore = 0;
    #endregion

    #region Properties
    public bool HasNewHighScore
    {
        get { return _newHighScore; }
    }
    public int Score
    {
        get { return _score; }
    }
    public int HighScore
    {
        get { return _highScore; }
    }
    #endregion

    #region Methods
    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        _hub.UpdateHighScore(_highScore);
    }

    public void IncrementScore()
    {
        ++_score;
        if (_score > _highScore)
        {
            _highScore = _score;
            _hub.UpdateHighScore(_highScore);
        }
    }
    public void SaveHighScore()
    {
      int prev =  PlayerPrefs.GetInt("HighScore", 0);
        if (_highScore > prev)
            _newHighScore = true;

        PlayerPrefs.SetInt("HighScore", _highScore);
    }
    #endregion
}
