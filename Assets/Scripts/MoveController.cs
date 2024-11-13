using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [SerializeField] Rigidbody2D Rigidbody2D;
    #endregion

    #region Properties
    [Header("Properties")]
    [SerializeField] float moveSpeed;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 currentVelocity = new Vector2(horizontal * moveSpeed, 0 );

        Rigidbody2D.velocity = currentVelocity;


        if (isDevMode)
        {
            Debug.Log($"Velocity : {currentVelocity}");
        }
    }
}
