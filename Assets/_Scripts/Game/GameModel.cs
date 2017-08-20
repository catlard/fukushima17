using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameModel : SingletonMonoBehavior<GameModel> {


	private float _currentXPosition = 0;
    private int _currentLevel = 0;
    private float _currentTimePass = 0;
    private Vector3 _lastplayformRightPoint; //最右最前的平台最右的點


    public List<Transform> _platformsList; //所有平台的array
    public List<Mouse> _playerList;

     float _currentCameraStopPoint;
    bool _isCameraStop;
    bool _isGameOver;
    [SerializeField]
     public float waitingTime;
    float _currentTimer;


	public void Init() {
		_currentTimePass = 0;
		_currentLevel = 0;

	}
    




	public void removePlayerRegister(Mouse m)
    {
        _playerList.Remove(m);
    }

	public float UpdateX() {
        if (_isCameraStop)
        {
            return _currentXPosition;
        }

		_currentXPosition += (Time.deltaTime )*(getCurrentLevel()/1f ) ;
		return _currentXPosition;
	}

    public void runningStopTimer()
    {
        if (!_isCameraStop)
        {
            return;
        }
        else
        {
            if (waitingTime > _currentTimer)
            {
                _currentTimer += Time.deltaTime;
            }
            else
            {
                setIsCameraStop(false);
            }
        }
    }

    public int getCurrentLevel()
    {
        //start in level1
        //根據time.time來慢慢增加速度
        //time.time  not work
        _currentTimePass += Time.deltaTime;
        _currentLevel = ( (int)_currentTimePass / 5)+1;
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

    public List<Mouse> getPlayerList()
    {
        return _playerList;
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

    public void updateMostRightCameraStopPoint()
    {
        //取得cameraStopPoint坐標
        if (_platformsList.Count < 1)
        {
            Debug.LogError("platforms count less than 1");
            return ;
        }

        foreach (Transform child in _platformsList[_platformsList.Count - 1].transform)
        {
            if (child.gameObject.tag == "cameraStopPoint")
            {
                _currentCameraStopPoint = child.position.x;
                return ;
            }
        }


        Debug.LogError("cant not find tag");
        return ;
    }

    public float getCameraStopPoint()
    {
        return _currentCameraStopPoint;
    }

    public Transform getCabinetObjectTransform(Transform platform)
    {
        foreach (Transform child in platform)
        {
            if (child.gameObject.tag == "bookShelfheight")
            {
                return child;
            }
        }

        Debug.LogError("cant not find tag");
        return null;
    }

    public float getRandomHeight()
    {
        //隨機出y畫面比例
        Bounds b = CameraUtils.OrthographicBounds(Camera.main);
        int randomNumber = Random.Range(2,7); //
        float yHeightInCamera = b.max.y - b.min.y;
        return b.min.y+  ((yHeightInCamera / 10.0f) * randomNumber);
    }
    
    public bool getIsCameraStop() {
        return _isCameraStop;
    }

    public void setIsCameraStop(bool Bool)
    {
        if (!Bool)
        {
            GameController.instance.OnExitCameraStopPoint();
            _currentTimer = 0;
        }
        _isCameraStop = Bool;
    }

    public void checkCameraPos()
    {
        float cameraStopPoint = getCameraStopPoint();
        //Debug.Log("point : " + cameraStopPoint);
        if (cameraStopPoint <= Camera.main.transform.position.x && !_isCameraStop)
        {
            _isCameraStop = true;
            GameController.instance.OnEnterCameraStopPoint();
            return;
        }
    }

    public int getWhoLoseTheGame()
    {
        //input playerList

        //-1 代表 未有玩家死亡 
        return -1;

    }

    /*
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
*/

}
