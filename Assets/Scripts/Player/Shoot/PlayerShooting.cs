using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private const string _layerName = "NoShoot";

    [SerializeField] private DamageMagicCreator _damageMagicCreator;
    [SerializeField] private ReactionShoot _reactionShoot;
    [SerializeField] private DamageMagicImprovement _damageMagicImprovement;

    private RaycastHit hit;

    private float elapsedTimeAfterShooting = 1;
    private bool _isShooting;

    private void Awake()
    {
        _isShooting = false;
    }

    private void Update()
    {
        elapsedTimeAfterShooting += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _isShooting)
            ShootMagic();
    }

    private void ShootMagic()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject != gameObject && hit.collider.gameObject.layer != LayerMask.NameToLayer(_layerName))
        {
            _damageMagicCreator.TryMagicCreate(hit.point, ref elapsedTimeAfterShooting, gameObject, _reactionShoot.EnableSound, _reactionShoot.EnableAnimation, _damageMagicImprovement.DamageMagicLevel);
        }
    }

    public void EnableShooting()
    {
        _isShooting = true;
    }
}
