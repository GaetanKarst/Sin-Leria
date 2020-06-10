using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabArray;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawn = true;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);//spawn one of the attacker initialized within the array
    }

    private void Spawn(Attacker myAttacker)//Passed in value is defined in the line above
    {
        Attacker newAttacker = Instantiate<Attacker>(myAttacker, transform.position,
            Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;//place the newAttacker below the GameObject spawner in the hierarchy (Keeps the hierarchy clean)
    }
}
