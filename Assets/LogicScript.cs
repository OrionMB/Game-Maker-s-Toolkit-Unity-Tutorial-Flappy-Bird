using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int player_score;
    public int high_score = 0;
    public Text score_text;
    public Text high_score_text;
    public GameObject game_over_scene;
    public PipeSpawnScript pipe_spawn;
    private bool game_in_progress = true;
    public AudioSource boing;

    void Start()
    {
        pipe_spawn = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawnScript>();
        game_in_progress = true;
        high_score = PlayerPrefs.GetInt("HighScore");
        high_score_text.text = high_score.ToString();
    }


    [ContextMenu("Increase Score")]
    public void AddScore(int score_to_add)
    {
        if (game_in_progress)
        {
            player_score += score_to_add;
            if (player_score > high_score)
            {
                high_score = player_score;
                PlayerPrefs.SetInt("HighScore", high_score);
            }
            score_text.text = player_score.ToString();
            high_score_text.text = high_score.ToString();
            boing.Play();
            pipe_spawn.UpdatePipeSpawnSpeed(player_score);
        }
    }

    public void Restart_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        game_over_scene.SetActive(true);
        game_in_progress = false;
    }

    public int GetPlayerScore()
    {
        return player_score;
    }
}