using UnityEngine;
public class CoreMovePC : CoreBasePC
{
    protected float _baseRotateSpeed = -0.5f;
    protected override void InitDelegate()
    {
        base.InitDelegate();
    }

    public void Update()
    {
        _gameController.gameObject.transform.Rotate(Vector3.forward * _baseRotateSpeed);
    }
}
