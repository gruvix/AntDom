using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D Map;
    public GameObject Entidades;

    public PrefabsPorColor[] MapeadoDeColor;
    public LevelSettings MapeadoDeEntiedades;

    private GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        GenerateEntities();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < Map.width; x++)
        {
            for (int y = 0; y < Map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelcolor = Map.GetPixel(x, y);

        if (pixelcolor == Color.white)
        {
            //Todos los pixeles trasparentes no generan bloque
            return;
        }
        foreach (PrefabsPorColor colorasignado in MapeadoDeColor)
        {
            if (colorasignado.color.Equals(pixelcolor))
            {
                if (colorasignado.color == Color.red)
                {
                    Debug.Log("Spanw");
                }
                Vector2 posicion = new Vector2(x, y);
                Instantiate(colorasignado.prefab, posicion, Quaternion.identity, gameObject.transform);
            }
        }
    }

    void GenerateEntities()
    {
        Spawn = GameObject.Find("Spawn(Clone)");
        Debug.Log(Spawn);
        if (Spawn)
        {
            Instantiate(MapeadoDeEntiedades.Brain, Spawn.transform.position, Quaternion.identity, Entidades.transform);
            foreach (Sibling sibling in MapeadoDeEntiedades.Siblings)
            {
                for (int i = 0; i < sibling.Cantidad; i++)
                    Instantiate(sibling.prefab, Spawn.transform.position, Quaternion.identity, Entidades.transform);
            }
        }
    }
}
