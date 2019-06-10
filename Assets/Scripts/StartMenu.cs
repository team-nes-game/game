using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public bool start;
    public bool exit;
    public bool info;
    public bool back;

    private void OnMouseUp()
    {
        if (start)
        {
            SceneManager.LoadScene(1);
        }
        if (info)
        {
            SceneManager.LoadScene(6);
        }
        if (exit)
        {
            Application.Quit();
        }
        if (back)
        {
            SceneManager.LoadScene(0);
        }
    }
}
