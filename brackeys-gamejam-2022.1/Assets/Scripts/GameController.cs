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
    EndPickup endPickup;

    void Start()
    {
        GameOverPanel = GameObject.Find("GameOverPanel");
        GameOverPanel.SetActive(false);
        pm  = player.GetComponent<PlayerMovement>();

        GameWonPanel = GameObject.Find("GameEndPanel");
        GameWonPanel.SetActive(false);

        endPickup = GameObject.Find("EndPickup").GetComponent<EndPickup>();
    }

    void Update()
    {
        xrayState = pm.xrayUsed;        

        if (Input.GetKeyDown("r"))
        {
            //Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }else if (endPickup.gameWon)
        {
            pm.playerDead = true;
            GameWonPanel.SetActive(true);
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
}
