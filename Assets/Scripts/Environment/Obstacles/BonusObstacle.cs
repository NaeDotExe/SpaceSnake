using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObstacle : Obstacle
{
    #region Attributes
    [SerializeField] private float _speedDivider = 1.5f;
    #endregion

    #region Methods
    public override void Kill()
    {
        FindObjectOfType<Player>().BonusObstacleDestroyed(_speedDivider);

        base.Kill();
    }
    #endregion
}
