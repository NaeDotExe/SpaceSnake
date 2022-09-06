using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Methods
    private void Start()
    {

    }

    public void Spawn()
    {
        // play anim
    }
    public virtual void Kill()
    {
        Destroy(gameObject);
    }
    #endregion
}
