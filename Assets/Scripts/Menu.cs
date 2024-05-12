using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameField;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance.playerName != "")
        {
            playerNameField.text = DataManager.Instance.playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string value)
    {
        DataManager.Instance.playerName = value;
    }

    public void Exit()
    {
        if (DataManager.Instance.playerName != "")
        {
            DataManager.Instance.SaveScores();
        }
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

    public void StartGame()
    {
        if(DataManager.Instance.playerName == "")
        {
            Debug.Log("Enter name!");
        }
        else
        {
            SceneManager.LoadScene(1);
        }    
    }

    public void HighScores()
    {
        SceneManager.LoadScene(2);
    }
}
