using UnityEngine;

public class Loot : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private int chance;
    [SerializeField] private GameObject[] partSpaceShip;
    [SerializeField] private Vector3 offsetCreate = Vector3.up;
    private Life _life;

    private void OnEnable()
    {
        _life = GetComponent<Life>();
        _life.OnDid += CreatePartSpaceShip;
    }

    private void OnDisable()
    {
        _life.OnDid -= CreatePartSpaceShip;
    }

    public void GetOneHundredPercentChanceLoot()
    {
        chance = 100;
    }

    private void CreatePartSpaceShip()
    {
        var numberPartsFoundShip = Progress.GetNumberPartsFoundShip();
        if (numberPartsFoundShip > partSpaceShip.Length - 1) return;
        if (Random.Range(0, 101) > chance) return;
        var positionSpawn = transform.position + offsetCreate;
        Instantiate(partSpaceShip[Progress.GetNumberPartsFoundShip()], positionSpawn, Quaternion.identity);
        Progress.SetNumberPartsFoundShip(Progress.GetNumberPartsFoundShip() + 1);
    }
}
