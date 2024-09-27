using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxtime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;
    private float _timer;
    // Start is called before the first frame update
    private void Start()
    {
        SpwanPipe();
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (_timer > _maxtime)
        {
            SpwanPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
    private void SpwanPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, UnityEngine.Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe,spawnPos, Quaternion.identity);
        Destroy(pipe,10f);
    }

    
}
