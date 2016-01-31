using UnityEngine;
using System.Collections;

public class LightStabilizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + new Vector3(0, -100, 0));
    }
}
