using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscolhePagina : MonoBehaviour {

	public Transform[] paginas;
	public TMP_Dropdown barraEndereco;


	public void VaiPara (int indice) {
		paginas [indice].SetAsLastSibling ();
	}

	public void BarraEnderecoVaiPara () {
		VaiPara (barraEndereco.value);
	}


}
