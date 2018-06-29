using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIattack : MonoBehaviour {

    public string scene;
    public Color loadToColor = Color.white;
    public float speed;
    public float health = 50f;

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;
    Animator anim;

    // Use this for initialization
    void Start () {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
	}

    void Update()
    {
        SetDestination();
    }
	
    private void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            anim.SetBool("animAttack", true);
            anim.SetBool("animRun", false);
            anim.SetBool("animDamage", false);
            anim.SetBool("animDeath", false);
            GoFade();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        anim.SetBool("animDamage", true);
        anim.SetBool("animRun", false);
        anim.SetBool("animAttack", false);
        anim.SetBool("animDeath", false);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("animDeath", true);
        anim.SetBool("animRun", false);
        anim.SetBool("animDamage", false);
        anim.SetBool("animAttack", false);
        Destroy(gameObject, 3f);
    }

    public void GoFade()
    {
        Initiate.Fade(scene, loadToColor, speed);
    }
}
