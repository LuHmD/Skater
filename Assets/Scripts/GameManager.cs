using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    private bool isGameStarted = false;
    private PlayerMotor motor;

    //UI and UI fields
    public TextMeshProUGUI scoreText, coinText, modifierText;
    private float score, coinScore, modifierScore;

        private void Awake()
    {
        Instance = this;
        modifierScore = 1;
        Update();
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if(MobileInput.Instance.Tap && !isGameStarted)
        {
            isGameStarted = true;
            motor.StartRunning();
        }

        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
        modifierText.text = "x" + modifierScore.ToString("0.0");
    }

    public void UpdateModifier(float modifierAmount)
    {

        modifierScore = 1.0f + modifierAmount;
        Update();


    }

   /* public void UpdateScores()
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
        modifierText.text = modifierScore.ToString();
    }*/
}
