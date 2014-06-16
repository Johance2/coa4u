﻿using System;
using System.Collections.Generic;
using UnityEngine;

class ActionRotateTo : ActionInterval
{
    protected Vector3 value;
    protected Vector3 path;

    public ActionRotateTo(Vector3 tgtValue, float tgtDuration)
        : base(tgtDuration)
    {
        value = tgtValue;
    }

    public override Action clone()
    {
        return new ActionRotateTo(value, duration);
    }

    public override void start()
    {
        base.start();
        path = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            float t = value[i];
            float f = target.gameObject.transform.rotation.eulerAngles[i];
            if (Math.Abs(t - f) < Math.Abs(t + 360 - f))
                path[i] = t - f;
            else
                path[i] = t + 360 - f;
        }
    }
    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Vector3 tgt = path * d;
        target.gameObject.transform.Rotate(Vector3.up, tgt.y);
        target.gameObject.transform.Rotate(Vector3.right, tgt.x);
        target.gameObject.transform.Rotate(Vector3.forward, tgt.z);
    }
}