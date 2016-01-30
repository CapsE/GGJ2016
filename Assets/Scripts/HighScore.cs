using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour {

    public int curPoints = 2;
    string path = @".\highscore.txt";
    //[Platz-1, 1:Kürzel 2: Score]
    public string[,] highScore = new string[10, 3];
    public Text[] scoreText;
    public bool beat = false;


    // Use this for initialization
    void Start () {

        if (!File.Exists(path))
        {
            string[] lines = { "1:abc:0:", "2:abc:0:", "3:abc:0:", "4:abc:0:", "5:abc:0:", "6:abc:0:", "7:abc:0:", "8:abc:0:", "9:abc:0:", "10:abc:0" };
            System.IO.File.WriteAllLines(path, lines);
        }
        else {
            string text = System.IO.File.ReadAllText(path);
            string[] input = text.Split(':');
            int count = 0;
            int j = 0;
            for (int i = 0; j < 10; i++) {
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
                else if (count == 2) {
                    highScore[j, 2] = input[i];
                    count = 0;
                    j++;
                }
            }
        }

        string kurzBuf1= "";
        string pointBuf1 = "";
        string kurzBuf2 = "";
        string pointBuf2 = "";
        int switcharoo= 0;

        for (int i = 0; i < 10; i++) {
            if (beat && switcharoo == 0)
            {
                kurzBuf2 = highScore[i, 1];
                pointBuf2 = highScore[i, 2];
                highScore[i, 1] = kurzBuf1;
                highScore[i, 2] = pointBuf1;
                switcharoo = 1;
            }
            else if (beat && switcharoo == 1) {
                kurzBuf1 = highScore[i, 1];
                pointBuf1 = highScore[i, 2];
                highScore[i, 1] = kurzBuf2;
                highScore[i, 2] = pointBuf2;
                switcharoo = 0;
            }
            if (curPoints > Int32.Parse(highScore[i, 2])) {
                //Anzeige fenster zur eingabe fehlt
                Debug.Log("drin");
                kurzBuf1 = highScore[i, 1];
                pointBuf1 = highScore[i, 2];
                highScore[i, 1] = "blah";
                highScore[i, 2] = curPoints+"";
                beat = true;
                curPoints = 0;
            }
            scoreText[i].text = highScore[i, 1] + " " + highScore[i, 2];
        }
        beat = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}
