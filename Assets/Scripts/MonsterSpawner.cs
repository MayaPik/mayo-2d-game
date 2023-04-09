using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform rightPos;

    private int randomIndex;

    private void Start()
    {
        StartCoroutine(SpawnedMonster());
    }

    private IEnumerator SpawnedMonster() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(3,6));

            randomIndex = Random.Range(0, monsterReference.Length);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            spawnedMonster.transform.position  = rightPos.position;
            spawnedMonster.GetComponent<Monster>().speed = -(Random.Range(4,10));
            spawnedMonster.GetComponent<Monster>().hightOfGhost = (Random.Range(-3,3));
            spawnedMonster.GetComponent<Monster>().jumpForce = (Random.Range(8,13));
            spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f);
        }
    }
}

