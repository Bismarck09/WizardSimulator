using UnityEditor;
using UnityEngine;

public class PlayerRevival : MonoBehaviour
{
    [SerializeField] private SceneAsset _mainScene;

    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.DiedPlayer += RevivePlayer;
    }

    private void OnDisable()
    {
        _playerHealth.DiedPlayer -= RevivePlayer;
    }

    private void RevivePlayer()
    {
        Teleportation.LoadScene(_mainScene.name);
    }
}
