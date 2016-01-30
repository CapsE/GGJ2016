using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    public static int points = 0;
    public Text pointText;
    // Use this for initialization
    void Start()
    {
        CowMotor.AbductedEvent += madePoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void madePoint(GameObject cow)
    {
        CowCreator.cowCount--;
        points++;
        pointText.text = "Points: "+points;
        Debug.Log("Made a point");
    }
}
