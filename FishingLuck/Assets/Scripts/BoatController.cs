using System.Collections;
using UnityEngine;
using TMPro;

public class BoatController : MonoBehaviour
{
    public int playerAttempts = 0; // Oyuncunun yaptýðý hamle sayýsý
    public int maxAttempts = 15; // Toplam hamle sayýsý
    private int playerScore = 0; // Oyuncunun anlýk puaný
    private int playerTotalScore = 0; // Oyuncunun toplam puaný
    private int aiScore = 0; // AI'nýn anlýk puaný
    private int aiTotalScore = 0; // AI'nýn toplam puaný
    private bool playerTurn = true; // Oyuncunun sýrasý
    private bool isGameOver = false; // Oyunun bitiþ durumu

    public TextMeshProUGUI playerScoreText; // Oyuncu puanýný gösterecek Text
    public TextMeshProUGUI aiScoreText; // AI puanýný gösterecek Text
    public TextMeshProUGUI playerTotalScoreText; // Oyuncu toplam puanýný gösterecek Text
    public TextMeshProUGUI aiTotalScoreText; // AI toplam puanýný gösterecek Text
    public TextMeshProUGUI winText; // Oyun sonu kazanan/kaybeden text

    public AudioClip moveSound; // Ses efekti için AudioClip
    private AudioSource audioSource; // Ses çalma için AudioSource
    private GameManager gameManager;
    public GamePause gamePause; // GamePause scriptine referans

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager'ý bul
        playerTotalScoreText.gameObject.SetActive(false); // Toplam skorlar baþlangýçta gizli
        aiTotalScoreText.gameObject.SetActive(false); // Toplam skorlar baþlangýçta gizli
        winText.gameObject.SetActive(false); // Win/Lose text baþlangýçta gizli
        audioSource = GetComponent<AudioSource>(); // AudioSource bileþenini al
        UpdateScoreUI(); // Baþlangýç skorlarýný sýfýr olarak göster
    }

    void OnMouseDown()
    {
        if (playerTurn && !isGameOver)
        {
            Fish caughtFish = gameManager.GetRandomFish(); // Rastgele bir balýk yakala
            playerScore = caughtFish.GetScoreValue(); // Balýðýn skorunu al
            playerTotalScore += playerScore;
            playerAttempts++; // Oyuncunun hamle sayýsýný artýr

            gameManager.CatchFish(caughtFish); // Balýðýn görselini ve puanýný göster

            // Hamle sesini çal
            PlayMoveSound();

            UpdateScoreUI();

            if (playerAttempts >= maxAttempts)
            {
                EndGame(); // Oyunu sonlandýr
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
        // Oyun sýrasýnda sadece anlýk skorlar gösterilir
        playerScoreText.text = "My Score: " + playerScore.ToString();
        aiScoreText.text = aiScore.ToString() + " :AI Score";
    }

    IEnumerator AITurn()
    {
        yield return new WaitForSeconds(1.0f); // Kýsa bir bekleme süresi

        // AI bir hamle yapar
        Fish aiCaughtFish = gameManager.GetRandomFish();
        aiScore = aiCaughtFish.GetScoreValue();
        aiTotalScore += aiScore;

        gameManager.CatchFish(aiCaughtFish); // AI için de balýk görseli ve puaný göster

        // AI hamlesinde de hamle sesini çal
        PlayMoveSound();

        UpdateScoreUI();

        if (playerAttempts >= maxAttempts)
        {
            EndGame(); // Oyunu sonlandýr
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
            audioSource.PlayOneShot(moveSound); // Ses efektini çal
        }
    }

    void EndGame()
    {
        isGameOver = true; // Oyunu bitir

        // Anlýk skorlarý gizle ve toplam skorlarý göster
        playerScoreText.gameObject.SetActive(false);
        aiScoreText.gameObject.SetActive(false);

        playerTotalScoreText.text = "Player Total Score: " + playerTotalScore.ToString();
        aiTotalScoreText.text = "AI Total Score: " + aiTotalScore.ToString();

        playerTotalScoreText.gameObject.SetActive(true);
        aiTotalScoreText.gameObject.SetActive(true);

        // Kazananý belirle
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

        winText.gameObject.SetActive(true); // Kazanan metnini göster

        gamePause.EndGame(); // Oyun sonu fonksiyonunu çaðýr

        // Oyun sonunda balýk görselini gizle
        gameManager.HideFish();
    }
}
