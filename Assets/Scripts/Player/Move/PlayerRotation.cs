using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private const string MouseX = "Mouse X";

    [SerializeField] private float _rotateSpeed;

    private bool _isRotation;

    private void Awake()
    {
        _isRotation = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && _isRotation)
            Rotate();
    }

    private void Rotate()
    {
        float direction = Input.GetAxis(MouseX);

        gameObject.transform.Rotate(new Vector3(0, direction * _rotateSpeed * Time.deltaTime, 0));
    }

    public void EnableRotation()
    {
        _isRotation = true;
    }
}
