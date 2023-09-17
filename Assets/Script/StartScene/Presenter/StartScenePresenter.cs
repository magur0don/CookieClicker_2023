using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePresenter : MonoBehaviour
{
    private StartSceneModel startSceneModel;

    [SerializeField]
    private StartSceneView startSceneView;

    async void Start()
    {
        startSceneModel = new StartSceneModel();
        await startSceneModel.Load();

        AudioManager.Instance.AudioLoad();
        startSceneView.SetStartButtonImage();
        AudioManager.Instance.PlayBGM(AudioManager.BGMTypes.Start);
        startSceneView.SetStartButton(() => LoadSceneUtility.Instance.StartLoadScene(LoadSceneUtility.SceneTypes.InGameScene));
    }

}
