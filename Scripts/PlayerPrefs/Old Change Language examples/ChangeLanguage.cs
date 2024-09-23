using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLanguage : MonoBehaviour
{
    public GameObject[] Russian;
    public GameObject[] English;

    private int Language = 1;
    // Use this for initialization
    void Start()
    {
        Change();
    }

    private void Change()
    {
        Language = PlayerPrefs.GetInt("Language");
        if (Language == 2)
        {
            toRussian();
        }
        else
        {
            toEnglish();
        }
    }

    private void toEnglish()
    {
        foreach (GameObject obj in Russian)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in English)
        {
            obj.SetActive(true);
        }
    }

    private void toRussian()
    {
        foreach (GameObject obj in Russian)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in English)
        {
            obj.SetActive(false);
        }
    }

    public void Button()
    {
        if (Language == 0)
        {
            PlayerPrefs.SetInt("Language", 2);
        }
        else
        {
            PlayerPrefs.SetInt("Language", 0);
        }
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Change();
        }
    }
    
}
