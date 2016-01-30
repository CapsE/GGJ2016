using UnityEngine;
using System.Collections;

public class UfoRotate : MonoBehaviour {


    public Vector3 rotateSpeed = new Vector3(0, 0.0001f, 0);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(rotateSpeed);
	}
}
