using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Leitor : MonoBehaviour
{
    //public List<string> id;
    //public List<string> autor;
    //public List<string> mensagem;

    //public List<string> resposta;

    public struct Linha {
        public string id;
        public string autor;
        public string msg;
        public string visibilidade;
        public string requiriment;
        public string nextMsg;
    }

    public struct Resposta {
        public string id;
        public string reposta;
        public string next;
    }
    // Start is called before the first frame update
    void Start()
    {
        StreamReader strReader = new StreamReader("D:\\UnityProjects\\DialogSystem\\Assets\\Data\\Dialogs.csv");
        StreamReader strAnswers = new StreamReader("D:\\UnityProjects\\DialogSystem\\Assets\\Data\\Answers.csv");
        List<Linha> listReader = ReadCSVFile(strReader);
        List<Resposta> listAnswers = ReadCSVFileAnswers(strAnswers);

        nextMessage(listReader[1], listReader);
    }

    private List<Linha> ReadCSVFile(StreamReader strReader) {
        bool endOfFile = false;
        List<Linha> linhas = new List<Linha>();
        while (!endOfFile)
        {
            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_string.Split(';');

            Linha linha;
            linha.id = data_values[0].ToString();
            linha.autor = data_values[1].ToString();
            linha.msg = data_values[2].ToString();
            linha.visibilidade = data_values[3].ToString();
            linha.requiriment = data_values[4].ToString();
            linha.nextMsg = data_values[5].ToString();

            linhas.Add(linha);
        }
        return linhas;
    }

    private List<Resposta> ReadCSVFileAnswers(StreamReader strAnswers)
    {
        bool endOfFile = false;
        List<Resposta> respostas = new List<Resposta>();
        while (!endOfFile)
        {
            string data_string = strAnswers.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_string.Split(';');

            Resposta resposta;
            resposta.id = data_values[0].ToString();
            resposta.reposta = data_values[1].ToString();
            resposta.next = data_values[2].ToString();
            
            respostas.Add(resposta);
        }
        return respostas;
    }

    //perguntar antes pra linha atual se ela é uma pergunta ou não
    public Linha nextMessage(Linha atual, List<Linha> prox) {
        Linha next;
        int idNext = Convert.ToInt32(atual.nextMsg);
        next = prox[idNext];
        Debug.Log(atual.msg.ToString());
        Debug.Log(atual.nextMsg.ToString());
        Debug.Log(next.msg.ToString());
        return next;
    }
}
