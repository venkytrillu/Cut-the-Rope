using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}// class
