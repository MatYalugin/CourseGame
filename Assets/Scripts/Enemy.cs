using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private bool dead;
    private bool hurt;
    public float Health = 100;
    public float vision;
    public float attackRadius;
    public float attackDamage;
    NavMeshAgent agent;
    public Animator animator;
    bool run;
    bool attack;
    public AudioSource AudioSource;
    public RuntimeAnimatorController animatorDeath;
    public ParticleSystem blood;
    private bool _isInFire;
    private float _normalSpeed;
    [SerializeField]private GameObject _fireEffect;

    private void Start()
    {
        tag = "Enemy";
        agent = GetComponent<NavMeshAgent>();
        _normalSpeed = agent.speed;
    }
    public void CheckAttack()
    {
        if (Physics.CheckSphere(transform.position, attackRadius, GameManager.playerLayer) && hurt == false)
        {
            attack = true;
            animator.Play("Attack");
        }
    }
    private void ChasePlayer()
    {
        if (Physics.CheckSphere(transform.position, vision, GameManager.playerLayer) && attack == false)
        {
            agent.SetDestination(GameManager.player.transform.position);
            if (run == false && hurt == false)
            {
                run = true;
                animator.Play("Move");
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            if (run == true)
            {
                run = false;
                animator.Play("Idle");
            }
        }
    }
    public void AttackPlayer()
    {
        AudioSource.Play();
        if (Physics.CheckSphere(transform.position, attackRadius, GameManager.playerLayer))
        {
            GameManager.player.Hurt(attackDamage);
        }
    }
    public void AttackEnd()
    {
        attack = false;
    }
    public void Update()
    {
        if (dead == false)
        {
            ChasePlayer();
            CheckAttack();
        }
    }

    public void Hurt(float Damage)
    {
        hurt = true;
        animator.Play("Hurt");
        if(!_isInFire)
            blood.Play();
        Health = Health - Damage;
        if (Health <= 0)
        {
            blood.Stop();
            Destroy(_fireEffect);
            dead = true;
            agent.SetDestination(transform.position);
            animator.runtimeAnimatorController = animatorDeath;
            GameManager.killScoreText.GetComponent<Score>().plusKill();
        }
    }
    public void StartHurt()
    {
        hurt = true;
        run = false;
        agent.speed /= 2;
    }
    public void EndHurt()
    {
        hurt = false;
        run = true;
        agent.speed = _normalSpeed;
    }
    public void ScreenBloodOff()
    {
        GameManager.playerScreenBlood.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            _isInFire = true;
            StartCoroutine(FireDamage(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            Invoke("IsInFireFalse", 3f);
        }
    }
    private IEnumerator FireDamage(GameObject fire)
    {
        _fireEffect.SetActive(true);
        while (_isInFire)
        {
            Hurt(5);
            yield return new WaitForSeconds(0.5f);
            if (fire == null)
            {
                _fireEffect.SetActive(false);
                break;
            }
            if (!_isInFire)
            {
                _fireEffect.SetActive(false);
                break;
            }
        }
    }
}
