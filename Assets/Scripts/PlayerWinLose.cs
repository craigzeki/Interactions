using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinLose : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Canvas _winCanvas;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Goal":
                _winCanvas.enabled= true;
                _rigidbody.isKinematic = true;
                break;
            case "TheVoid":
                transform.position = _spawnPoint.position;
                break;

        }
    }
}
