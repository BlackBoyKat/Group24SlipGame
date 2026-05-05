using System.Collections; 
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject beat;

    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    public IEnumerator StartSpawn()
    {
        while (true)
        {
            GameObject newbeat = Instantiate(beat);
            newbeat.transform.position = new Vector2(Random.value*5-3,Random.value*3-2);//position of tthe buttons
            Destroy(newbeat, 1.5f);//destroys object after 1.5

            yield return new WaitForSeconds(1f); //respawns after a second
        }
    }
} 
