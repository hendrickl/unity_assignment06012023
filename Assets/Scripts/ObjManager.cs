using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    private Vector3 _clickPosition;
    private int _numberOfObj = 0;
    private bool _canInstantiate = true;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateObj();
        // InstantiateObjOnNumberMax();
    }

    // Instantiate object at mouse position and on click
    void InstantiateObj()
    {
        _clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f));

        if (Input.GetKeyUp(KeyCode.Mouse0) && _numberOfObj < 10)
        {
            GameObject.Instantiate(_prefab, _clickPosition, Quaternion.identity);

            Debug.Log(_numberOfObj + " objects instantiated");

            _numberOfObj++;

            _prefabs.Add(_prefab);
            Debug.Log(String.Join(", ", _prefabs));

        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && _numberOfObj > 9)
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject.Instantiate(_prefabs[i], _clickPosition, Quaternion.identity);
                Debug.Log("POOL triggered at " + _prefabs[i]);

            }
        }
    }
}