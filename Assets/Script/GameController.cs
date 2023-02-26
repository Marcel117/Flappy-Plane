using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstaculo;   
    //Posi��o para criar o obst�culo
    [SerializeField] private Vector3 posicao;
    //Posi��o m�nima e m�xima das montanhas
    [SerializeField] private float posMin = -1.64f;
    [SerializeField] private float posMax = 1.44f;
    [SerializeField] private float tMin = 0.5f;
    [SerializeField] private float tMax = 1;
    //Vari�vel do som 
    public AudioClip levelSound;

    private float pontos;
    private int level = 1;
    [SerializeField] private float proxLevel = 10f;



    //Vari�vel dos pontos do Canvas
    [SerializeField] private Text pontosTexto;
    //Vari�vel do Level do Canvas
    [SerializeField] private Text levelTexto;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Pontos();
       
        CriandoObstaculos();

        GanhandoLevel();
        
    }

    private void CriandoObstaculos()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            timer = Random.Range(tMin/level, tMax);

            posicao.y = Random.Range(posMin, posMax);

            //Criando os obst�culos
            Instantiate(obstaculo, posicao, Quaternion.identity);
        }
    }

    public void Pontos()
    {
        pontos += Time.deltaTime;
        Debug.Log(Mathf.Round(pontos));
        pontosTexto.text = Mathf.Round(pontos).ToString();
    }

    private void GanhandoLevel()
    {
        levelTexto.text = level.ToString();
        if (pontos > proxLevel)
        {
            AudioSource.PlayClipAtPoint(levelSound, transform.position);
            level ++;
            proxLevel *= 2;
        }
    }

    public int RetornaLevel()
    {
        return level;
    }
}

