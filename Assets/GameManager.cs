using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject spawnPoint;
    [SerializeField] Slider powerSlider;
    [SerializeField] TextMeshProUGUI blueScoreText;
    [SerializeField] TextMeshProUGUI yellowScoreText;

    private int blueScore = 0;
    private int yellowScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        blueScoreText.text = "Blue: 0";
        yellowScoreText.text = "Yellow: 0";
    }

    public void SetPowerSlider(float value)
    {
        powerSlider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
