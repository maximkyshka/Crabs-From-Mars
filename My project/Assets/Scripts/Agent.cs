using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    private NavMeshAgent _agent;

    private int _currentIndex = 0;
    
    private IDamageable _health;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        _agent.avoidancePriority = Random.Range(0, 100);
        
        if(targets.Length != 0)
            _agent.SetDestination(targets[_currentIndex].position);
    }
    
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_agent.remainingDistance <= 0.01f)
        {
            _currentIndex++;
            
            if (_currentIndex >= targets.Length)
                _currentIndex = 0;
            
            _agent.destination = targets[_currentIndex].position;
        }
    }
}
