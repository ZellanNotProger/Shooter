using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _player;
    private Vector3 _moveDirection;
    private float _xMove;
    private float _zMove;
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private void Start()
    {
        _player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _xMove = Input.GetAxis(_horizontal);
        _zMove = Input.GetAxis(_vertical);

        _moveDirection = new Vector3(_xMove, 0f, _zMove);
        _moveDirection = transform.TransformDirection(_moveDirection);

        _player.Move(_moveDirection * _speed * Time.deltaTime);
    }
}
