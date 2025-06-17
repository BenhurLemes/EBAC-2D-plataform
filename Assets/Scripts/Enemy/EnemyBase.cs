using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] int damage = 5;
    [SerializeField] float speed = 2f;
    
    private Transform target;
    private Vector2 startPosition;
    private bool startFollow = false;

    private void Start()
    {
        startPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (startFollow && target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startFollow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startFollow = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.transform.name);
        }

        var heath = collision.gameObject.GetComponent<HeathBase>(); // pega o componente vida do player
        if (heath != null)
        {
            heath.Damage(damage);
            StartCoroutine(DelayAttack());
        }
    }
    
    public IEnumerator DelayAttack()
    {
        startFollow = false;
        yield return new WaitForSeconds(1f);
    }
}

// trigger pega o collider
// collision pega a colisão por isso precisa do game object pro getcomponent