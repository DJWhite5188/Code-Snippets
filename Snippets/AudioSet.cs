using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioSet {

    public AudioClip[] clips;

    int nextClipIndex = -1;

    private void Shuffle()
    {
        if (clips.Length <= 1)
        {
            return;
        }

        System.Random _random = new System.Random();

        AudioClip last = clips[clips.Length - 1];

        int n = clips.Length;
        for (int i = 0; i < n; i++)
        {

            int r = i + _random.Next(n - i);
            AudioClip t = clips[r];
            clips[r] = clips[i];
            clips[i] = t;
        }

        if (clips[0] == last)
        {
            int r = _random.Next(1, clips.Length);
            AudioClip t = clips[r];
            clips[r] = clips[0];
            clips[0] = t;
        }

        nextClipIndex = 0;
    }

    public AudioClip GetRandomClip()
    {
        if (clips.Length == 0)
        {
            return null;
        }

        if (nextClipIndex < 0)
        {
            Shuffle();
        }

        if (nextClipIndex >= clips.Length)
        {
            Shuffle();
        }

        return clips[nextClipIndex++];
    }
}
