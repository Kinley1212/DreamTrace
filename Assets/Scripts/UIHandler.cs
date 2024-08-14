using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("点击了UI元素，忽略");
        }
        else
        {
            Debug.Log("点击了场景物体");
            // 在这里处理点击场景物体的逻辑
        }
    }
}
