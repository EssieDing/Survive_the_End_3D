using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public static int enemyNum;
    public static int scoreNum;

    public Text enemyNumText;
    public Text scoreNumText;

    private float timer1 = 10f;
    private float timer2 = 60f;
    public Text scoreMessageText;
    public GameObject winText;
    public GameObject loseText;
    public GameObject message;
    public static bool gameEnd;



    // Start is called before the first frame update
    void Start()
    {
        enemyNum = 1;
        scoreNum = 0;
        gameEnd = false;

        enemyNumText = GameObject.Find ("EnemyNum").GetComponent<Text> ();
        scoreNumText = GameObject.Find ("ScoreNum").GetComponent<Text> ();
        
        enemyNumText.text = enemyNum.ToString();
        scoreNumText.text = scoreNumText.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == true) {
            Debug.Log("game end");
            setUI();
        }
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        if (timer1 <= 0) {
            Debug.Log(string.Format("Timer1 is up !!! time=${0}", Time.time));
            
            scoreNum += 1;
            timer1 = 10f;
        }
        if (timer2 <= 0) {
            scoreNum *= 2;
            timer2 = 60f;
        }
        scoreNumText.text = scoreNum.ToString();
        enemyNumText.text = enemyNum.ToString();

        
    }

    public void setUI(){
        if (scoreNum > 50) {
            winText.SetActive(true);
            loseText.SetActive(false);
        } else if (scoreNum <= 50) {
            loseText.SetActive(true);
            winText.SetActive(false);
        }
        message.SetActive(true);
        scoreMessageText.text = "You get " + scoreNumText.text + " score this time.";
    }

    public void HomeBtn() {
        SceneManager.LoadScene(0);
    }
}
