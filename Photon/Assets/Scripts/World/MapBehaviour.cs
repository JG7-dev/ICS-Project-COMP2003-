using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _groundPlane;
    [SerializeField] private GameObject _mapPlane;
    [SerializeField] private GameObject _playerController;
    [SerializeField] private GameObject _playerMapMarker;
    [SerializeField] private Color _playerMapMarkerColor = Color.green;
    // Start is called before the first frame update
    void Start()
    {
        var _cylinderRenderer = _playerMapMarker.GetComponent<Renderer>();
        _cylinderRenderer.material.SetColor("_Color", _playerMapMarkerColor);
    }

    // Update is called once per frame
    void Update()
    {
        var _xScale = _mapPlane.transform.localScale.x / _groundPlane.transform.localScale.x;
        if (_xScale < 0) _xScale *= -1;

        var _yScale = _mapPlane.transform.localScale.y / _groundPlane.transform.localScale.z;
        if (_yScale < 0) _yScale *= -1;

        var _posX = _mapPlane.transform.position.x + (_playerController.transform.position.x * _xScale);
        var _posY = _mapPlane.transform.position.y - (_playerController.transform.position.z * _yScale);
        var _posZ = _mapPlane.transform.position.z;

        Vector3 _newPoss = new Vector3(_posX, _posY, _posZ);
        _playerMapMarker.transform.position = _newPoss;
    }
}
