// using System.Collections;
// using UnityEngine;

// public class tilemap : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     private PlatformEffector2D platformEffector2D;
//     void Awake()
//     {
//         platformEffector2D = GetComponent<PlatformEffector2D>();

//     }
//     private LayerMask groundLayer;
//     private Rigidbody2D rb;
//     private Collider2D playerCollider;

//     void Start()
//     {
//         playerCollider = GetComponent<Collider2D>();
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.S))
//         {
//             StartCoroutine(DisableCollision());
//         }
//     }

//     private IEnumerator DisableCollision()
//     {
//         // Ignore collision between player and ground
//         Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
//                                        LayerMask.NameToLayer("ground"), true);

//         // Small downward push so player doesn’t stay inside collider
//         rb.linearVelocity = new Vector2(rb.linearVelocity.x, -2f);

//         yield return new WaitForSeconds(0.3f); // duration of "fall through"

//         // Re-enable collisions
//         Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
//                                        LayerMask.NameToLayer("ground"), false);
//     }

// }
