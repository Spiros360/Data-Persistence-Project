using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif



// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]


public class MenuUIHandler : MonoBehaviour
{
    
    private string playerName;
    public TMP_InputField InputName;
    public Text bestScore;
    private int score;


    void Start()
    {
        playerName = Persistent.Instance.textName;
        score = Persistent.Instance.bestScore;
        bestScore.text = "Best Score: "+ playerName + ": " + score;
    }


    public void SetName()
    {

        playerName = InputName.text;
        Persistent.Instance.textName = playerName;
        Persistent.Instance.score = 0;
        
    }



    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Persistent.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
