using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    [SerializeField] private float velocidade = 4f;
    [SerializeField] private GameObject eu;
    [SerializeField] private GameController game;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(eu, 3f);

        //Encontrando o GameController da cena atual
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  Vector3.left * velocidade * Time.deltaTime; ;

        Debug.Log(game.RetornaLevel());

        velocidade = 4f + game.RetornaLevel();
    }
}
