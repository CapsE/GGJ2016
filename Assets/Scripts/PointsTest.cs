using UnityEngine;
using System.Collections;

public class PointsTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CowMotor.AbductedEvent += madePoint;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void madePoint(GameObject cow) {
        Debug.Log("Made a point");
    }
}
