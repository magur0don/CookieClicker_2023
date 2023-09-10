using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{

    [SerializeField]
    private AudioSource[] AudioSources = new AudioSource[3];

    private List<AudioClip> SEAudioClips = new List<AudioClip>();

    private List<AudioClip> BGMAudioClips = new List<AudioClip>();


    public enum AudioSourceTypes
    {
        Invalide = -1,
        BGM,
        SE_Primaly,
        SE_Secondary
    }

    public enum SETypes
    {
        Invalide = -1,
        Click,
        OK,
        Fail
    }
    public enum BGMTypes
    {
        Invalide = -1,
        Start,
        InGame,
    }

    public override void Awake()
    {
        var audioSources = this.GetComponentsInChildren<AudioSource>();
        // AudioSourcesを追加
        for (int i = 0; i < audioSources.Length; i++)
        {
            AudioSources[i] = audioSources[i];
        }
    }

    public void AudioLoad()
    {

        var seAudioClips =
            AddressableAssetLoadUtility.Instance.LoadAssetsAsync<AudioClip>("SE");
        SEAudioClips.AddRange(seAudioClips);

        var bgmAudioClips =
            AddressableAssetLoadUtility.Instance.LoadAssetsAsync<AudioClip>("BGM");
        BGMAudioClips.AddRange(bgmAudioClips);
    }

    public void PlayBGM(BGMTypes bgmType)
    {
        AudioSources[(int)AudioSourceTypes.BGM].clip = BGMAudioClips[(int)bgmType];
        AudioSources[(int)AudioSourceTypes.BGM].Play();
    }

    public void PlaySE(SETypes seType)
    {
        var se = SEAudioClips.Find(clip => clip.name == seType.ToString());

        if (se == null)
        {
            Debug.LogError("指定されたSEはありません");
            return;
        }

        if (!AudioSources[(int)AudioSourceTypes.SE_Primaly].isPlaying)
        {
            AudioSources[(int)AudioSourceTypes.SE_Primaly].clip = se;
            AudioSources[(int)AudioSourceTypes.SE_Primaly].Play();
            return;
        }
        // SE_Primalyは再生中なのでSE_Secondaryで再生する
        if (!AudioSources[(int)AudioSourceTypes.SE_Secondary].isPlaying)
        {
            AudioSources[(int)AudioSourceTypes.SE_Secondary].clip = se;
            AudioSources[(int)AudioSourceTypes.SE_Secondary].Play();
            return;
        }
        Debug.LogError("再生できるオーディオ数を超えています");
    }
}
