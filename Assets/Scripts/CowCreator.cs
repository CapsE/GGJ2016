using UnityEngine;
using System.Collections;

public class CowCreator : MonoBehaviour {

    public GameObject cow;
    public static int cowCount = 23;
    public int cowMax = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CowCreator.cowCount < cowMax) {
            cowCount++;
            Vector3 position = new Vector3(Random.Range(120.0F, 390.0F), 0.5f, Random.Range(93,400.0F));
            Instantiate(cow, position, Quaternion.identity);
        }
	
	}
}
