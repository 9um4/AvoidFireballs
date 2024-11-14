using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class MoveController : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] Rigidbody2D Rigidbody2D;
    [SerializeField] Animator Animator;
    #endregion

    #region Properties
    [Header("Properties")]
    [SerializeField] float moveSpeed;
    [SerializeField] RuntimeAnimatorController controller;
    #endregion

    #region Developer Option
    [Header("Developer Option")]
    [SerializeField] bool isDevMode = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (Rigidbody2D.IsUnityNull())
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            if (Rigidbody2D.IsUnityNull())
            {
                Rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
            }
        }
        Rigidbody2D.gravityScale = 0f;

        if (Animator.IsUnityNull())
        {
            Animator = gameObject.AddComponent<Animator>();
            if (Animator.IsUnityNull())
            {
                Animator = gameObject.AddComponent<Animator>();
            }
            Animator.runtimeAnimatorController = controller;
        }

        if (SpriteRenderer.IsUnityNull())
        {
            SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (SpriteRenderer.IsUnityNull())
            {
                gameObject.AddComponent<SpriteRenderer>();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        Animation();

        if (isDevMode)
        {
            Debug.Log($"Velocity : {Rigidbody2D.velocity}");
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 currentVelocity = new Vector2(horizontal * moveSpeed, 0);

        Rigidbody2D.velocity = currentVelocity;
    }

    void Animation()
    {
        float velocityX = Rigidbody2D.velocity.x;

        if (velocityX == 0)
        {
            Animator.SetBool("IsMoving", false);
            return;
        }
        Animator.SetBool("IsMoving", true);
        if (velocityX < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else
        {
            SpriteRenderer.flipX = false;
        }
    }
}
