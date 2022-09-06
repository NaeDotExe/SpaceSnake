using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    #region Properties
    public Scene CurrentScene
    {
        get { return SceneManager.GetActiveScene(); }
    }
    #endregion

    #region Methods
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(CurrentScene.buildIndex);
    }
    #endregion
}
