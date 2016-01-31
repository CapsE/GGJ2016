using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    public static int points = 0;
    public Text pointText;
    static PointCounter instance;
    private PointCounter() {
        
        CowMotor.AbductedEvent += madePoint;
    }

    public static PointCounter getInstance() {
        if(instance == null) {
            instance = new PointCounter();
        }
        instance.pointText = GameObject.Find("PointText").GetComponent<Text>();
        return instance;
    }

    // Use this for initialization
    void Start()
    {
        CowMotor.AbductedEvent += madePoint;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void madePoint(GameObject cow)
    {

        //    CowCreator.cowCount--;
        //    points++;
        if (pointText == null)
        {

            pointText = GameObject.Find("PointText").GetComponent<Text>();

            pointText.text = "Points: " + points;

        }
        else {
            pointText.text = "Points: " + points;
        }
        
        
    }


}
