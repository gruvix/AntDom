using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{
    public Button bnNew;
    public Button bnLoad;
    public Button bnQuit;
    
    void Start()
    {
        bnNew.onClick.AddListener(NewGame);
        bnQuit.onClick.AddListener(QuitGame);
    }


    void NewGame()
	{
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
