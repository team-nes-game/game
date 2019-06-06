using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public bool start;
    public bool exit;

    private void OnMouseUp()
    {
        if (start)
        {
            SceneManager.LoadScene(1);
        }
        if (exit)
        {
            Application.Quit();
        }
    }
}
