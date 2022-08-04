using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Behaviour : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;

    public float _speed = 3f;
    public float _bulletSpeed = 3f;

    private float _horInput;
    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementLogic();
        ShootLogic();
    }

    void MovementLogic() {
        _horInput = Input.GetAxisRaw("Horizontal");
        _body.velocity = new Vector2(_horInput, 0) * _speed;
    }

    void ShootLogic()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 _bulletPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
            GameObject _bullet = Instantiate(_prefabBullet, _bulletPosition, transform.rotation);
            _bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * _bulletSpeed;
        }
    }
}
