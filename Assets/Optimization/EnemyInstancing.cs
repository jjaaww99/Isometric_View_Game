using Unity.VisualScripting;
using UnityEngine;

public class DualMaterialInstancing : MonoBehaviour
{
    public ObjectPool enemyPool;
    public int enemyCount = 100;
    public Material[] enemyMaterials;

    private Matrix4x4[] matrices;
    private MaterialPropertyBlock materialPropertyBlock;
    private GameObject[] enemies;
    private SkinnedMeshRenderer[] skins;

    void Awake()
    {
        matrices = new Matrix4x4[enemyCount];
        materialPropertyBlock = new MaterialPropertyBlock();
        enemies = new GameObject[enemyCount];

        // 오브젝트 풀에서 적을 가져와 초기화
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = enemyPool.GetObject();

            enemies[i] = enemy;
            Vector3 position = new Vector3(

                Random.Range(-10.0f, 10.0f),
                0,
                Random.Range(-10.0f, 10.0f)
            );

            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Vector3 scale = new Vector3(2, 2, 2);

            skins = enemy.GetComponentsInChildren<SkinnedMeshRenderer>();

            matrices[i] = Matrix4x4.TRS(position, rotation, scale);
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
        }
    }

    void Start()
    {

        int halfCount = enemyCount / 2;
        Graphics.DrawMeshInstanced(
            enemies[0].GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh,
            0,
            enemyMaterials[0],
            matrices,
            halfCount,
            materialPropertyBlock
        );

        Graphics.DrawMeshInstanced(
            enemies[0].GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh,
            0,
            enemyMaterials[1],
            matrices,
            halfCount,
            materialPropertyBlock
        );
    }

    void Update()
    {

    }
}
