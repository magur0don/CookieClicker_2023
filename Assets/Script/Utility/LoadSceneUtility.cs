using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneUtility : SingletonMonoBehaviour<LoadSceneUtility>
{
    public enum SceneTypes
    {
        Invalide = -1,
        StartScene,
        InGameScene
    }

    public void StartLoadScene(SceneTypes sceneType)
    {
        SceneManager.LoadScene(sceneType.ToString());
    }
}
