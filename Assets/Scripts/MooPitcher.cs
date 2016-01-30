using UnityEngine;
using System.Collections;

public class MooPitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
