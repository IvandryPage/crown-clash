using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text p1ScoreText;
    [SerializeField] private TMP_Text p2ScoreText;

    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;

    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        timerText.text =
            Mathf.Ceil(gameManager.RemainingTime).ToString();

        p1ScoreText.text = (player1.CrownTime > player2.CrownTime ? "(X)" : "") +
            $"P1: {player1.CrownTime:F1}";

        p2ScoreText.text = (player1.CrownTime < player2.CrownTime ? "(X)" : "") +
            $"P2: {player2.CrownTime:F1}";
    }
}