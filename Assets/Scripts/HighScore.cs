using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    public int curPoints = 2;
    string path = @".\highscore.txt";
    //[Platz-1, 1:Kürzel 2: Score]
    public string[,] highScore = new string[10, 3];
    public Text[] scoreText;
    public bool beat = false;
    public InputField playerInput;
    public Canvas canvasScore;
    public Canvas canvasNew;
    public Text newScore;

    // Use this for initialization
    void Start()
    {
        curPoints = PointCounter.points;
        PointCounter.points = 0;
        if (!File.Exists(path))
        {
            string[] lines = { "1:abc:0:", "2:abc:0:", "3:abc:0:", "4:abc:0:", "5:abc:0:", "6:abc:0:", "7:abc:0:", "8:abc:0:", "9:abc:0:", "10:abc:0" };
            System.IO.File.WriteAllLines(path, lines);
        }
        else
        {
            string text = System.IO.File.ReadAllText(path);
            string[] input = text.Split(':');
            int count = 0;
            int j = 0;
            for (int i = 0; j < 10; i++)
            {
                if (count == 0)
                {
                    highScore[j, 0] = input[i];
                    count++;
                }
                else if (count == 1)
                {
                    highScore[j, 1] = input[i];
                    count++;
                }
                else if (count == 2)
                {
                    highScore[j, 2] = input[i];
                    count = 0;
                    j++;
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (curPoints > Int32.Parse(highScore[i, 2]))
            {
                Debug.Log("ddrin");
                canvasNew.gameObject.SetActive(true);
                newScore.text = curPoints + "";
                beat = true;
            }

        }
        if (!beat)
        {
            canvasScore.gameObject.SetActive(true);
            for (int i = 0; i < 10; i++)
            {
                int spaces = 20;
                string empty = "";
                for (int x = highScore[i, 1].Length; x < spaces; x++) {
                    empty += " ";
                }
                scoreText[i].text = highScore[i, 1] + empty + highScore[i, 2];
            }
        }
        beat = false;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }

    public void NewHighScore()
    {

        //Write Score
        string kurzBuf1 = "";
        string pointBuf1 = "";
        string kurzBuf2 = "";
        string pointBuf2 = "";
        int switcharoo = 0;

        for (int i = 0; i < 10; i++)
        {
            if (beat && switcharoo == 0)
            {
                kurzBuf2 = highScore[i, 1];
                pointBuf2 = highScore[i, 2];
                highScore[i, 1] = kurzBuf1;
                highScore[i, 2] = pointBuf1;
                switcharoo = 1;
            }
            else if (beat && switcharoo == 1)
            {
                kurzBuf1 = highScore[i, 1];
                pointBuf1 = highScore[i, 2];
                highScore[i, 1] = kurzBuf2;
                highScore[i, 2] = pointBuf2;
                switcharoo = 0;
            }
            Debug.Log("curPoints: " + curPoints);
            Debug.Log("bl " + Int32.Parse(highScore[i, 2]));
            Debug.Log(curPoints > Int32.Parse(highScore[i, 2]));
            if (curPoints > Int32.Parse(highScore[i, 2]))
            {
                //Anzeige fenster zur eingabe fehlt
                Debug.Log("drin");
                kurzBuf1 = highScore[i, 1];
                pointBuf1 = highScore[i, 2];
                highScore[i, 1] = playerInput.text;
                highScore[i, 2] = curPoints + "";
                beat = true;
                curPoints = 0;
            }
            int spaces = 20;
            string empty = "";
            for(int x = highScore[i, 1].Length; x < spaces; x++) {
                empty += " ";
            }
            scoreText[i].text = highScore[i, 1] + empty + highScore[i, 2];
        }
        beat = false;
        canvasNew.gameObject.SetActive(false);
        canvasScore.gameObject.SetActive(true);
        //write data to file
        string[] lines = { "1:" + highScore[0, 1] + ":" + highScore[0, 2] + ":", "2:" + highScore[1, 1] + ":" + highScore[1, 2] + ":", "3:" + highScore[2, 1] + ":" + highScore[2, 2] + ":", "4:" + highScore[3, 1] + ":" + highScore[3, 2] + ":", "5:" + highScore[4, 1] + ":" + highScore[4, 2] + ":", "6:" + highScore[5, 1] + ":" + highScore[5, 2] + ":", "7:" + highScore[6, 1] + ":" + highScore[6, 2] + ":", "8:" + highScore[7, 1] + ":" + highScore[7, 2] + ":", "9:" + highScore[8, 1] + ":" + highScore[8, 2] + ":", "10:" + highScore[9, 1] + ":" + highScore[9, 2] };
        System.IO.File.WriteAllLines(path, lines);
    }

    public void NewGame() {
        canvasScore.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
