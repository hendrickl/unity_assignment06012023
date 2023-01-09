using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    private Vector3 _mousePosition;
    private int _numberOfObj = 0;
    private float _distanceToCam = 10f;
    private List<GameObject> _prefabs = new List<GameObject>();

    [SerializeField] private GameObject _objToSpawn;

    // Update is called once per frame
    void Update()
    {
        InstantiateObjAtMousePosition();
    }

    // Instantiate object at mouse position and on click
    void InstantiateObjAtMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distanceToCam));

        if (Input.GetKeyUp(KeyCode.Mouse0) && _numberOfObj < 10)
        {
            GameObject _prefab = Instantiate(_objToSpawn, _mousePosition, Quaternion.identity);
            _numberOfObj++;
            _prefabs.Add(_prefab);
            Debug.Log(String.Join(", ", _prefabs));
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && _numberOfObj > 9)
        {
            GameObject newobjectspawned = _prefabs[0];
            newobjectspawned.transform.position = _mousePosition;
            _prefabs.RemoveAt(0);
            _prefabs.Add(newobjectspawned);
        }
    }
}