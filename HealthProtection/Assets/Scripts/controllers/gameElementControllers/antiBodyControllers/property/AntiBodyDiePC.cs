using UnityEngine;
 /**
 * reaction of die
 * */
public class AntiBodyDiePC : AntiBodyBasePC
{
    protected override void InitDelegate()
    {
        base.InitDelegate();
        _gameController.dieDelagate += DieDelagate;
    }

    private void DieDelagate()
    {
        PrefabCreatorManager.Instance.DestroyPrefab(_gameController.gameObject);
    }
}