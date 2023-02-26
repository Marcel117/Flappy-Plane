using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private GameObject puff;

    //velocidade
    [SerializeField] private float velocidade = 5f;


    // Start is called before the first frame update
    void Start()
    {
        //Pegando meu Rig. Body sozinho ( sem arrastar para o Transform)
        meuRB = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        //Subindo ao Apertar espaço
        Subir();
        //Limitando a minha velocidade de queda
        LimitadorVelocidade();
        //Reiniciando ao sair da tela
        morrendoSair();
    }

    private void LimitadorVelocidade()
    {
        if (meuRB.velocity.y < -velocidade)
        {
            //travando meuRB.velocity.y em -5
            meuRB.velocity = Vector2.down * velocidade;
        }
    }

    //criando o método subir
    public void Subir()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fazendo a velocidade do RB ir para cima
            meuRB.velocity = Vector2.up * velocidade;

            //Criando a fumaça           
            GameObject meuPuff = Instantiate(puff, transform.position, Quaternion.identity);
            Destroy (meuPuff, 1f);
        }
        
    }
   
    //Reiniciando ao sair da tela
    private void morrendoSair()
    {
        if(transform.position.y > 5f || transform.position.y < -5f)
        {
            SceneManager.LoadScene(0);
        }
    }

    //Configurando a colisão do Player   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bati!");
        SceneManager.LoadScene(0);
    }
            
}
