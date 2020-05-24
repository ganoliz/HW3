using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject GameCompleteMenu;
    [SerializeField] private AudioClip explode;
    private bool GameIsPaused;
    private bool GameIsComplete;

    private int EnemyCount;
    private int DefeatEnemyCount;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;
        GameIsComplete = false;
        SetPauseMenu();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1;
        GameOverMenu.SetActive(false);
        GameCompleteMenu.SetActive(false);

        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        DefeatEnemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameIsComplete && DefeatEnemyCount >= EnemyCount)
        {
            GameIsComplete = true;
            GameComplete();
        }
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
    }

    public void GameComplete()
    {
        GameCompleteMenu.SetActive(true);
    }

    public void Pause() {
        GameIsPaused = !GameIsPaused;
        SetPauseMenu();
    }

    public void Resume() {
        GameIsPaused = false;
        SetPauseMenu();
    }

    private void SetPauseMenu()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }

    public void PlayExplodeEffect()
    {
        audioSource.PlayOneShot(explode, Setting.Volume.VOLUME_EFFECT / 100f);
    }

    public void EnemyIsDefeat()
    {
        DefeatEnemyCount++;
    }
}
