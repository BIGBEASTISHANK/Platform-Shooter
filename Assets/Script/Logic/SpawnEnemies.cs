using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Variables
    /////////////

    private bool spawnBool = true;

    [Header("Values")]
    [SerializeField] private float Ypos;
    [SerializeField] private float minPos;
    [SerializeField] private float maxPos;
    [SerializeField] private float tBwSpwn;

    [Header("Components & Others")]
    [SerializeField] private GameObject enemy;

    // References
    //////////////

    private void FixedUpdate()
    {
        // Spawn function
        if (spawnBool)
            StartCoroutine(Spawn());
    }

    // Spawn function
    IEnumerator Spawn()
    {
        spawnBool = false;

        // Getting Spawn point
        Vector2 spawnPos = new Vector2(Random.Range(minPos, maxPos), Ypos);

        // Spawning enemy
        GameObject spawnedEnemy = Instantiate(enemy, spawnPos, enemy.transform.rotation);
        spawnedEnemy.SetActive(true);

        // Waiting for second before spawning another
        yield return new WaitForSeconds(tBwSpwn);

        spawnBool = true;
    }
}
