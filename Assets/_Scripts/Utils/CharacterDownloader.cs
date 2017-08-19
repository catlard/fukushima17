using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CharacterDownloader : MonoBehaviour {

	private string _url = "https://drawws.kgr-lab.com/";




	public void Start() {
		StartCoroutine("GetImages");

	}


	private IEnumerator GetImages()
	{
		bool error = false;
		int charNum = 0;

		while (!error) {
			charNum++;

			string numStr = charNum.ToString ();
			if (charNum < 10) {
				numStr = "000" + numStr;
			} else if (charNum < 100) {
				numStr = "00" + numStr;
			}

			string bodyFile = "b" + numStr + ".png";
			string armFile = "a" + numStr + ".png";


			// Start a download of the given URL
			WWW www = new WWW (_url + bodyFile);
			// Wait for download to complete
			print ("WAITING: " + bodyFile);
			yield return www;
			print ("GOT " + bodyFile + ".");
			System.IO.File.WriteAllBytes (Application.dataPath + "/_Art/chars/" + bodyFile, www.texture.EncodeToPNG ());
		
			// Start a download of the given URL
			www = new WWW (_url + armFile);
			// Wait for download to complete
			print ("WAITING: " + armFile);
			yield return www;
			print ("GOT " + armFile + ".");
			System.IO.File.WriteAllBytes (Application.dataPath + "/_Art/chars/" + armFile, www.texture.EncodeToPNG ());

			if (www.error != null) {
				error = true;
				print (www.error);
			}
		}

	}


	private void SaveTextureToFile (Texture2D texture, string filename) { 
	}

}
