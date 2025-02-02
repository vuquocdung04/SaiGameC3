using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int id;
    public Vector3 firstPosition;

    public void Start()
    {
        firstPosition = transform.position;
    }

    public void OnMouseDown()
    {
        if(GamePlayController.instance.currentPiece == null)
        {
            GamePlayController.instance.currentPiece = this;
        }
    }
    public void HandleSetFirstPost()
    {
        transform.position = firstPosition;
        GamePlayController.instance.currentPiece = null;
    }
}
