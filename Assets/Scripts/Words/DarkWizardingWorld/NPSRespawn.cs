using System;
using System.Collections;
using UnityEngine;

public class NPSRespawn : MonoBehaviour
{
    [SerializeField] private float _respawnTime;

    public void RespawnNPS(NPS nps, Action recoveryLives)
    {
        StartCoroutine(RespawnWithDelay(nps, recoveryLives));
    }

    private IEnumerator RespawnWithDelay(NPS nps, Action recoveryLives)
    {
        yield return new WaitForSeconds(_respawnTime);
        nps.gameObject.SetActive(true);
        recoveryLives();
    }
}
