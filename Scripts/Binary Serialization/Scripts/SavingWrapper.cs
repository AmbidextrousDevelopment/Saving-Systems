using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Saving                                             //C:/Users/User/AppData/LocalLow/DefaultCompany/RPG study 18_4
{
    public class SavingWrapper : MonoBehaviour
    {
        
        #region newSystem
        const string defaultSaveFile = "save"; //потом удалить
        private const string currentSaveKey = "currentSaveName";

        [SerializeField] float fadeInTime = 0.2f;
        //* new
        
        [SerializeField] int firstLevelBuildIndex = 1;
        [SerializeField] int menuLevelBuildIndex = 0;
        
        // *
        private void Awake()
        {
          
        }
        //new
        public void ContinueGame()
        {
            StartCoroutine(LoadLastScene());
        }

        public void NewGame(string saveFile)
        {
            SetCurrentSave(saveFile);  // здесь появляется новый сейв
            StartCoroutine(LoadFirstScene());
        }

        public void LoadGame(string saveFile)
        {
            SetCurrentSave(saveFile);
            ContinueGame();
        }

        public void LoadMenu()
        {
            StartCoroutine(LoadMenuScene());
        }

        private void SetCurrentSave(string saveFile)
        {
            PlayerPrefs.SetString(currentSaveKey, saveFile);
        }

        private string GetCurrentSave()
        {
            return PlayerPrefs.GetString(currentSaveKey);
        }

        private IEnumerator LoadFirstScene()
        {
          
            yield return SceneManager.LoadSceneAsync(firstLevelBuildIndex);
           
        }

        private IEnumerator LoadMenuScene()
        {
            
            yield return SceneManager.LoadSceneAsync(menuLevelBuildIndex);
          
        }
        //*
        private IEnumerator LoadLastScene()
        {
            yield return GetComponent<SavingSystem>().LoadLastScene(GetCurrentSave()); //загружает сцену с нынешним сейвом
                                                                                       // yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutImmediate();
            yield return fader.FadeIn(fadeInTime);
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
                {
                    Save();
                }


                if (Input.GetKeyDown(KeyCode.L))
                {
                    Load();
                }
                if (Input.GetKeyDown(KeyCode.Delete))
                {
                    Delete();
                }
            }
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(GetCurrentSave()); //было (defaultSaveFile)
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(GetCurrentSave());  // было (defaultSaveFile)
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(GetCurrentSave()); // было (defaultSaveFile)
        }
        //new
        public IEnumerable<string> ListSaves()
        {
            return GetComponent<SavingSystem>().ListSaves();
        }
        //*
        #endregion
    }
}
