using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public Button _btn1;

    public Texture2D cursorTexture1;//要替换的光标图片1
    public Texture2D cursorTexture2;//要替换的光标图片2
    public Texture2D cursorTexture3;//要替换的光标图片3

    Texture2D t1;

    private void Awake()
    {
        _btn1.onClick.AddListener(() => { Cursor.SetCursor(cursorTexture3, Vector2.zero, CursorMode.Auto); });
    }

    //鼠标进入3D物体后执行
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
    //鼠标离开3D物体后执行
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    //鼠标进入UI后执行
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
    //鼠标离开UI后执行
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    //在UI中鼠标点击后执行
    public void OnPointerDown(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
    }
    //在UI中鼠标抬起后执行
    public void OnPointerUp(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
    }
}
