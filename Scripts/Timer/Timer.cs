using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //public GameObject Game_Manager;

    public Text TimerText;
    public float StartTime;
    public float ti;

    public bool GameEnded = false;

    public string HS_min;
    public string HS_sec;

    public Text Current_Time;
    public Text HS_text;


    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        HS_min = PlayerPrefs.GetInt("HighScore_min", 0).ToString();
        HS_sec = PlayerPrefs.GetInt("HighScore_sec", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameEnded){
            ti = Time.time - StartTime;
        
            int mins = ((int)ti / 60);
            int secs = ((int)ti % 60);

            string Minutes = mins.ToString();
            string Seconds = secs.ToString();

            if(mins > PlayerPrefs.GetInt("HighScore_min", 0)){
                PlayerPrefs.SetInt("HighScore_min", mins);
                PlayerPrefs.SetInt("HighScore_sec", secs);
                HS_min = PlayerPrefs.GetInt("HighScore_min", mins).ToString();
                HS_sec = PlayerPrefs.GetInt("HighScore_sec", secs).ToString();
            }
            if(mins == PlayerPrefs.GetInt("HighScore_min", 0)){
                if(secs >= PlayerPrefs.GetInt("HighScore_sec", 0)){
                    PlayerPrefs.SetInt("HighScore_min", mins);
                    PlayerPrefs.SetInt("HighScore_sec", secs);
                    HS_min = PlayerPrefs.GetInt("HighScore_min", mins).ToString();
                    HS_sec = PlayerPrefs.GetInt("HighScore_sec", secs).ToString();
                }
            }


            TimerText.text = Minutes + " min " + Seconds + " sec";
            Current_Time.text = Minutes + " min " + Seconds + " sec";
        }

        HS_text.text = HS_min + " min " + HS_sec + " sec";
    }
}
