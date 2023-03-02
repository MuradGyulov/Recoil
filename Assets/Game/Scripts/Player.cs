using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float recoilForce;
    [Space(20)]
    [SerializeField] private Rigidbody rigidBody;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.AddForce(transform.right * -recoilForce, ForceMode.Impulse);
        }
    }
}
