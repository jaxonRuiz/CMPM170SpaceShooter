using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float spawn_delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 offset = Random.insideUnitSphere * 30;
            if (Mathf.Abs(offset.x) < 10)
                offset.x += Mathf.Sign(offset.x) * 10;
            if (Mathf.Abs(offset.z) < 10)
                offset.z += Mathf.Sign(offset.z) * 10;
            offset.y = 0;
            Instantiate(enemy, player.transform.position + offset, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(spawn_delay + Random.value);
        }
    }
}
