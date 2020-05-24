using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickInGame : MonoBehaviour
{
    GameController gameController;

    private void Start()
    {
        gameController = this.gameObject.GetComponent<GameController>();
    }

    public void Pause() {
        gameController.Pause();
    }

    public void Resume() {
        gameController.Resume();
    }

    public void Restart() {
        SceneManager.LoadScene("123");
    }

    public void BackToTitle() {
        SceneManager.LoadScene("MainMenuScene");
    }
}
