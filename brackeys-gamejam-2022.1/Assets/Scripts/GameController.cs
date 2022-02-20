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

    void Start()
    {
        GameOverPanel = GameObject.Find("GameOverPanel");
        GameOverPanel.SetActive(false);
        pm  = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        xrayState = pm.xrayUsed;
        Debug.Log(xrayState);

        if (Input.GetKeyDown("r"))
        {
            //Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
