﻿using System;
using System.Collections.Generic;
using UnityEngine;

class ActionFadeTo : ActionInterval
{
    protected float value;
    protected float delta;

    public ActionFadeTo(float tgtValue, float tgtDuration)
        : base(tgtDuration)
    {
        value = tgtValue;
    }

    public override Action clone()
    {
        return new ActionFadeTo(value, duration);
    }

    public override void start()
    {
        base.start();
        delta = value - renderer.material.color.a;
    }

    public override void stepInterval(float dt)
    {
        float d = dt / duration;
        Color tgtColor = renderer.material.color;
        tgtColor[3] += delta * d;
        renderer.material.color = tgtColor;
    }
}