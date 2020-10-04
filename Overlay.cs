using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Overlay : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI stageText;
    [Space]
    public float stageTextSize = 35;
    public float stageAdditionalSize = 5;
    public float stageAnimationSpeed;
    
    float animationTime = 0;
    int previousLevel = 0;
    [Space]
    public TextMeshProUGUI scoreText;
    public int score;
    public float scoreSpeed;
    private void Update()
    {
        stageText.SetText("Stage " + player.stage);
        scoreText.SetText(score.ToString());
        if(previousLevel != player.stage)
        {
            previousLevel = player.stage;
            animationTime = 0;
        }
    }
    private void Start()
    {
        animationTime = 0;
        StartCoroutine(levelScoreAnimation());

        StartCoroutine(scoreCounter());
    }
    IEnumerator scoreCounter()
    {
        while(true)
        {
            yield return new WaitForSeconds(scoreSpeed);
            score++;
        }
    }
    IEnumerator levelScoreAnimation()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if(animationTime < 6.28f)
            {
                animationTime += stageAnimationSpeed;
                stageText.fontSize = stageTextSize + (((Mathf.Cos(animationTime) * -0.5f) + 0.5f) * stageAdditionalSize);
            }
        }
    }
}
