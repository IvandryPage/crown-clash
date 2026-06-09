using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController[] players;
    [SerializeField] private float matchDuration = 60f;

    [Header("UI")]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TMP_Text winnerText;

    private float remainingTime;
    private bool matchEnded;

    private void Start()
    {
        remainingTime = matchDuration;

        endGamePanel.SetActive(false);
    }

    private void Update()
    {
        if (matchEnded)
            return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            EndMatch();
        }
    }

    private void EndMatch()
    {
        matchEnded = true;

        PlayerController winner = null;
        float bestScore = -1f;

        foreach (PlayerController player in players)
        {
            if (player.CrownTime > bestScore)
            {
                bestScore = player.CrownTime;
                winner = player;
            }
        }

        endGamePanel.SetActive(true);

        if (winner != null)
        {
            winnerText.text = $"{winner.name} WINS!";
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public float RemainingTime => remainingTime;
}