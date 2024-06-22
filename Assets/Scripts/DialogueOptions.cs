using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialoge Options", menuName = "DialogueOptions")]
public class DialogueOptions : DialogueBase
{
    [System.Serializable]
    public class Options
    {
        public string buttonName;
        public DialogueBase nextDialoge;
        public UnityEvent myEvent;
        
    }

    [TextArea(2, 10)]
    public string questionText;
    public Options[] optionsInfo;

}
