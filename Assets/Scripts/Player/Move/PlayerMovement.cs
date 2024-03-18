using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed;
 
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private MoveAnimation _moveAnimation;

    private bool _isMoving;

    private void Awake()
    {
        _isMoving = false;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveAnimation = GetComponent<MoveAnimation>();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            Move();
    }

    private void Move()
    {
        _moveDirection = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));

        CheckSticking();

        Vector3 localDirection = transform.TransformDirection(_moveDirection);

        _rigidbody.velocity = localDirection * _moveSpeed;
        _moveAnimation.StartAnimation(_moveDirection);
    }

    private void CheckSticking()
    {
        if (Mathf.Abs(_moveDirection.x) < 0.01f)
            _moveDirection.x = 0;
        if (Mathf.Abs(_moveDirection.z) < 0.01f)
            _moveDirection.z = 0;
    }

    private IEnumerator EnableMovementSkill(float workTime)
    {
        _moveSpeed *= 2;
        yield return new WaitForSeconds(workTime);

        _moveSpeed /= 2;
    }

    public void StartMovementSkill(float workTime)
    {
        StartCoroutine(EnableMovementSkill(workTime));
    }

    public void EnableMoving()
    {
        _isMoving = true;
    }

}
