using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool xrayState = false;

    public GameObject player;
    PlayerMovement pm;
         

    void Start()
    {
        pm  = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        xrayState = pm.xrayUsed;
        Debug.Log(xrayState);

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
