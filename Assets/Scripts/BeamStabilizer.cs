using UnityEngine;
using System.Collections;

public class BeamStabilizer : MonoBehaviour {

    public Transform anchor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Vector3.left);
        transform.position = anchor.position;

    }
}
