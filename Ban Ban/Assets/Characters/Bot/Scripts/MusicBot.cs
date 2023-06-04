using System.Collections;
using UnityEngine;

public class MusicBot : MonoBehaviour
{
    private Coroutine _playerMusicCorotine;
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerMusicCorotine = StartCoroutine(PlayerMusic());
    }

    private void OnDisable()
    {
        StopCoroutine(_playerMusicCorotine);
    }

    private IEnumerator PlayerMusic()
    {

        var delayTime = Random.Range(0, 10);
        while (true)
        {
            yield return new WaitForSeconds(delayTime + _audioSource.clip.length);
            _audioSource.Play();
        }
    }
}
