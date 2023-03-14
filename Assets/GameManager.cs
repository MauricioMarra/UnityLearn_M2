using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject bluePlayer;
    [SerializeField] GameObject yellowPlayer;
    [SerializeField] Slider powerSlider;
    [SerializeField] TextMeshProUGUI blueScoreText;
    [SerializeField] TextMeshProUGUI yellowScoreText;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] private int maxRounds = 3;

    private int currentRound = 1;
    private int blueScore = 0;
    private int yellowScore = 0;

    private bool hasCurrentPlayerPlayed = true;
    private bool isNextPlayerBlue = false;
    private bool isGameOver = false;

    private void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        blueScoreText.text = "Blue: 0";
        yellowScoreText.text = "Yellow: 0";

        StartCoroutine(nameof(ReadyPlayer));
    }

    public void SetPowerSlider(float value)
    {
        powerSlider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            winnerText.gameObject.SetActive(true);

            if (blueScore > yellowScore)
                winnerText.text = $"Winner is BLUE!";
            else if (yellowScore > blueScore)
                winnerText.text = $"Winner is YELLOW!";
            else
                winnerText.text = $"DRAW!";

        }
    }

    public void SetBlueScore(int value)
    {
        blueScore += value;
        blueScoreText.text = $"Blue: {blueScore}";
    }

    public void SetYellowScore(int value)
    {
        yellowScore += value;
        yellowScoreText.text = $"Yellow: {yellowScore}";
    }

    IEnumerator ReadyPlayer()
    {
        while (!isGameOver)
        {
            if (hasCurrentPlayerPlayed)
            {
                yield return new WaitForSeconds(5);

                if (isNextPlayerBlue)
                {
                    Instantiate(bluePlayer, spawnPoint.transform.position, Quaternion.identity);
                    isNextPlayerBlue = false;
                }
                else
                {
                    Instantiate(yellowPlayer, spawnPoint.transform.position, Quaternion.identity);
                    isNextPlayerBlue = true;
                }

                hasCurrentPlayerPlayed = false;
                currentRound++;
            }
            
            yield return null;
        }

    }

    public void ReadyNextPlayer()
    {
        if (currentRound > maxRounds * 2)
            isGameOver = true;

        hasCurrentPlayerPlayed = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
