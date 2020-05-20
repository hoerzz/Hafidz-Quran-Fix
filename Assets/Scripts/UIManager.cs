using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject AboutPanel, TutorialPanel, ExitPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AboutSelect()
    {
        AboutPanel.SetActive(true);
        TutorialPanel.SetActive(false);
        ExitPanel.SetActive(false);
    }

    public void TutorialSelect()
    {
        AboutPanel.SetActive(false);
        TutorialPanel.SetActive(true);
        ExitPanel.SetActive(false);
    }

    public void ExitSelect()
    {
        AboutPanel.SetActive(false);
        TutorialPanel.SetActive(false);
        ExitPanel.SetActive(true);
    }

    public void Close()
    {
        AboutPanel.SetActive(false);
        TutorialPanel.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Exit This Game");
        Application.Quit();
    }

    public void Cancel()
    {
        ExitPanel.SetActive(false);
    }

    public void Belajar()
    {
        SceneManager.LoadScene("Belajar");
    }

    public void Bermain()
    {
        SceneManager.LoadScene("Bermain");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Load Scane
    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Stage4()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void Stage5()
    {
        SceneManager.LoadScene("Stage5");
    }
    public void Stage6()
    {
        SceneManager.LoadScene("Stage6");
    }
    public void Stage7()
    {
        SceneManager.LoadScene("Stage7");
    }
    public void Stage8()
    {
        SceneManager.LoadScene("Stage8");
    }

    //Load Bermain
    public void AnNas()
    {
        SceneManager.LoadScene("An-Nas");
    }
    public void AlFalaq()
    {
        SceneManager.LoadScene("Al-Falaq");
    }
}
