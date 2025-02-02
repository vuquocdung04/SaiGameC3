using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public Piece currentPiece;
    public TMP_Text tmp_Time;
    public TMP_Text tmp_Score;
    public int score;
    public float time;
    public GameObject popupWin;
    public void Start()
    {
        instance = this;
        currentPiece = null;
        score = 0;
        time = 0;
        tmp_Time.text = "Time";
        tmp_Score.text = "Score";
    }

    private void Update()
    {
        if(currentPiece != null)
        {
            var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPiece.transform.position = new Vector3(temp.x, temp.y, 0) ;

            if (Input.GetMouseButtonUp(0))
            {
                currentPiece.HandleSetFirstPost();
            }
        }
        time += Time.deltaTime;
        tmp_Time.text = "Time :" + time.ToString();
    }

    public void HandleScore(int param)
    {
        score += param;
        tmp_Score.text = "Score :" + score.ToString();
        if (score >= 9)
        {
            popupWin.SetActive(true);
        }
    }



}
