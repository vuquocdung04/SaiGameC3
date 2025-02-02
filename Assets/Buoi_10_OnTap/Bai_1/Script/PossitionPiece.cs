using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PossitionPiece : MonoBehaviour
{
    public int id;

    //public void OnMouseEnter()
    //{
       
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GamePlayController.instance.currentPiece != null)
        {
            if (GamePlayController.instance.currentPiece.id == id)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                Destroy(GamePlayController.instance.currentPiece.gameObject);
                GamePlayController.instance.currentPiece = null;
                GamePlayController.instance.HandleScore(1);
            }
        }
        Debug.LogError("OnMouseEnter");
    }
}
