using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Transform Target { get { return target; } set { target = value; } }
    private NavMeshAgent _botNMA;
    private Animator _animator;

    private void Awake()
    {
        _botNMA = GetComponent<NavMeshAgent>();
        Target = GetComponent<TargetMoveBot>().GetTarget();
        _animator = GetComponent<Animator>();
    }

    public void StopRun()
    {
        _botNMA.isStopped = true;
    }

    public void RunTowardsTarget()
    {
        _animator.SetTrigger("Run");
        _botNMA.destination = Target.position;
        _botNMA.isStopped = false;
    }

    public void RotateTowardsTarget()
    {
        _botNMA.isStopped = true;
        var rotationLookAnTarget = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationLookAnTarget, _botNMA.angularSpeed / 20f);
    }
}
