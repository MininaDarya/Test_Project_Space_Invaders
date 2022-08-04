using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    public int _hp;
    public float _speed;

    public enum Direction { 
        left, right
    };

    public Direction _direction = Direction.left;

    private float _sideDirection;

    private void Start()
    {
        if (_direction == Direction.left)
        {
            _sideDirection = -1;
        }
        else if (_direction == Direction.right) 
        {
            _sideDirection = 1;
        }
    }

    private void Update()
    {
        Move();
    }

    void Move() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(_sideDirection, 0) * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet_Behaviour>()) {
            _hp--;
            if (_hp <= 0) {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.GetComponent<BoxCollider2D>()) {
            _sideDirection *= -1;
        }
    }
}
