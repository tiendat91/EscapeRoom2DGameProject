using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    public GameObject healthText;
    public bool disableSimulation = false;
    public bool canTurnInvincible = false;
    public float invincibilityTime = 0.25f;

    Animator animator;
    Rigidbody2D rigidbody;
    Collider2D physicsCollider;

    bool isAlive = true;
    private float invincibleTimeElapsed = 0;

    //TEST
    public float _health = 3;
    public bool _targetable = true;
    public bool _invincible = true;

    public float Health
    {
        set
        {
            //when health is dropped (new value less than old value), play hit animation and show damage taken as text
            if (value > _health)
            {
                animator.SetTrigger("hit");

                //Spawn damage text right above the character
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }
            _health = value;
            if (_health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get
        {
            return _health;
        }

    }
    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;
            if (disableSimulation)
            {
                rigidbody.simulated = false;
            }

            physicsCollider.enabled = value;
        }
    }
    public bool Invincible
    {
        get
        {
            return _invincible;
        }
        set
        {
            _invincible = value;
        }
    }

    //Take damage with knockback,
    public void OnHit(float damage, Vector2 knockback)
    {
        if (!Invincible)
        {
            Health -= damage;

            //Apply force to the slime
            //Impulse for instantaneous forces
            rigidbody.AddForce(knockback, ForceMode2D.Impulse);

            if (canTurnInvincible)
            {
                //Activate Invincibility and timer
                Invincible = true;
            }

        }
    }


    //Take damgage without knockback
    public void OnHit(float damage)
    {
        if (!Invincible)
        {
            Health -= damage;
            if (canTurnInvincible)
            {
                //Active invincibility and timer
                Invincible = true;
            }
        }
    }

    public void OnObjectDestroyed()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        //Make sure the slime is alive at the start of its scipts
        animator.SetBool("isAlive", isAlive);
        rigidbody = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    void Update()
    {

    }
}