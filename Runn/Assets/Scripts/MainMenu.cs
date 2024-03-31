using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene names")]
    public string redDroneClassic;
    public string redDroneSurvival;
    public string redDroneKillEmAll;
    public string blackDroneClassic;
    public string blackDroneSurvival;
    public string blackDroneKillEmAll;
    
    [Header("UIs")]
    public GameObject classicUI;
    public GameObject killEmAllUI;
    public GameObject survivalUI;
    public GameObject mainMenu;
    public Text classicHighScoreText;
    public Text survivalHighScoreText;

    public static int classicHighScore;
    public static int survivalHighScore;

    void Start()
    {
        classicHighScoreText.text = PlayerPrefs.GetInt("ClassicHighScore", 0).ToString();
        survivalHighScoreText.text = PlayerPrefs.GetInt("SurvivalHighScore", 0).ToString();
    }

    void Update()
    {
        if (classicHighScore > PlayerPrefs.GetInt("ClassicHighScore", 0))
        {
            PlayerPrefs.SetInt("ClassicHighScore", classicHighScore);
            classicHighScoreText.text = classicHighScore.ToString();
        }
        if (survivalHighScore > PlayerPrefs.GetInt("SurvivalHighScore", 0))
        {
            PlayerPrefs.SetInt("SurvivalHighScore", survivalHighScore);
            survivalHighScoreText.text = survivalHighScore.ToString();
        }

    }

    public void ToggleClassicMenu()
    {
        
        classicUI.SetActive(!classicUI.activeSelf);
    }

    public void ToggleKillEmAllMenu()
    {
        killEmAllUI.SetActive(!killEmAllUI.activeSelf);
    }

    public void ToggleSurvivalMenu()
    {
        survivalUI.SetActive(!survivalUI.activeSelf);
    }

    public void StartBlackDroneClassic()
    {
        SceneManager.LoadScene(blackDroneClassic);
    }
    
    public void StartBlackDroneSurvival()
    {
        SceneManager.LoadScene(blackDroneSurvival);
    }
    
    public void StartBlackDroneKillEmAll()
    {
        SceneManager.LoadScene(blackDroneKillEmAll);
    }

    public void StartRedDroneClassic()
    {
        SceneManager.LoadScene(redDroneClassic);
    }

    public void StartRedDroneKillEmAll()
    {
        SceneManager.LoadScene(redDroneKillEmAll);
    }
    
    public void StartRedDroneSurvival()
    {
        SceneManager.LoadScene(redDroneSurvival);
    }
    

    public void ToggleMainMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
