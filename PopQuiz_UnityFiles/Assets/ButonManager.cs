using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartLevel()
    {
        SoruSecici.sorulanSoru.Clear();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RetryGame()
    {
        SoruSecici.sorulanSoru.Clear();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
