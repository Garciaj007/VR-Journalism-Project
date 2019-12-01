using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IndRotatationController : MonoBehaviour
{
    [SerializeField] private float Speed;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), Speed * Time.deltaTime);
    }
}
