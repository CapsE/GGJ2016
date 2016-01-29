using UnityEngine;
using System.Collections;

public class CowCreator : MonoBehaviour {

    public GameObject cow;
    public int cowCount = 20;
    public int cowMax = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (cowCount < cowMax) {
            cowCount++;
            Instantiate(cow, new Vector3(250, 1, 250), Quaternion.identity);
        }
	
	}
}
