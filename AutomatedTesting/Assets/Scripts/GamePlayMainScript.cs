using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMainScript : MonoBehaviour
{
    bool GameOver = false;
    bool revive = false;
    float startTime = 0f;
    public GameObject revivePanel;
    public GameObject gameOverPanel;
    PanelHandler panelHandler;
    // Start is called before the first frame update
    void Start()
    {
        panelHandler = FindObjectOfType<PanelHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "GamePlay" && startTime == 0)
        {
            startTime = Time.time;
            Debug.Log("GameStarted");
        }

        if(Time.time > startTime + 10 && GameOver == false)
        {
            GameOver = true;
            revive = false;
            panelHandler.OpenThePanel(revivePanel.gameObject.name);
            StartCoroutine(GameOverr());
            Debug.Log("GameOver");
        }
    }

    public void Revive()
    {
        revive = true;
        startTime = 0f;
        GameOver = false;
        Debug.Log("Revived");
    }

    public IEnumerator GameOverr()
    {
        yield return new WaitForSeconds(5);
        if(revive == false)
        {
            panelHandler.OpenThePanel(gameOverPanel.gameObject.name);
        }
    }

    public void Pause()
    {
        this.gameObject.GetComponent<GamePlayMainScript>().enabled = false;
    }

    public void Resume()
    {
        this.gameObject.GetComponent<GamePlayMainScript>().enabled = true;
    }
}
