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
    [SerializeField] TextMeshProUGUI nameAlert;
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
            nameAlert.gameObject.SetActive(true);
            StartCoroutine(DisableAlert());
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

    IEnumerator DisableAlert()
    {
        yield return new WaitForSeconds(3);
        nameAlert.gameObject.SetActive(false);
    }
}
