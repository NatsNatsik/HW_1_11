using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public int ManPlatforms;
    public int MixPlatforms;
    public float DastanceBetweenPlatforms;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public GameObject FirstPlatformPrefab;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        int PlatformsCount = RandomRange(random, ManPlatforms, MixPlatforms+1);

        for (int i = 0; i < PlatformsCount; i++)
        {
            int PrefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject PlatformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[PrefabIndex];
            GameObject platform = Instantiate(PlatformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i>0)
            platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }
        FinishPlatform.localPosition = CalculatePlatformPosition(PlatformsCount);
        CylinderRoot.localScale = new Vector3(1, PlatformsCount * DastanceBetweenPlatforms+ ExtraCylinderScale, 1);
    }

    private int RandomRange( Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }
    private float RandomRange (Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }
    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DastanceBetweenPlatforms * platformIndex, 0);
    }
}
