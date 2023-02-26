using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //Pegando o meu material
    private Renderer meuFundo;
    //Posição do meu X offset
    private float xOffset = 0f;
    //Posição da minha textura
    private Vector2 texturaOffset;
    //Velocidade do fundo
    private float velocidade = 0.1f;
    // Start is called before the first frame update
    void Start()
    {       
        //Pegando o meuFundo
        meuFundo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Diminuindo o valor do xOffset
        xOffset += velocidade * Time.deltaTime;
        //Passando o xOffset para o X da minha textura
        texturaOffset.x = xOffset;
        //Movendo o offset x do meu renderer
        meuFundo.material.mainTextureOffset = texturaOffset;
    }
}
