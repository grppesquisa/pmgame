using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChatConversa : MonoBehaviour {

    string caminho;
    public string arquivo;
    string stringFromJson;

    ConversaFromTwine conversa;
    public FalaFromTwine[] passagens;

    void Start ()
    {
        caminho = Application.streamingAssetsPath + "/" + arquivo + ".json";
        stringFromJson = File.ReadAllText(caminho);

        conversa = JsonUtility.FromJson <ConversaFromTwine> (stringFromJson);
        passagens = new FalaFromTwine[conversa.passages.Length + 1];

        for (int i = 0; i < conversa.passages.Length; i++)
        {
            passagens[(conversa.passages[i].pid)] = conversa.passages[i];
        }
    }

}
