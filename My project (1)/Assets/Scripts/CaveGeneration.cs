using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
public class CaveGeneration : MonoBehaviour
{
    [SerializeField] int caveWeidth, caveHeight;
    [SerializeField] int surfaceWeidht, surfaceHeight;

    [SerializeField] float defaultCheese;
    [SerializeField] float NoiseScale = 100.0f;
    [SerializeField] float SurfaceNoiseScale;
    [SerializeField] float seedOffset;
    [SerializeField] float defaultSpaghettiMin;
    [SerializeField] float defaultSpaghettiMax;
    [SerializeField] float defaultSpaghettiMin2;
    [SerializeField] float defaultSpaghettiMax2;

    
    [SerializeField] float jungleCheese;
    [SerializeField] float jungleSpaghettiMin;
    [SerializeField] float jungleSpaghettiMax;
    [SerializeField] float jungleSpaghettiMin2;
    [SerializeField] float jungleSpaghettiMax2;



    [SerializeField] float surfaceSmooth;

    //[SerializeField] GameObject defaultCaveBlock;
    [SerializeField] GameObject defaultSurfaceBlock;
    [SerializeField] GameObject grassBlock;
    [SerializeField] GameObject goldBlock;
    [SerializeField] GameObject ironBlock;

    [SerializeField] BlockList blockList;
 
    [SerializeField] int jungleBound1, jungleBound2;
    [SerializeField] int desertBound1, desertBound2;
    [SerializeField] int mountainBound1, mountainBound2;
    [SerializeField] int iceBound1, iceBound2;
    [SerializeField] int defaultBuond1, defaultBound2;

    [SerializeField] Transform world;
    GameObject[,] caveBlocks;
    GameObject[,] surfaceBlocks;
    [SerializeField] int wormHeight;
    int[,] caveMap;
    int[,] surfaceMap;

    float lastGenerate;

    
    private void Start()
    {
        TextAsset str = Resources.Load<TextAsset>("OreSpawnInfo");
        OreList loadedOreList = JsonUtility.FromJson<OreList>(str.ToString());
        loadedOreList.oreList[0].replacedBlock = 1;
        OreSpawnInfo ore1 = loadedOreList.oreList[0];
        Debug.Log(ore1.myType);
        Debug.Log(ore1.replacedBlock);
        caveMap = new int[caveWeidth, caveHeight];
        caveBlocks = new GameObject[caveWeidth, caveHeight];

        surfaceMap = new int[surfaceWeidht, surfaceHeight];
        surfaceBlocks = new GameObject[surfaceWeidht, surfaceHeight];

        Generate();
        OrePlacement(loadedOreList);
        SurfaceGeneration();
        GrassPlanting();
        SetWorldBoard();
    }
    private void Update()
    {
        /*if (Time.time > lastGenerate)
        {
            Generate();
            lastGenerate = Time.time;
            seedOffset += 3;

        }*/
    }

    private void SetWorldBoard()
    {
        for (int i = 0; i < caveWeidth; i++)
        {
            for (int j = 0; j < caveHeight; j++)
            {
                if (i == 0 || i == caveWeidth - 1 || j == 0)
                {
                    if (caveMap[i, j] == 0)
                    {

                        caveMap[i, j] = 1;
                        GameObject block = GetCaveDefaultBlock(i);
                        caveBlocks[i, j] = Instantiate(block, new Vector3(i, j, 0), Quaternion.identity.normalized.normalized, world);
                    }
                }
            }
        }
    }
    private void Generate()
    {
        float cheese = 0;
        float spaghettiMin = 0;
        float spaghettiMax = 0;
        float spaghettiMin2 = 0;
        float spaghettiMax2 = 0;
        for (int i = 0; i < caveWeidth; i++)
        {
            for (int j = 0; j < caveHeight; j++)
            {
                if (caveBlocks[i, j] != null)
                {
                    Destroy(caveBlocks[i, j]);
                }
                float noise = Mathf.PerlinNoise(((float)i + seedOffset) / NoiseScale, ((float)j + seedOffset) / NoiseScale);
                float noise2 = Mathf.PerlinNoise(((float)i + seedOffset + 200) / NoiseScale, ((float)j + seedOffset + 200) / NoiseScale);
                cheese = GetGeneretionSettings(i)["cheese"];
                spaghettiMin = GetGeneretionSettings(i)["spaghettiMin"];
                spaghettiMax = GetGeneretionSettings(i)["spaghettiMax"];
                spaghettiMin2 = GetGeneretionSettings(i)["spaghettiMin2"];
                spaghettiMax2 = GetGeneretionSettings(i)["spaghettiMax2"];
                if (noise < cheese || noise > spaghettiMin && noise < spaghettiMax || noise2 > spaghettiMin2 && noise2 < spaghettiMax2)
                {
                    caveMap[i, j] = 0;
                    Destroy(caveBlocks[i, j]);
                }
                else
                {
                    GameObject block = GetCaveDefaultBlock(i);
                    caveMap[i, j] = 1;
                    caveBlocks[i, j] = Instantiate(block, new Vector3(i, j, 0), Quaternion.identity, world);
                }
                //Debug.Log(map[i, j]);
            }
        }
    }
    private void OrePlacement(OreList oreList)
    {
        for (int i = 0; i < oreList.oreList.Count; i++)
        {
            if (oreList.oreList[i] != null)
            {

                for (int oreAmount = oreList.oreList[i].amont; oreAmount > 0;)
                {
                    int x = 0;
                    int y = Random.Range(0, caveHeight);
                        GameObject oreBlock = null;
                    switch (oreList.oreList[i].myType)
                    {
                        case OreType.Gold:
                            oreBlock = goldBlock;
                            x = Random.Range(mountainBound1, mountainBound2 + 1);
                            break;
                        case OreType.Iron:
                            oreBlock = ironBlock;
                            x = Random.Range(mountainBound1, mountainBound2 + 1);
                            break;
                        case OreType.Emerald:
                            oreBlock = blockList.EmeraldMarshmallow;
                            x = Random.Range(jungleBound1, jungleBound2 + 1);
                            break;
                        case OreType.Zircon:
                            oreBlock = blockList.Zircon;
                            x = Random.Range(desertBound1, desertBound2);
                            break;
                        case OreType.Morion:
                            oreBlock = blockList.Morion;
                            x = Random.Range(defaultBuond1, defaultBound2 + 1);
                            break;
                        case OreType.Cabyg:
                            oreBlock = blockList.Cabyg;
                            x = Random.Range(iceBound1, iceBound2 + 1);
                                break;
                    }
                    if (caveMap[x, y] == 1)
                    {
                        //if (caveBlocks[x, y] == blockList.blockList[oreList.oreList[i].replacedBlock])
                        //{
                        caveMap[x, y] = 2;
                        Destroy(caveBlocks[x, y]);
                        caveBlocks[x, y] = Instantiate(oreBlock, new Vector3(x, y, 0), Quaternion.identity.normalized.normalized, world);
                        oreAmount--;

                        oreAmount -= OreStackGeneration(oreBlock, oreList.oreList[i].stackAmount >= oreAmount ? oreList.oreList[i].stackAmount : oreAmount, x, y);
                        //}
                    }
                }
            }
        }
    }
    private int OreStackGeneration(GameObject block, int stackAmount, int x, int y)
    {
        int generatedOre = 0;
        Vector2Int currPos = new Vector2Int(x, y);
        for (int i = 0; i < stackAmount;)
        {
            Vector2Int direction = new Vector2Int(0, 0);
            int rnd = Random.Range(1, 5);
            switch (rnd)
            {
                case 1:
                    direction = new Vector2Int(1, 0);
                    break;
                case 2:
                    direction = new Vector2Int(-1, 0);
                    break;
                case 3:
                    direction = new Vector2Int(0, 1);
                    break;
                case 4:
                    direction = new Vector2Int(0, -1);
                    break;
            }
            if (currPos.x + direction.x >= 0 && currPos.x + direction.x < caveWeidth && currPos.y + direction.y >= 0 && currPos.y + direction.y < caveHeight)
            {
                if (caveMap[(currPos + direction).x, (currPos + direction).y] == 1)
                {

                    currPos += direction;
                    caveMap[currPos.x, currPos.y] = 2;
                    Destroy(caveBlocks[currPos.x, currPos.y]);
                    caveBlocks[currPos.x, currPos.y] = Instantiate(block, new Vector3Int(currPos.x, currPos.y, 0), Quaternion.identity, world);
                    generatedOre++;
                }
            }
            i++;
        }
        return generatedOre;
    }
    private void SurfaceGeneration()
    {
        
        surfaceMap[0, wormHeight] = 1;
        surfaceBlocks[0, wormHeight] = Instantiate(defaultSurfaceBlock, new Vector3Int(0, wormHeight + caveHeight, 0), Quaternion.identity, world );
        Vector2Int PrevPosition = new Vector2Int(0, wormHeight);
        int StartY = wormHeight;
        Vector2Int SpawnPosition;
        for (int i = 0; i < surfaceWeidht; i++)
        {
            float noiseY = Mathf.PerlinNoise((i +  seedOffset) / SurfaceNoiseScale, (surfaceHeight + seedOffset) / SurfaceNoiseScale) * surfaceSmooth - surfaceSmooth / 2.0f;
            noiseY = (int)(noiseY / 45.0f) * 45.0f;
            
            Debug.Log(noiseY);
            Vector2Int direction = new Vector2Int(0, 0);
            switch (noiseY)
            {
                case -90:
                    direction = new Vector2Int(0, -1);
                    break;
                case -45:
                    direction = new Vector2Int(1, -1);
                    break;
                case 0:
                    direction = new Vector2Int(1, 0);
                    break;
                case 45:
                    direction = new Vector2Int(1, 1);
                    break;
                case 90:
                    direction = new Vector2Int(0, 1);
                    break;
            }
            if (PrevPosition.x + direction.x < surfaceWeidht)
            {
                if (Mathf.Abs(StartY - (direction.y + PrevPosition.y)) > 10)
                {
                    direction.y *= -1;
                }
                if (PrevPosition.y + direction.y == 0)
                {
                    direction.y = 0;
                }
                SpawnPosition = PrevPosition + direction;
                PrevPosition = SpawnPosition;
                surfaceMap[SpawnPosition.x, SpawnPosition.y] = 1;
                GameObject block = GetSurfaceBlock(SpawnPosition.x);
                surfaceBlocks[SpawnPosition.x, SpawnPosition.y] = Instantiate(block, new Vector3(SpawnPosition.x, SpawnPosition.y + caveHeight, 0), Quaternion.identity, world);
                DirtFiller(SpawnPosition.x, SpawnPosition.y);
            }
            else
            {
                return;
            }

        }
    }
    private void DirtFiller(int x, int y)
    {
        for (int i = y; i >= 0; i--)
        {
            surfaceMap[x, y] = 1;
            if (surfaceBlocks[x, i] != null)
            {
                Destroy(surfaceBlocks[x, y]);
            }
            GameObject block = GetSurfaceBlock(x); 
            surfaceBlocks[x, y] = Instantiate(block, new Vector3(x, i + caveHeight - 1, 0.0f), Quaternion.identity, world);
        }
    }
    private void GrassPlanting()
    {
        for (int x = 0; x < surfaceWeidht; x++)
        {
            for (int y = 0; y < surfaceHeight; y++)
            {
                if (surfaceMap[x, y] == 1 && surfaceMap[x, y + 1] == 0)
                {
                    Destroy(surfaceBlocks[x, y]);
                    GameObject block = GetSurfaceGrassBlock(x);
                    surfaceBlocks[x, y] = Instantiate(block, new Vector3(x, y + caveHeight, 0), Quaternion.identity, world);
                }
            }
        }
    }
    private Dictionary<string, float> GetGeneretionSettings(int x)
    {
        Dictionary<string, float> Settings = new Dictionary<string, float>();
        Settings.Add("cheese", defaultCheese);
        Settings.Add("spaghettiMin", defaultSpaghettiMin);
        Settings.Add("spaghettiMax", defaultSpaghettiMax);
        Settings.Add("spaghettiMin2", defaultSpaghettiMin2);
        Settings.Add("spaghettiMax2", defaultSpaghettiMax2);
        if (x > jungleBound1 && x < jungleBound2)
        {
            Settings["cheese"] = 0;
            Settings["spaghettiMin"] = jungleSpaghettiMin;
            Settings["spaghettiMax"] = jungleSpaghettiMax;
            Settings["spaghettiMin2"] = jungleSpaghettiMin2;
            Settings["spaghettiMax2"] = jungleSpaghettiMax2;

        }
        else if (x > desertBound1 && x < desertBound2)
        {
            Settings["cheese"] -= 0.15f;
            Settings["spaghettiMin"] = 1f;
            Settings["spaghettiMin2"] += 0.05f;
        }
        return Settings;
    }
    private GameObject GetCaveDefaultBlock(int x)
    {
        if (x >= jungleBound1 && x < jungleBound2)
        {
            return blockList.Moss;
        }
        else if (x >= desertBound1 && x < desertBound2)
        {
            return blockList.SandStone;
        }
        else if (x >= mountainBound1 && x < mountainBound2)
        {
            return blockList.Stone;
        }
        else if (x >= iceBound1 && x < iceBound2)
        {
            return blockList.Ice;
        }
        else
        {
            return blockList.BlackSoil;
        }
    }
    private GameObject GetCaveOreBlock(int x)
    {
        if (x > jungleBound1 && x < jungleBound2)
        {
            return blockList.EmeraldMarshmallow;
        }
        else
        {
            return blockList.Iron;
        }
    }
    private GameObject GetSurfaceBlock(int x)
    {
        if (x > jungleBound1 && x < jungleBound2)
        {
            return blockList.BlackSoil;
        }
        else if (x > desertBound1 && x < desertBound2)
        {
            return blockList.Sand;
        }
        else if (x > mountainBound1 && x < mountainBound2)
        {
            return blockList.Stone;
        }
        else if (x > iceBound1 && x < iceBound2)
        {
            return blockList.Ice;
        }
        else
        {
            return blockList.Dirt;
        }
    }
    private GameObject GetSurfaceGrassBlock(int x)
    {
        if (x > jungleBound1 && x < jungleBound2)
        {
            return blockList.BlackSoil;
        }
        else if (x > desertBound1 && x < desertBound2)
        {
            return blockList.Sand;
        }
        else if (x > mountainBound1 && x < mountainBound2)
        {
            return blockList.Stone;
        }
        else if (x > iceBound1 && x < iceBound2)
        {
            return blockList.Ice;
        }
        else
        {
            return blockList.Grass;
        }
    }
}

public enum OreType 
{ 
    Gold = 0, 
    Iron,
    Emerald, 
    Zircon,
    Morion, 
    Cabyg
};

[System.Serializable]
public class OreSpawnInfo
{
    public OreType myType;
    public int amont;
    public int stackAmount;
    public int replacedBlock;
}

[System.Serializable]
public class OreList
{
    public List<OreSpawnInfo> oreList;
    public OreList()
    {
        oreList = new List<OreSpawnInfo>();
    }
}


