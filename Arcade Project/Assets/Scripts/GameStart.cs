using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Text insCredits;
    public AudioSource creditSound;
    
    public IntData score;
    public IntData lives;
    public IntData credits;
    public Text scoreText;
    public Text livesText;
    public Text creditsText;
    
    void Start()
    {
        credits.value = 0;
        lives.value = 3;
        score.value = 0;
        StartCoroutine("Blinking");
    }
    
    void Update()
    {
        //Add Credits
        if (Input.GetButtonDown("Fire3"))
        {
            credits.value++;
            creditSound.Play();
        }
        
        scoreText.text = score.value.ToString();
        /*MAX SCORE
        if (score.value > 9999999)
        {
            scoreText.text = "9999999";
        }
        else
        {
            scoreText.text = score.value.ToString();
        }*/
        //MAX LIVES
        if (lives.value > 99)
        {
            livesText.text = "99";
        }
        else
        {
            livesText.text = lives.value.ToString();
        }
        //MAX CREDITS
        if (credits.value > 99)
        {
            creditsText.text = "99";
        }
        else
        {
            creditsText.text = credits.value.ToString();
        }
        //Credit Text Changer
        if (credits.value == 1)
        {
            insCredits.text = "PRESS P1 START";
        }
        else if (credits.value >= 2)
        {
            insCredits.text = "PRESS P1/P2 START";
        }
    }

    IEnumerator Blinking()
    {
        while (credits.value == 0)
        {
            insCredits.text = " ";
            yield return new WaitForSeconds(0.8f);
            insCredits.text = "INSERT CREDITS";
            yield return new WaitForSeconds(0.8f);
        }
    }
}