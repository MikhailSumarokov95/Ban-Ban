using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private GameObject backGroundPref;

    [Range(0f, 1f)]
    [SerializeField] private float volumeBackGround;
    private AudioSource _backGroundAudioS;
    private Setting _setting;

    private void Start()
    {
        _backGroundAudioS = Instantiate(backGroundPref).GetComponent<AudioSource>();
        _backGroundAudioS.volume = Progress.GetMusicVolume() * volumeBackGround;

        AudioListener.volume = Progress.GetVolume();
    }

    private void OnEnable()
    {
        _setting = FindObjectOfType<Setting>(true);
        _setting.OnChangeMusicVolume += ChangeVolumeBackGround;
    }

    private void OnDisable()
    {
        _setting.OnChangeMusicVolume -= ChangeVolumeBackGround;
    }

    private void ChangeVolumeBackGround()
    {
        _backGroundAudioS.volume = Progress.GetMusicVolume() * volumeBackGround;
    }
}
