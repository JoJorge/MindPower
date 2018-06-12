using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReadingStrategy {

    protected float threshold;
    protected float power;

    protected ReadingStrategy(float th) {
        threshold = th;
        power = 0;
    }

    public virtual float getResult() {
        return power;
    }
    public abstract void init ();
    public abstract void close();
    public abstract void readMind(int value);
}
