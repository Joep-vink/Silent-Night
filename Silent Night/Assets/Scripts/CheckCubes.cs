using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCubes : MonoBehaviour
{
    public Dictionary<int, Pickup> cubes = new Dictionary<int, Pickup>();

    private void Start()
    {
        var _cubes = FindObjectsOfType<Pickup>();

        for (int i = 0; i < _cubes.Length; i++)
        {
            if (!cubes.ContainsKey(_cubes[i].id))
            {
                cubes.Add(_cubes[i].id, _cubes[i]);
                PlayerPrefs.SetInt(_cubes[i].id.ToString(), 1);
            }
        }
    }
}
