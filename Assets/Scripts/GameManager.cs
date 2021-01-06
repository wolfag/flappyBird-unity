using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string HIGH_SCORE = "HIGH_SCORE";
    private const string FIRST_TIME = "FIRST_TIME";

    void _MakeSingleInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        _MakeSingleInstance();
        _IsGameStartForTheFirstTime();
    }

    void _IsGameStartForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey(FIRST_TIME))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(FIRST_TIME, 0);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
