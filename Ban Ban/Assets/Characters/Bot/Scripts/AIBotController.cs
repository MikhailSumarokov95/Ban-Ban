using UnityEngine;
using UnityEngine.AI;
using Bot;

public class AIBotController : MonoBehaviour
{
    [SerializeField] private Transform eyesTr;
    [Range(0f, 30f)]
    [SerializeField] private float angleVisibility = 5f;
    [SerializeField] private float maxSpeedAnimation = 1.5f;
    [SerializeField] private float timeDo = 0.5f;
    private Transform _target;
    private CapsuleCollider _targetCol;
    private BotMove _botMove;
    private Weapon _weapon;
    private float _timerForDo;

    private void Start()
    {
        _target = GetComponent<TargetMoveBot>().GetTarget();
        _targetCol = _target.GetComponent<CapsuleCollider>();
        _botMove = GetComponent<BotMove>();
        _weapon = transform.GetComponentInChildren<Weapon>();
        RandomizerSpeed();
        _timerForDo = Random.Range(0, timeDo);
    }

    private void Update()
    {
        if (StateGameManager.StateGame != StateGameManager.State.Game) return;
        if (_weapon.IsAttacking) return;
        _timerForDo += Time.deltaTime;
        if (_timerForDo < timeDo) return;
        _timerForDo = 0f;
        if (DetermineIfThereObstaclesBetweenTargetAndBot() && IsTargetInAffectedArea())
            if (TargetVisibilityCheck()) Attack();
            else _botMove.RotateTowardsTarget();
        else _botMove.RunTowardsTarget();
    }

    private bool TargetVisibilityCheck()
    {
        var rotationLookAnTarget = Quaternion.LookRotation(_target.position - transform.position);
        if (Mathf.Abs(transform.rotation.eulerAngles.y - rotationLookAnTarget.eulerAngles.y) < angleVisibility)
            return true;
        else return false;
    }

    private bool DetermineIfThereObstaclesBetweenTargetAndBot()
    {
        var sideIsTarget = GetSideIsTargetWithIndent(0.9f);
        for (var i = 0; i < sideIsTarget.Length; i++)
        {
            Debug.DrawRay(eyesTr.position, sideIsTarget[i] - eyesTr.position, Color.red);
            RaycastHit hit;
            if (!Physics.Raycast(eyesTr.position, sideIsTarget[i] - eyesTr.position, out hit)) continue;
            if (hit.collider.gameObject == _target.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    private Vector3[] GetSideIsTargetWithIndent(float indentFromSide)
    {
        var perpendicularToVectorBetweenTargetAndBot =
            (Quaternion.Euler(0, 90, 0) * (_target.position - transform.position)).normalized;
        var sideIsTarget = new Vector3[4];
        sideIsTarget[0] = _targetCol.transform.up * indentFromSide * _targetCol.height + _target.position;
        sideIsTarget[1] = _targetCol.transform.up * (1 - indentFromSide) + _target.position;
        sideIsTarget[2] = -perpendicularToVectorBetweenTargetAndBot * indentFromSide * _targetCol.radius + _target.position +
            _targetCol.transform.up * _targetCol.height / 2;
        sideIsTarget[3] = perpendicularToVectorBetweenTargetAndBot * indentFromSide * _targetCol.radius + _target.position +
            _targetCol.transform.up * _targetCol.height / 2;
        return sideIsTarget;
    }
    
    private bool IsTargetInAffectedArea()
    {
        return Vector3.Distance(transform.position, _target.position) < _weapon.DistanceAttack;
    }

    private void Attack()
    {
        _botMove.StopRun();
        _weapon.Attack(_target.gameObject);
    }

    private void RandomizerSpeed()
    {
        var speed = Random.Range(1, maxSpeedAnimation);
        GetComponent<Animator>().speed *= speed;
        GetComponent<NavMeshAgent>().speed *= speed;
    }
}