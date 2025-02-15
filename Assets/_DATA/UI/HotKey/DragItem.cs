using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragItem : LoadAutoComponents, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // OnBeginDrag = user nhan chuot va bat dau di chuyen TrigerEnter
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Enter");
    }

    // OnDrag = user dang keo = TriggerStay
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Stay");
        Vector3 mousePos = InputManager.Instance.mouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    // OnEndDrag = user ket thua = TriggerExit
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Exit");
    }
    
}
