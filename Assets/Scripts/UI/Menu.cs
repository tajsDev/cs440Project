using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    static int sceneBuildIndex = 1;
    public void OnStartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void OnEndlessButton()
    {
        ScoreTracker.isEndless = true;
        SceneManager.LoadScene("endless");
    }
    static public void loadNextScene()
    {
        sceneBuildIndex++;
        SceneManager.LoadScene(sceneBuildIndex);
        
    }
    public void returnToMenu()
    {
        resetGame();
        SceneManager.LoadScene(0);
    }
    static public void loadGameOver()
    {
        SceneManager.LoadScene("GameOver");

    }
    void resetGame()
    {
        ScoreTracker.isEndless = false;
        ScoreTracker.currentScore = 0;
        PlayerChange.health = 200;
        SpawnerController.CAPACITY = 5f;
        sceneBuildIndex = 1;
        LevelState.BossEvent = false;
        LevelState.Spawning = true;
        SpawnerController.NUM_OF_ENEMIES = 0;
    }
    public void toScoreForm() {
        SceneManager.LoadScene("ScoreForm");
    }
    static public void loadGameWin()
    {
        SceneManager.LoadScene("GameWin");

    }
    public void toControles()
    {
        SceneManager.LoadScene("Controls");
    }
}