using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    public int score;
    public int totallines;
    public float level = 1f;
    public float togo = 5f;
    public Text textComponent;

    public static float t;
    void UpdateText () {
        textComponent.text ="Tetris \nScore: " + score + " \nLines: " + totallines + "/" + togo +"\n\nLevel: " + level;
    }
    void Awake() {
        //t=Mathf.Pow(0.8f-((level-1)*0.007f), level-1);
        t = 1;
        UpdateText();
    }
    void updateLevel()
    {
        level++;
        togo = level*5f;
        t=Mathf.Pow(0.8f-((level-1)*0.007f), level-1);
    }
    
    public void UpdateScore(int lines) {
        totallines += lines;
        switch (lines)
        {
            case 4:
                score += 8;
                break;
            case 3:
                score += 5;
                break;
            case 2:
                score += 3;
                break;
            default:
                score += 1;
                break;
        }
        if (totallines >= togo) {
            updateLevel();
        }
        UpdateText();
    }

}
