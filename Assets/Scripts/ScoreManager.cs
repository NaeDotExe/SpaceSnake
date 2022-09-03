using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Attributes
    private int _score = 0;
    private int _highScore = 0;
    #endregion

    #region Properties
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

    }
    private void Update()
    {

    }

    public void IncrementScore()
    {
        ++_score;
        if (_score < _highScore)
        {
            _highScore = _score;
        }
    }
    #endregion
}
