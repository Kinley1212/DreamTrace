using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New CharacterProfile", menuName = "Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string myName;
    private Sprite myPortrait;
    public Sprite myAvatar;

    public AudioClip myVoice;
    public Color myFontColor;
    public Color myAvatorBackgroundColor;

    //public TMP_FontAsset myFont;
    public Sprite MyPortrait
    {
        get
        {
            setEmtionType(Emotion);
            return myPortrait;
        }

    }

    [System.Serializable]
    public class EmotionPortraits
    {
        public Sprite standard;
        public Sprite happy;
        public Sprite angry;
        public Sprite shock;
        public Sprite sad;
        public Sprite hurt;
    }

    public EmotionPortraits myEmotionPortrait;
    [HideInInspector]
    public EmotionType Emotion;

    public void setEmtionType(EmotionType newEmotion)
    {
        Emotion = newEmotion;
        switch (Emotion)
        {
            case EmotionType.Standard:
                myPortrait = myEmotionPortrait.standard;
                break;
            case EmotionType.Happy:
                myPortrait = myEmotionPortrait.happy;
                break;
            case EmotionType.Angry:
                myPortrait = myEmotionPortrait.angry;
                break;
            case EmotionType.shock:
                myPortrait = myEmotionPortrait.shock;
                break;
            case EmotionType.sad:
                myPortrait = myEmotionPortrait.sad;
                break;
            case EmotionType.hurt:
                myPortrait = myEmotionPortrait.hurt;
                break;
        }
    }
}
public enum EmotionType
{
    Standard,
    Happy,
    Angry,
    shock,
    sad,
    hurt,
}
