using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager: ManagerSingleTone<ParallaxManager>
{
    private List<ParallaxController> _parallaxList = new List<ParallaxController>();
    public void InitParallaxData(RoundVO roundData)
    {
        for (int i = 0; i < roundData.parallaxList.Count; i++)
        {
            if (i == _parallaxList.Count)
            {
                _parallaxList.Add(PrefabParallaxCreator.CreatParallax());
            }
            _parallaxList[i].SetData(roundData.parallaxList[i]);
        }
    }

    public void ResetAllParallax()
    {
        for (int i = 0;i< _parallaxList.Count; i++)
        {
            _parallaxList[i].ResetParallax();
        }
    }
}
