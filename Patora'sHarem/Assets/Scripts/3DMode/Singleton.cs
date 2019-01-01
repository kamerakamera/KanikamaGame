using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>{
	protected static T instance;
    public static T Instance{
        get{
            if(instance == null){
                instance = (T)FindObjectOfType(typeof(T));//Scene上のTの型のobjectを検索、初回の探索のみ動く
            }
        return instance;
        }

    }
    protected void Awake(){
        Checkinstance();
    }

    protected bool Checkinstance(){
        if(instance == null){
            instance = (T)this;
            return true;
        }else if(Instance == null){
            return true;
        }
        Destroy(this);
        return false;
    }
}
