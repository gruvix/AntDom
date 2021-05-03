using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class MenuHandler : MonoBehaviour
{
    public Button bnNew;

    public Button bnQuit;
    // Start is called before the first frame update
    void Start()
    {
        bnNew.onClick.AddListener(NewGame);
        bnQuit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void NewGame()
	{

	}

    void Update()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
