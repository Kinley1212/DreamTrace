using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManger : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorPickaxe;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);

    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorPickaxe, Vector2.zero, CursorMode.ForceSoftware);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    //鼠标进入UI后执行
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorPickaxe, Vector2.zero, CursorMode.ForceSoftware);
    }
    //鼠标离开UI后执行
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
