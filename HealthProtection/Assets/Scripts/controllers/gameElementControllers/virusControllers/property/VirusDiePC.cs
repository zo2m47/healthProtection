using UnityEngine;
 /**
 * reaction of die
 * */
public class VirusDiePC : VirusBasePC
{
    protected override void InitDelegate()
    {
        base.InitDelegate();
        _gameController.dieDelagate += DieDelagate;
    }
    
    private void DieDelagate()
    {
        Debug.Log("Virus die");
        PrefabCreatorManager.Instance.DestroyPrefab(_gameController.gameObject);
    }
}
