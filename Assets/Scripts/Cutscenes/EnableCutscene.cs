using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCutscene : MonoBehaviour
{
    [SerializeField] private GameObject _startCutscene;
    [SerializeField] private StartSpawn _startSpawn;


    private void OnEnable()
    {
        _startSpawn.StartedSpawning += EnableStartCutscene;
    }

    private void OnDisable()
    {
        _startSpawn.StartedSpawning -= EnableStartCutscene;
    }

    private void EnableStartCutscene()
    {
        _startCutscene.SetActive(true);
    }
}
