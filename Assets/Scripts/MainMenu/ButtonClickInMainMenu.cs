using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickInMainMenu : MonoBehaviour
{
    public void GameStart() {
        SceneManager.LoadScene("123");
    }

    public void Option() {
        this.gameObject.GetComponent<MenuController>().SetMenuActive("OptionMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLanguage()
    {
        Setting.Language.nextLang();
    }
    
    public void PreLanguage()
    {
        Setting.Language.preLang();
    }

    public void BackToMenu() {
        this.gameObject.GetComponent<MenuController>().SetMenuActive("MainMenu");
    }
}
