using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnemyBase : MonoBehaviour
{
    [Header("Variáveis HeathBase")]
    [SerializeField] HeathBase heath;

    [Header("Variáveis privadas")]
    [SerializeField] int damage = 5;
    [SerializeField] float speed = 2f;
    private Transform target;
    private Vector2 startPosition;
    private bool startFollow = false;
    private Rigidbody2D Rb;

    //--------------------------//

    [Header("Variáveis Animação")]
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerRun = "Run";


    #region UNITY METHODS

    private void Start()
    {
        startPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        heath = GetComponent<HeathBase>();
    }

    private void Update()
    {
        if (startFollow && target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetBool(triggerRun, true);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            animator.SetBool(triggerRun, true);
        }
        animator.SetBool(triggerRun, false);
    }

    #endregion

    #region PRIVATE METHODS

    public void HeathDamage(int damage)
    {
        heath.Damage(damage);
    }

    public void AttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    public IEnumerator DelayAttack()
    {
        AttackAnimation();
        startFollow = false;
        yield return new WaitForSeconds(1f);
    }
    #endregion

    #region COLLSION AND TRIGGERS
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
            var player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.HeathDamage(damage);
                StartCoroutine(DelayAttack());
            }
        }

        if (collision.gameObject.CompareTag("projecttile"))
        {
            var projecttile = collision.gameObject.GetComponent<ProjecttileBase>();
        }
    }
    #endregion
}

// trigger pega o collider
// collision pega a colisão por isso precisa do game object pro getcomponent