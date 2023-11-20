using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRenderer : MonoBehaviour
{
    Renderer rend;
    [SerializeField] bool enable = false;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update() {
        rend.enabled = enable;
    }
}