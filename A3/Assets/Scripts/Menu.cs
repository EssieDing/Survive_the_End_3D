using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject resumeBtn;
    public GameObject settingPanel;

    public GameObject guidePanel;
    public GameObject aboutPanel;

    public GameObject startBtn;
    public GameObject restartBtn;




    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        resumeBtn.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("pause game");
            pause();
        }
    }

    public void start(){
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        startBtn.SetActive(false);
    }
    public void restart() {
        SceneManager.LoadScene(0);
    }



    public void resume() {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }
    public void pause() {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        resumeBtn.GetComponent<Button>().interactable = true;

        restartBtn.SetActive(true);
    }
    public void quit(){
        #if !UNITY_EDITOR
			Application.Quit();
		#endif
		
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
    }
    public void setting() {
        menuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void closeSetting() {
        settingPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void guide() {
        menuPanel.SetActive(false);
        guidePanel.SetActive(true);
    }

    public void about() {
        menuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void closeGuide() {
        menuPanel.SetActive(true);
        guidePanel.SetActive(false);
    }

    public void closeAbout() {
        menuPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }
    
}
