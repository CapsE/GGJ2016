using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeLeft = 120.0f;
    public Text text;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left: " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            //Application.LoadLevel("gameOver");
            text.text = "Game Over";
        }
    }
}
