using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragItem : LoadAutoComponents, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;

    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
    }

    // OnBeginDrag = user nhan chuot va bat dau di chuyen TrigerEnter
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Enter");
        this.realParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
        this.image.raycastTarget = false;
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
        // realParent => set parent DragItem
        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
    }
    
}
