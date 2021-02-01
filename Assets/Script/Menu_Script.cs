

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    
    public Button m_YourFirstButton, m_YourSecondButton;

    void Start()
    {
      
        m_YourFirstButton.onClick.AddListener(ChangeScene);
        m_YourSecondButton.onClick.AddListener(quitApp);
    }

    void ChangeScene()
    {
       
        Debug.Log("Changement de Scene");
        SceneManager.LoadScene("Main");

    }

    void quitApp()
    {
       
        Debug.Log("On Quitte l'application");
        Application.Quit();
    }
}