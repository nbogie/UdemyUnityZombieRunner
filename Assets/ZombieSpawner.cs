using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int numZombiesToSpawn = 10;



    public void SpawnManyZombies(Vector3 centrePos, Transform target)
    {
        for (int i = 0; i < numZombiesToSpawn; i++)
        {
            
            Vector3 pos = centrePos
                + (Vector3)(Random.insideUnitCircle).normalized * 10f
                                                    + Vector3.up * 0.4f;  // TODO: raycast down to find terrain hit.
            SpawnZombie(pos, target);
        }
    }

    private void SpawnZombie(Vector3 pos, Transform target)
    {

        GameObject zombieClone = Instantiate(zombiePrefab, pos, Quaternion.identity);
        zombieClone.transform.SetParent(this.transform);

        zombieClone.GetComponent<AICharacterControl>().SetTarget(target);
        zombieClone.GetComponent<ThirdPersonCharacter>().SetMoveSpeedMultiplier(Random.Range(0.3f, 1.5f));
    }
}
