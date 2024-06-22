using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("!" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    [Header("UI")]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguerAvatar;
    public Image dialoguerAvatarBG; 
    public Image[] dialoguerPortraitUI;

    [Header("可配置项")]
    public float textShowDelay = 0.05f;
    public TMP_FontAsset textFont;
    public TMP_FontAsset nameFont;


    public Queue<DialogueBase.info> dialogueInfo = new Queue<DialogueBase.info>();

    //对话选项 
    private bool isDialogueOption;
    private bool inDialogue;
    public GameObject dialogueOptionUI;
    public GameObject[] optionButtons;
    private int optionAmount;
    public TextMeshProUGUI QuestionText;

    //AutoComplete 点击快速对话跳过typing效果
    private bool isCurrentlyTyping = false;
    private string completeText;

    private readonly List<char> puncutationCharacters = new List<char>
    {
        '!',
        '?',
        '。',
        '，',
        '.',
    };


    private void Start()
    {
        dialogueText.font = textFont;
        dialogueName.font = nameFont;
    }

    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return;
        inDialogue = true;

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        OptionParser(db);

        foreach (DialogueBase.info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0)
        {
            EndofDialogue();
            return;
        }

        if (isCurrentlyTyping == true)
        {
            StopAllCoroutines();
            CompleteText();
            isCurrentlyTyping = false;
            return;
        }

        DialogueBase.info info = dialogueInfo.Dequeue();
        completeText = info.myText;

        //设置立绘

        foreach (Image img in dialoguerPortraitUI)
        {
            if(img != null)
            img.gameObject.SetActive(false);
        }

        if (info.portraitSlotIndex > 0)
        { 
            info.ChangeEmotion();
            dialoguerPortraitUI[info.portraitSlotIndex].gameObject.SetActive(true);
            dialoguerPortraitUI[info.portraitSlotIndex].sprite = info.character.MyPortrait;//*My
        }
        dialoguerAvatar.sprite = info.character.myAvatar;
        dialoguerAvatarBG.color = info.character.myAvatorBackgroundColor;//头像背景颜色
        //设置对话
        dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
        dialogueName.color = info.character.myFontColor;//字体颜色
        dialogueText.color = info.character.myFontColor;

        dialogueText.text = "";
        StartCoroutine(TypeText(info));

    }

    IEnumerator TypeText(DialogueBase.info info)
    {
        isCurrentlyTyping = true;
        dialogueText.text = "";
      
        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(textShowDelay);
            dialogueText.text += c;
            if(info.character.myVoice != null)
            AudioManager.instance.PlayClip(info.character.myVoice);

            if (CheckPunctuation(c))
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    private bool CheckPunctuation(char c)
    {
        if (puncutationCharacters.Contains(c))
        {
            return true;
        }
        else {
            return false;
        }
    }

    public void EndofDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;

        //开启选项
        if (isDialogueOption != true) return;
        OptionLogic();
    }

    private void OptionLogic()
    {
        dialogueOptionUI.SetActive(true);
        inDialogue = true;
    }

    private void OptionParser(DialogueBase db)
    {
        //对话配置是否是选项子类
        isDialogueOption = db is DialogueOptions;
        if (isDialogueOption)
        {
            DialogueOptions dialogueOptions = db as DialogueOptions;

            //根据问题数量开启选项按钮
            optionAmount = dialogueOptions.optionsInfo.Length;
            QuestionText.text = dialogueOptions.questionText;


            for (int i = 0; i < optionButtons.Length; i++) //可能多次启用,提前隐藏不需要的按钮
            {
                optionButtons[i].SetActive(false);
            }

            for (int i = 0; i < optionAmount; i++)
            {
                optionButtons[i].SetActive(true);
                if (optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text != null)
                    optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogueOptions.optionsInfo[i].buttonName;
                else Debug.LogWarning("Lose Option Button");

                //*尝试失败**直接在按钮上加event触发的函数function
                //optionButtons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                //optionButtons[i].GetComponent<Button>().onClick.AddListener(dialogueOptions.optionsInfo[i].myEvent.Equals);


                if (optionButtons[i].GetComponent<UnityEventHandler>() != null)
                {
                    UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                    myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialoge;
                }
            }
        }
    }

    public void CloseOption()
    {
        dialogueOptionUI.SetActive(false);
        inDialogue = false;
    }
}

