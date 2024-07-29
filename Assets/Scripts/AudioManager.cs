using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Toggle BgmToggle;

    [SerializeField] AudioSource sfxAudio;
    public AudioClip diary;
    public AudioClip game1;
    public AudioClip game2;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audioSource;

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void BGMoptions()
    {
        if (BgmToggle.isOn)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
    public void Playsfx(AudioClip clip)
    {
        sfxAudio.PlayOneShot(clip);
    }


}
