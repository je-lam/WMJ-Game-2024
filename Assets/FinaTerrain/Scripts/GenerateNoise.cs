using UnityEngine;

public static class GenerateNoise
{

    public static float SimpleNoise(int MapXsize, int MapYsize, int x, int y, float amplitude, float frequency, float seed)
    {
        float SampleX = (float)x / MapXsize + seed;
        float SampleY = (float)y / MapYsize + seed;
        float height = Mathf.PerlinNoise(SampleX * frequency, SampleY * frequency) * amplitude;
        return height;
    }

}
