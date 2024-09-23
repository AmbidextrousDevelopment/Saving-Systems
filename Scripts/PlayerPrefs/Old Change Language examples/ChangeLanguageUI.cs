using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChangeLanguageUI : MonoBehaviour  //with textmesh pro
{
    private string lang;

    // Start is called before the first frame update
    void Start()
    {
        Change();
        Language();
    }

    private void Change()
    {
        lang = PlayerPrefs.GetString("Language");
    }

    private void Language()
    {
        GameObject[] Russian = GameObject.FindGameObjectsWithTag("Russian");
        foreach (GameObject go in Russian)
        {
            if (lang == "rus")
            {
                go.GetComponent<TextMeshProUGUI>().enabled = true;
            }
            else go.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        GameObject[] English = GameObject.FindGameObjectsWithTag("English");
        foreach (GameObject go in English)
        {
            if (lang == "eng")
            {
                go.GetComponent<TextMeshProUGUI>().enabled = true;
            }
            else go.GetComponent<TextMeshProUGUI>().enabled = false;
        }

    }
}
