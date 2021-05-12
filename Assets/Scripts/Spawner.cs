using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] templates;
    [SerializeField] private float spawnDelay;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int footNumber = Random.Range(0, templates.Length);
            Instantiate(templates[footNumber], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
