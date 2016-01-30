using UnityEngine;
using System.Collections;

public class RandomMooh : MonoBehaviour {

    public float factor = 10;

    private AudioSource audioSource;
    private float chance = 0;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        chance += 0.1f;
        float x = Random.Range(0.0f, chance);
        if(chance >= factor && !audioSource.isPlaying) {
            audioSource.pitch = Random.Range(0.6f, 1.5f);
            audioSource.Play();
            chance = 0;
        }
	}
}
