using UnityEngine;
using System.Collections;

public class RingBehave : MonoBehaviour {

    public GameObject ring;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Vector3 position = new Vector3(Random.Range(260.0F, 360.0F), Random.Range(-10.0F, 10.0F), other.gameObject.transform.position.z +45);
        GameObject b = Instantiate(ring, position, Quaternion.identity) as GameObject;
        b.transform.Rotate(new Vector3(90,0,0));
        Destroy(gameObject);
    }
}
