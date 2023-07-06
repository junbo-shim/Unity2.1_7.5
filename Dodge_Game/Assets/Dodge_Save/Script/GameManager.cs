using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi = default;
    public GameObject timeText = default;
    public GameObject recordText = default;

    //public Text timeText = default;
    //public Text recordText = default;

    private float surviveTime = default;
    private bool isGameOver = default;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            //timeText.text = string.Format("Time : {0} ", (int)surviveTime);
            timeText.SetText(string.Format("Time : {0} ", (int)surviveTime));
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SceneManagement.LoadScene("PlayScene");
                Function_Global.LoadScene("PlayScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }


        // 이 방식은 책에는 써있지만 연산이 많아서 아래 방식이 좋음
        //recordText.text += "BestTime: " + (int)bestTime;

        //recordText.text = string.Format("Best Time : {0}", (int)bestTime);
        recordText.SetText(string.Format("Best Time : {0}", (int)bestTime));


        Time.timeScale = 0.5F;


    }
}
