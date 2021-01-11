using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject dialog;
    public GameObject pauseMenuDialog;
    public GameObject optionsMenuDialog;
    public GameObject generique;
    public GameObject player;
    public GameObject cameraLol;
    public GameObject skip;

    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuDialog.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsMenuDialog.activeSelf)
        {
            if (gameIsPaused)
            {
                if (skip.activeSelf)
                {
                    FindObjectOfType<audioManager>().Play("CoronaCut");
                    pauseMenuUI.SetActive(false);
                    Time.timeScale = 1f;
                    gameIsPaused = false;
                }
                else if (pauseMenuDialog.activeSelf && dialog.activeSelf)
                {
                    ResumeDialog();
                }
                else
                {
                    Resume();
                }
            }
            else
            {
                if (skip.activeSelf)
                {
                    FindObjectOfType<audioManager>().Pause("CoronaCut");
                    pauseMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    gameIsPaused = true;
                }
                else if (!pauseMenuDialog.activeSelf && dialog.activeSelf)
                {
                    PauseDialog();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        FindObjectOfType<audioManager>().Play("Corona");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Skip()
    {
        FindObjectOfType<audioManager>().Play("CoronaCut");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ResumeDialog()
    {
        if (generique.gameObject.activeSelf)
            FindObjectOfType<audioManager>().Play("Corona");
        pauseMenuDialog.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void PauseDialog()
    {
        if (generique.gameObject.activeSelf)
            FindObjectOfType<audioManager>().Pause("Corona");
        pauseMenuDialog.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void Pause()
    {
        FindObjectOfType<audioManager>().Pause("Corona");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Score.point = 0;
        FindObjectOfType<audioManager>().Play("CoronaCut");
        player.transform.position = new Vector3(0, 10.2600002f, 3.1099999f);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().MovePosition(Vector3.zero);
        player.GetComponent<Rigidbody>().MoveRotation(Quaternion.identity);


        cameraLol.transform.position = new Vector3(10.2955885f, 12.0460987f, 3.34127188f);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
