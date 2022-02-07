using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ColorChanger : MonoBehaviour, IInteractable {
 
    [SerializeField] private Material _mat;
 
    private void Start() {
        _mat = GetComponent<MeshRenderer>().material;
    }
 
    public string GetDescription() {
        return "Change to a random colour";
    }
 
    public void Interact() {
        _mat.color = new Color(Random.value, Random.value, Random.value);
    }
}