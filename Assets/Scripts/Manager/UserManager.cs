using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : Singleton<UserManager>
{
    public UserModel UserModel = null;
    public List<UserModel> lsUsers = new();
   
}
