using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Dialoge", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject 
{
    [System.Serializable]
    public class info
    {
        public CharacterProfile character;
        //public string myName;
        //public Sprite portrait;
        [TextArea(4, 8)]
        public string myText;

        public EmotionType characterEmotion;
        public int portraitSlotIndex = 0;
        public void ChangeEmotion()
        {
            character.Emotion = characterEmotion;
        }

    }

    [Header("Insert Dialogue Information Below")]
    public info[] dialogueInfo;



}
