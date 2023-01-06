using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private Vector3 _clickPosition;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateObj();
    }

    void InstantiateObj()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.0f));
            GameObject.Instantiate(_prefab, _clickPosition, Quaternion.identity);
        }
    }
}
