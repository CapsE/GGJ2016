using UnityEngine;
using System.Collections;

public class CowCreator : MonoBehaviour {

    public GameObject cow;
    public static int cowCount = 0;
    public int cowMax = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CowCreator.cowCount < cowMax) {
            cowCount++;
            Instantiate(cow, new Vector3(218, 0, 233), Quaternion.identity);
        }
	
	}
}
