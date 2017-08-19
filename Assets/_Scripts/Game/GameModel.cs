using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameModel : SingletonMonoBehavior<GameModel> {


	private float _currentXPosition = 0;
<<<<<<< HEAD
    private int _currentLevel = 0;
    private Vector3 _lastplayformRightPoint; //最右最前的平台最右的點

    public List<Transform> _platformsList; //所有平台的array

    public void Init() {
=======
	public List<GameObject> _platforms;
	public List<GameObject> _cats;


	public void Init() {
		_platforms = GameObject.FindGameObjectsWithTag ("Floor").ToList<GameObject> ();
		_cats = GameObject.FindGameObjectsWithTag ("CatBelly").ToList<GameObject> ();
>>>>>>> 76d3febc2ae5b603ee0c6a8b5137eea50d582411

	}

	public float UpdateX() {
<<<<<<< HEAD
		_currentXPosition += (Time.deltaTime )*(getCurrentLevel()/0.25f ) ;
		return _currentXPosition;
	}

    public int getCurrentLevel()
    {
        //start in level1
        //根據time.time來慢慢增加速度
        _currentLevel = ( (int)Time.time / 5)+1;
        return _currentLevel;
    }

    public List<Transform> getListPlatformsList (){
        return _platformsList;
    }

    public void registerNewPlatformToList(Transform Platform) //好像不應該放在這 //ok
    {
        //註冊生成出來的platform到model的list裡
        _platformsList.Add(Platform);
    }

    public void removeOldestPlatformToList() 
    {
        //remove the oldest platform form list
        Destroy(_platformsList[0].gameObject);
        _platformsList.Remove(_platformsList[0]);
    }

    public float getMostRightPointInPlatformsList()
    {
        //取得最右端的platforms坐標(xPos)
        if (_platformsList.Count < 1)
        {
            Debug.LogError("platforms count less than 1");
            return 0;
        }

        foreach (Transform child in _platformsList[_platformsList.Count - 1].transform)
        {
            if (child.gameObject.tag == "rightPoint")
            {
                return child.position.x;
            }
        }


        Debug.LogError("cant not find tag");
        return 0;

    }

=======
		_currentXPosition += (Time.deltaTime * .5f);
		return _currentXPosition;
	}


	public void OnMakePlatform(GameObject platform) {
		_platforms.Add (platform);
	}

	public float GetLastPlatformX() {
		GameObject latest = _platforms [_platforms.Count - 1];
		return latest.GetComponent<SpriteRenderer> ().bounds.max.x;
	}

	public void OnMakeCat(GameObject cat) {
		_cats.Add (cat);

	}

	public float GetLastCatX() {
		GameObject latest = _cats [_cats.Count - 1];
		return latest.GetComponent<SpriteRenderer> ().bounds.max.x;
	}
>>>>>>> 76d3febc2ae5b603ee0c6a8b5137eea50d582411

}
