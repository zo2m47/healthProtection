using UnityEngine;
public interface ICoreGameController
{
    void SetData(CoreVO data);
    Vector3 corePosition { get; }
}
