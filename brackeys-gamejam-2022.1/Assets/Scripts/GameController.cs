using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool xrayState = false;
    

    public GameObject player;
    PlayerMovement pm;
    GameObject GameOverPanel;
    GameObject GameWonPanel;
    GameObject MainMenu;
    GameObject Tutorial;
    EndPickup endPickup;
    Vector3 playerStartPos;

    void Start()
    {
        GameOverPanel = GameObject.Find("GameOverPanel");
        GameOverPanel.SetActive(false);
        pm  = player.GetComponent<PlayerMovement>();

        GameWonPanel = GameObject.Find("GameEndPanel");
        GameWonPanel.SetActive(false);

        MainMenu = GameObject.Find("MainMenu");
        Tutorial = GameObject.Find("TutorialPanel");
        Tutorial.SetActive(false);

        endPickup = GameObject.Find("EndPickup").GetComponent<EndPickup>();
        playerStartPos = pm.transform.position;
    }

    void Update()
    {
        xrayState = pm.xrayUsed;        

        if (Input.GetKeyDown("r"))
        {
            //Time.timeScale = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //MainMenu.SetActive(false);
            //Tutorial.SetActive(false);
            resetGame();

        }
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }else if (endPickup.gameWon)
        {
            pm.playerDead = true;
            GameWonPanel.SetActive(true);
        }

        if (Tutorial.activeSelf)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                startLevel();
            }
        }
        
    }

    private void LateUpdate()
    {
        if (pm.health == 0)
        {
            Debug.Log("Game over");
            GameOverPanel.SetActive(true);
            //Time.timeScale = 0;
        }
        
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }

    public void StartGameBtn()
    {
        MainMenu.SetActive(false);
        Tutorial.SetActive(true);
    }

    public void startLevel()
    {
        Debug.Log("asdf");
        Tutorial.SetActive(false);
        pm.gameStarted = true;
        
    }

    void resetGame()
    {
        pm.playerDead = false;
        pm.gameStarted = true;
        pm.health = 3;
        pm.transform.position = playerStartPos;
        GameOverPanel.SetActive(false);
        pm.xraySlider.value = 3f;
    }
}
