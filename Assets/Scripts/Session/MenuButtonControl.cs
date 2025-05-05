using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonControl : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(0); // GameSahnesi
    }
    public void Quit()
    {
        Application.Quit();
    }
}
