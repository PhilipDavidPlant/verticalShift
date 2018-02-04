using UnityEngine;
using System.Collections;

public delegate void Callback();

public class GeneralUtilities : MonoBehaviour {

	/** Set Timeout and Interval functions which work just like their Javascript counterparts */
    public void setTimeout(Callback callBackFunction, int timeoutMilliseconds){
		StartCoroutine(countDown(callBackFunction, timeoutMilliseconds));
		return;
    }

	public void setInterval(Callback callBackFunction, int timeoutMilliseconds){
		StartCoroutine(interval(callBackFunction, timeoutMilliseconds));
		return;
    }

	private IEnumerator interval(Callback callBackFunction, int timeoutMilliseconds){
		while(true){
			int countDown = timeoutMilliseconds;
			while (countDown > 0) {
				yield return new WaitForSeconds(0.1f);
				countDown--;
			}
			callBackFunction();
		}
	}

	private IEnumerator countDown(Callback callBackFunction, int timeoutMilliseconds){
		int countDown = timeoutMilliseconds;
		while (countDown > 0) {
			yield return new WaitForSeconds(0.1f);
			countDown--;
		}
		callBackFunction();
	}

}