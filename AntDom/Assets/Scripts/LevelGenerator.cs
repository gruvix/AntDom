using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D Map;

    public PrefabsPorColor[] MapeadoDeColor;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
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

        if (pixelcolor == Color.clear)
        {
            //Todos los pixeles trasparentes no generan bloque
            return;
        }
        foreach (PrefabsPorColor colorasignado in MapeadoDeColor)
        {
            if (colorasignado.color.Equals(pixelcolor))
            {
                Vector2 posicion = new Vector2(x, y);
                Instantiate(colorasignado.prefab);
            }
        }
    }
}
