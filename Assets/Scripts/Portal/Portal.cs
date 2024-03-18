using UnityEditor;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Teleportation.LoadScene(_scene.name);
        }

    }
}
