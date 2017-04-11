/*============================================================================== 
 * Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;


public class ModelSwap : MonoBehaviour 
{
    private GameObject mDefaultModel;
    private GameObject mExtTrackedModel;
    private TrackableSettings mTrackableSettings = null;

	void Start () 
    {
        mDefaultModel = this.transform.FindChild("teapot").gameObject;
    }
    
    void Update () 
    {
        if ((mExtTrackedModel != null))
        {
            mDefaultModel.SetActive(true);
        }
    }
}
