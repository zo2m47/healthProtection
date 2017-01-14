using UnityEngine;
using System.Collections;
/**
 * Logic with all sounds in the game
 * */
public class SoundModel : ModelSingleTone<SoundModel> {
    protected override IEnumerator CheckOnInitialized()
    {
        Debug.Log("Sound model was initialized");
        initializationStatus = InitializationStatus.initializated;
        yield break;
    }
}
