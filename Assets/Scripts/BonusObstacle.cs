using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObstacle : Obstacle
{
    #region Attributes
    [SerializeField] private float _speedDivider = 2.0f;
    #endregion

    #region Methods
    public override void Kill()
    {
        FindObjectOfType<Player>().BonusObstacleDestroyed();

        base.Kill();
    }
    #endregion
}
