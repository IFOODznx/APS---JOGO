using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objetos;
    public Transform spawnPoint;

    public float tempoSpawn = 0.5f;
    public float tempoDestruir;

    void Start()
    {
        InvokeRepeating(nameof(Spawnar), 1f, tempoSpawn);
    }

    void Spawnar()
    {
        GameObject objeto = objetos[Random.Range(0, objetos.Length)];

        GameObject novo = Instantiate(
            objeto,
            spawnPoint.position,
            Quaternion.identity
        );

        Destroy(novo, tempoDestruir);
    }
}
