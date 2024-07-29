using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundRes : MonoBehaviour
{
    // Start is called before the first frame update

        /// <summary>
        /// 悬浮时音效
        /// </summary>
        public AudioClip hoverSound;
    /// <summary>
    /// 按下时音效
    /// </summary>
    public AudioClip pressedSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPressedSound()
    {
        audioSource.clip = pressedSound;
        audioSource.Play();
    }

    public void PlayHoverSound()
    {
        audioSource.clip = hoverSound;
        audioSource.Play();
    }
}