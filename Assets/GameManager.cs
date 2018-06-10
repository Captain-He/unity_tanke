using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public GameObject endUI;
    public static GameManager instance;
    void Awake()
    {
        instance = this;     
    }
    public void Failed()
    {
        endUI.SetActive(true);
    }
    public void re1button()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void nexbutton2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void re2button()
    {
        SceneManager.LoadScene("Scene2");
    }
}
