using System.Collections;
using UnityEngine;
using TMPro;

public class BoatController : MonoBehaviour
{
    public int playerAttempts = 0; // Oyuncunun yapt��� hamle say�s�
    public int maxAttempts = 15; // Toplam hamle say�s�
    private int playerScore = 0; // Oyuncunun anl�k puan�
    private int playerTotalScore = 0; // Oyuncunun toplam puan�
    private int aiScore = 0; // AI'n�n anl�k puan�
    private int aiTotalScore = 0; // AI'n�n toplam puan�
    private bool playerTurn = true; // Oyuncunun s�ras�
    private bool isGameOver = false; // Oyunun biti� durumu

    public TextMeshProUGUI playerScoreText; // Oyuncu puan�n� g�sterecek Text
    public TextMeshProUGUI aiScoreText; // AI puan�n� g�sterecek Text
    public TextMeshProUGUI playerTotalScoreText; // Oyuncu toplam puan�n� g�sterecek Text
    public TextMeshProUGUI aiTotalScoreText; // AI toplam puan�n� g�sterecek Text
    public TextMeshProUGUI winText; // Oyun sonu kazanan/kaybeden text

    public AudioClip moveSound; // Ses efekti i�in AudioClip
    private AudioSource audioSource; // Ses �alma i�in AudioSource
    private GameManager gameManager;
    public GamePause gamePause; // GamePause scriptine referans

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager'� bul
        playerTotalScoreText.gameObject.SetActive(false); // Toplam skorlar ba�lang��ta gizli
        aiTotalScoreText.gameObject.SetActive(false); // Toplam skorlar ba�lang��ta gizli
        winText.gameObject.SetActive(false); // Win/Lose text ba�lang��ta gizli
        audioSource = GetComponent<AudioSource>(); // AudioSource bile�enini al
        UpdateScoreUI(); // Ba�lang�� skorlar�n� s�f�r olarak g�ster
    }

    void OnMouseDown()
    {
        if (playerTurn && !isGameOver)
        {
            Fish caughtFish = gameManager.GetRandomFish(); // Rastgele bir bal�k yakala
            playerScore = caughtFish.GetScoreValue(); // Bal���n skorunu al
            playerTotalScore += playerScore;
            playerAttempts++; // Oyuncunun hamle say�s�n� art�r

            gameManager.CatchFish(caughtFish); // Bal���n g�rselini ve puan�n� g�ster

            // Hamle sesini �al
            PlayMoveSound();

            UpdateScoreUI();

            if (playerAttempts >= maxAttempts)
            {
                EndGame(); // Oyunu sonland�r
            }
            else
            {
                playerTurn = false;
                StartCoroutine(AITurn());
            }
        }
    }

    void UpdateScoreUI()
    {
        // Oyun s�ras�nda sadece anl�k skorlar g�sterilir
        playerScoreText.text = "My Score: " + playerScore.ToString();
        aiScoreText.text = aiScore.ToString() + " :AI Score";
    }

    IEnumerator AITurn()
    {
        yield return new WaitForSeconds(1.0f); // K�sa bir bekleme s�resi

        // AI bir hamle yapar
        Fish aiCaughtFish = gameManager.GetRandomFish();
        aiScore = aiCaughtFish.GetScoreValue();
        aiTotalScore += aiScore;

        gameManager.CatchFish(aiCaughtFish); // AI i�in de bal�k g�rseli ve puan� g�ster

        // AI hamlesinde de hamle sesini �al
        PlayMoveSound();

        UpdateScoreUI();

        if (playerAttempts >= maxAttempts)
        {
            EndGame(); // Oyunu sonland�r
        }
        else
        {
            playerTurn = true;
        }
    }

    void PlayMoveSound()
    {
        if (moveSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(moveSound); // Ses efektini �al
        }
    }

    void EndGame()
    {
        isGameOver = true; // Oyunu bitir

        // Anl�k skorlar� gizle ve toplam skorlar� g�ster
        playerScoreText.gameObject.SetActive(false);
        aiScoreText.gameObject.SetActive(false);

        playerTotalScoreText.text = "Player Total Score: " + playerTotalScore.ToString();
        aiTotalScoreText.text = "AI Total Score: " + aiTotalScore.ToString();

        playerTotalScoreText.gameObject.SetActive(true);
        aiTotalScoreText.gameObject.SetActive(true);

        // Kazanan� belirle
        if (playerTotalScore > aiTotalScore)
        {
            winText.text = "You Win!";
        }
        else if (playerTotalScore < aiTotalScore)
        {
            winText.text = "AI Wins!";
        }
        else
        {
            winText.text = "It's a Draw!";
        }

        winText.gameObject.SetActive(true); // Kazanan metnini g�ster

        gamePause.EndGame(); // Oyun sonu fonksiyonunu �a��r

        // Oyun sonunda bal�k g�rselini gizle
        gameManager.HideFish();
    }
}
