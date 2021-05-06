using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = ""+score.ToString();
    }

    public void setText(Text newText)
    {
        text = newText;
    }

    public int getScore()
    {
        return score;
    }
}
